using System.Net.Http;
using System.Threading.Tasks;

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

        public Task<GetMerchDeliveryInfoResponse> GetMerchDeliveryInfo(long id)
        {
            throw new System.NotImplementedException();
        }

        public Task<GiveOutMerchRequestResponse> GetMerchPack(long id)
        {
            throw new System.NotImplementedException();
        }
    }
}
