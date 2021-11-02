using System.Threading.Tasks;

using MerchApi.Http.Responses;

namespace MerchApi.HttpClients
{
    public interface IMerchHttpClient
    {
        Task<GiveOutMerchRequestResponse> GetMerchPack(long id);
        Task<GetMerchDeliveryInfoResponse> GetMerchDeliveryInfo(long id);
    }
}
