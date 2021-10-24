using System.Threading.Tasks;

using MerchApi.Http.Requests;
using MerchApi.Http.Responses;
using MerchApi.Models;

namespace MerchApi.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface IMerchService
    {
        Task<GetMerchPackResponse> GetMerchPack(MerchPackDto request);
        Task<GetMerchDeliveryInfoResponse> GetMerchDeliveryInfo(MerchDeliveryInfo request);
    }
}
