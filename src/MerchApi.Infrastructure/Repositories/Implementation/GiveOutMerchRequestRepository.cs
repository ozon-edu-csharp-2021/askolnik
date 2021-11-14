using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using MerchApi.Domain.AggregationModels.MerchAggregate;
using MerchApi.Domain.SharedKernel.Interfaces;
using MerchApi.Infrastructure.Repositories.Infrastructure.Interfaces;

using Npgsql;

namespace MerchApi.Infrastructure.Repositories.Implementation
{
    public class GiveOutMerchRequestRepository : IGiveOutMerchRequestRepository
    {
        private readonly IDbConnectionFactory<NpgsqlConnection> _dbConnectionFactory;
        private readonly IChangeTracker _changeTracker;

        public GiveOutMerchRequestRepository(
            IDbConnectionFactory<NpgsqlConnection> dbConnectionFactory,
            IChangeTracker changeTracker)
        {
            _dbConnectionFactory = dbConnectionFactory;
            _changeTracker = changeTracker;
        }

        public IUnitOfWork UnitOfWork => throw new System.NotImplementedException();

        public Task<GiveOutMerchRequest> CreateAsync(GiveOutMerchRequest itemToCreate, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<GiveOutMerchRequest>> FindByEmployeeAsync(int employeeId, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }
    }
}