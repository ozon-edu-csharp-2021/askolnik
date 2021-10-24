using System.Threading.Tasks;
using System.Net.Http;

using MerchApi.Http.Requests;
using MerchApi.Http.Responses;

namespace MerchApi.HttpClients
{
    public interface IMerchHttpClient
    {
        Task<GetMerchPackResponse> GetMerchPack(GetMerchPackRequest request);
        Task<GetMerchDeliveryInfoResponse> GetMerchDeliveryInfo(GetMerchDeliveryInfoRequest request);
    }

    public class MerchHttpClient : IMerchHttpClient
    {
        private readonly HttpClient _httpClient;

        public MerchHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<GetMerchDeliveryInfoResponse> GetMerchDeliveryInfo(GetMerchDeliveryInfoRequest request)
        {
            throw new System.NotImplementedException();
        }

        public Task<GetMerchPackResponse> GetMerchPack(GetMerchPackRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}
