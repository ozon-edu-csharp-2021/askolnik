using System.Threading.Tasks;

using MerchApi.Http.Responses;

namespace MerchApi.HttpClients
{
    public interface IMerchHttpClient
    {
        Task<GiveOutMerchResponse> GetMerchPack(long id);
        Task<GetMerchIssueInfoResponse> GetMerchDeliveryInfo(long id);
    }
}
