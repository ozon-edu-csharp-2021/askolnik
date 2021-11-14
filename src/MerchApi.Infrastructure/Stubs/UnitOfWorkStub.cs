using System.Threading;
using System.Threading.Tasks;

using MerchApi.Domain.SharedKernel.Interfaces;

namespace MerchApi.Infrastructure.Stubs
{
    public class UnitOfWorkStub : IUnitOfWork
    {
        public void Dispose()
        {
        }

        public ValueTask StartTransaction(CancellationToken token)
        {
            return ValueTask.CompletedTask;
        }

        Task IUnitOfWork.SaveChangesAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}