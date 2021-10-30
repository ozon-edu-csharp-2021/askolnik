using System.Threading.Tasks;

using MerchApi.Http.Responses;

namespace MerchApi.HttpClients
{
    public interface IMerchHttpClient
    {
        Task<GetMerchPackResponse> GetMerchPack(long id);
        Task<GetMerchDeliveryInfoResponse> GetMerchDeliveryInfo(long id);
    }
}
