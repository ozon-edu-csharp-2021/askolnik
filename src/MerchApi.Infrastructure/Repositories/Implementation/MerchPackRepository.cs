using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Dapper;

using MerchApi.Domain.AggregationModels.MerchPackAggregate;
using MerchApi.Infrastructure.Repositories.Infrastructure.Interfaces;

using Npgsql;

namespace MerchApi.Infrastructure.Repositories.Implementation
{
    public class MerchPackRepository : IMerchPackRepository
    {
        private readonly IDbConnectionFactory<NpgsqlConnection> _dbConnectionFactory;
        private readonly IQueryExecutor _queryExecutor;
        private const int Timeout = 5;

        public MerchPackRepository(
            IDbConnectionFactory<NpgsqlConnection> dbConnectionFactory,
            IQueryExecutor queryExecutor)
        {
            _dbConnectionFactory = dbConnectionFactory;
            _queryExecutor = queryExecutor;
        }

        public async Task<MerchPack> GetMerchPackByMerchType(MerchType merchType, CancellationToken cancellationToken)
        {
            const string sql = @"
                    Select *
                    FROM merch_packes 
                    WHERE merch_packes.merch_type_id = @MerchTypeId;";

            var parameters = new
            {
                MerchTypeId = merchType.Id,
            };

            var commandDefinition = new CommandDefinition(
               sql,
               parameters: parameters,
               commandTimeout: Timeout,
               cancellationToken: cancellationToken);

            var connection = await _dbConnectionFactory.CreateConnection(cancellationToken);
            var merchPack = connection.QueryFirst<Models.MerchPack>(commandDefinition);

            const string sql2 = @"
                    Select *
                    FROM skus 
                    WHERE skus.merch_pack_id = @MerchPackId;";

            var par = new
            {
                MerchPackId = merchPack.Id,
            };

            commandDefinition = new CommandDefinition(
              sql2,
              parameters: par,
              commandTimeout: Timeout,
              cancellationToken: cancellationToken);

            var skus = connection.Query<Models.Sku>(commandDefinition);

            var result = new MerchPack(
                merchType,
                new List<Sku>(skus.Select(x => Sku.Create(x.Value))),
                merchPack.CanBeReissued,
                merchPack.MerchTypeId
                );

            result.SetId(merchPack.Id);

            return result;
        }
    }
}