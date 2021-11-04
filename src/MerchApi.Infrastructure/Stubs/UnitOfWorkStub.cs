using System.Threading;
using System.Threading.Tasks;

using MerchApi.Domain.SharedKernel.Interfaces;

namespace MerchApi.Infrastructure.Stubs
{
    public class UnitOfWorkStub : IUnitOfWork
    {
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(0);
        }

        public Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(true);
        }
    }
}
