using System.Net.Http;
using System.Threading.Tasks;

using MerchApi.Http.Responses;

namespace MerchApi.HttpClients
{
    public interface IMerchHttpClient
    {
        Task<GetMerchPackResponse> GetMerchPack(long id);
        Task<GetMerchDeliveryInfoResponse> GetMerchDeliveryInfo(long id);
    }

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

        public Task<GetMerchPackResponse> GetMerchPack(long id)
        {
            throw new System.NotImplementedException();
        }
    }
}
