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

        public Task<GetMerchIssueInfoResponse> GetMerchDeliveryInfo(long id)
        {
            throw new System.NotImplementedException();
        }

        public Task<GiveOutMerchResponse> GetMerchPack(long id)
        {
            throw new System.NotImplementedException();
        }
    }
}
