using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Dapper;

using MerchApi.Domain.AggregationModels.MerchPackAggregate;
using MerchApi.Domain.AggregationModels.MerchRequestAggregate;
using MerchApi.Infrastructure.Repositories.Infrastructure.Interfaces;

using Npgsql;

namespace MerchApi.Infrastructure.Repositories.Implementation
{
    public class GiveOutMerchRequestRepository : IGiveOutMerchRequestRepository
    {
        private readonly IDbConnectionFactory<NpgsqlConnection> _dbConnectionFactory;
        private readonly IQueryExecutor _queryExecutor;
        private const int Timeout = 5;

        public GiveOutMerchRequestRepository(
            IDbConnectionFactory<NpgsqlConnection> dbConnectionFactory,
            IQueryExecutor queryExecutor)
        {
            _dbConnectionFactory = dbConnectionFactory;
            _queryExecutor = queryExecutor;
        }

        public async Task<int> CreateAsync(GiveOutMerchRequest itemToCreate, CancellationToken cancellationToken = default)
        {
            const string sql = @"
                INSERT INTO merch_requests 
                    (request_status_id, employee_email, merch_pack_id, create_date, issue_date)
                VALUES (@RequestStatusId, @EmployeeEmail, @MerchPackId, @CreateDate, null)
                RETURNING id;";

            var parameters = new
            {
                RequestStatusId = itemToCreate.Status.Id,
                EmployeeEmail = itemToCreate.Employee.Email.Value,
                MerchPackId = itemToCreate.MerchPack.Id,
                CreateDate = itemToCreate.CreatedDate
            };

            var commandDefinition = new CommandDefinition(
                sql,
                parameters: parameters,
                commandTimeout: Timeout,
                cancellationToken: cancellationToken);

            var connection = await _dbConnectionFactory.CreateConnection(cancellationToken);

            await _queryExecutor.Execute(itemToCreate, async () =>
            {
                var r = await connection.ExecuteAsync(commandDefinition);
                itemToCreate.SetId(r);
            });

            return itemToCreate.Id;
        }

        public async Task<IReadOnlyList<GiveOutMerchRequest>> FindByEmployeeEmailAsync(string employeeEmail, CancellationToken cancellationToken = default)
        {
            const string sql = @"
                SELECT mr.id, mr.request_status_id, mr.employee_email, mr.merch_pack_id, mr.create_date, mr.issue_date,
		                rs.id, rs.name,
		                mp.id, mp.merch_type_id, mp.can_be_reissued, mp.can_be_reissued_after_days,
		                mt.id, mt.name,
		                sk.id, sk.value
                FROM merch_requests mr
                INNER JOIN merch_request_statuses rs ON rs.id = mr.request_status_id
                INNER JOIN merch_packes mp ON mp.id = mr.merch_pack_id
                INNER JOIN merch_types mt ON mt.id = mp.merch_type_id
                INNER JOIN skus sk ON sk.merch_pack_id = mp.id
                WHERE mr.employee_email = @Email;";

            var parameters = new
            {
                Email = employeeEmail
            };

            var commandDefinition = new CommandDefinition(
                sql,
                parameters: parameters,
                commandTimeout: Timeout,
                cancellationToken: cancellationToken);

            var connection = await _dbConnectionFactory.CreateConnection(cancellationToken);
            var orderDictionary = new Dictionary<int, GiveOutMerchRequest>();

            var result = await _queryExecutor.Execute<GiveOutMerchRequest>(
                  async () =>
                  {
                      var list = (await connection.QueryAsync<
                          Models.MerchRequest, Models.MerchStatus, Models.MerchPack, Models.MerchType, Models.Sku, GiveOutMerchRequest>(
                          commandDefinition,
                          (merchRequest, status, pack, type, sku) =>
                          {
                              if (!orderDictionary.TryGetValue(merchRequest.Id, out GiveOutMerchRequest orderEntry))
                              {
                                  orderEntry = GiveOutMerchRequest.Create(
                                      merchRequest.Id,
                                      Employee.Create(Email.Create(merchRequest.EmployeeEmail)),
                                      new RequestStatus(status.Id, status.Name),
                                      new MerchPack(
                                          new MerchType(type.Id, type.Name),
                                          new List<Sku>(),
                                          pack.CanBeReissued,
                                          pack.CanBeReissuedAfterDays),
                                      merchRequest.CreateDate,
                                      merchRequest.IssueDate
                                      );

                                  orderDictionary.Add(orderEntry.Id, orderEntry);
                              }

                              orderEntry.MerchPack.AddSkuToMerchPack(new List<Sku>() { Sku.Create(sku.Value) });
                              return orderEntry;
                          },
                          splitOn: "Id")).Distinct().ToList();

                      return list;
                  });

            return result.ToList();
        }
    }
}