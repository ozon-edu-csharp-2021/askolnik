using System.Net.Http;
using System.Threading.Tasks;

using MerchApi.Http.Requests;
using MerchApi.Http.Responses;

namespace MerchApi.HttpClients.Implementation
{
    public class MerchHttpClient : IMerchHttpClient
    {
        private readonly HttpClient _httpClient;

        public MerchHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<GetMerchRequestInfoResponse> GetMerchDeliveryInfo(long employeeId)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> GiveOutMerch(GiveOutMerchRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}
