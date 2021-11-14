using System;
using System.Threading;
using System.Threading.Tasks;

namespace MerchApi.Domain.SharedKernel.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ValueTask StartTransaction(CancellationToken token);

        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}