using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Dapper;

using MerchApi.Domain.AggregationModels.MerchAggregate;
using MerchApi.Infrastructure.Repositories.Infrastructure.Interfaces;

using Npgsql;

namespace MerchApi.Infrastructure.Repositories.Implementation
{
    public class GiveOutMerchRequestRepository : IGiveOutMerchRequestRepository
    {
        private readonly IDbConnectionFactory<NpgsqlConnection> _dbConnectionFactory;
        private readonly IChangeTracker _changeTracker;
        private const int Timeout = 5;

        public GiveOutMerchRequestRepository(
            IDbConnectionFactory<NpgsqlConnection> dbConnectionFactory,
            IChangeTracker changeTracker)
        {
            _dbConnectionFactory = dbConnectionFactory;
            _changeTracker = changeTracker;
        }

        //TODO:
        public async Task<GiveOutMerchRequest> CreateAsync(GiveOutMerchRequest itemToCreate, CancellationToken cancellationToken = default)
        {
            const string sql = @"";

            var parameters = new
            {
               // SkuId = itemToCreate.EmployeeId
            };

            var commandDefinition = new CommandDefinition(
                sql,
                parameters: parameters,
                commandTimeout: Timeout,
                cancellationToken: cancellationToken);

            var connection = await _dbConnectionFactory.CreateConnection(cancellationToken);
            await connection.ExecuteAsync(commandDefinition);
            _changeTracker.Track(itemToCreate);

            return itemToCreate;
        }

        public async Task<IReadOnlyList<GiveOutMerchRequest>> FindByEmployeeIdAsync(int employeeId, CancellationToken cancellationToken = default)
        {
            const string sql = @"
                SELECT
                    merch_requests.id,
                    merch_requests.employee_id,
                    merch_requests.merch_type_id,
                    merch_requests.merch_status_id,
                    merch_requests.issue_date,
                    merch_statuses.id,
                    merch_statuses.name,
                    merch_types.id,
                    merch_types.name
                FROM merch_requests      
                INNER JOIN merch_types on merch_requests.merch_type_id = merch_types.id
                INNER JOIN merch_statuses on merch_requests.merch_status_id = merch_statuses.id
                WHERE merch_requests.employee_id = @EmployeeId;";

            var parameters = new
            {
                EmployeeId = employeeId
            };

            var commandDefinition = new CommandDefinition(
                sql,
                parameters: parameters,
                commandTimeout: Timeout,
                cancellationToken: cancellationToken);

            var connection = await _dbConnectionFactory.CreateConnection(cancellationToken);

            var merchRequests = await connection.QueryAsync<Models.MerchRequest, Models.MerchStatus, Models.MerchType, GiveOutMerchRequest>(commandDefinition,
                (merchRequest, statusType, merchType) =>
                    new GiveOutMerchRequest(
                        merchRequest.EmployeeId,
                        new MerchType(merchType.Id, merchType.Name),
                        new RequestStatus(statusType.Id, statusType.Name),
                        merchRequest.IssueDate));

            var result = merchRequests.ToList();

            foreach (var merchRequest in result)
            {
                var subSql = $@"
                    SELECT
                        items.id,
                        items.merch_type_id,
                        items.name
                    FROM items      
                    WHERE items.merch_type_id = {merchRequest.MerchType.Id};";

                var definition = new CommandDefinition(
                    subSql,
                    commandTimeout: Timeout,
                    cancellationToken: cancellationToken);

                var items = await connection.QueryAsync<Models.Item>(definition);
                merchRequest.LoadMerchPack(items.Select(x => new Item(x.MerchTypeId, x.Name)));

                _changeTracker.Track(merchRequest);
            }

            return result;
        }
    }
}