using System.Threading.Tasks;

using MerchApi.Http.Requests;
using MerchApi.Http.Responses;

namespace MerchApi.HttpClients
{
    public interface IMerchHttpClient
    {
        Task<int> GiveOutMerch(GiveOutMerchRequest request);
        Task<GetMerchRequestInfoResponse> GetMerchDeliveryInfo(long employeeId);
    }
}
