using System.Threading.Tasks;

using MerchApi.Http.Responses;
using MerchApi.Models;

namespace MerchApi.Services.Implementation
{
    /// <summary>
    /// 
    /// </summary>
    public class MerchService : IMerchService
    {
        public Task<GetMerchDeliveryInfoResponse> GetMerchDeliveryInfo(MerchDeliveryInfo request)
        {
            throw new System.NotImplementedException();
        }

        public Task<GetMerchPackResponse> GetMerchPack(MerchPackDto request)
        {
            throw new System.NotImplementedException();
        }
    }
}
