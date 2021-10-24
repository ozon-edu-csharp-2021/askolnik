using System.Threading.Tasks;

using MerchApi.Http.Responses;

namespace MerchApi.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface IMerchService
    {
        Task<GetMerchPackResponse> GetMerchPack(long id);
        Task<GetMerchDeliveryInfoResponse> GetMerchDeliveryInfo(long id);
    }
}
