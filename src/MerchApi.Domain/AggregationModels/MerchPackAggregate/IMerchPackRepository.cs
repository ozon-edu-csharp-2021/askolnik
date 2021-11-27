using System.Threading;
using System.Threading.Tasks;

using MerchApi.Domain.SharedKernel.Interfaces;

namespace MerchApi.Domain.AggregationModels.MerchPackAggregate
{
    public interface IMerchPackRepository : IRepository<MerchPack>
    {
        Task<MerchPack> GetMerchPackByMerchType(MerchType merchType, CancellationToken cancellationToken);
    }
}