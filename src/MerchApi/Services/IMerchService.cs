using System.Threading.Tasks;

using CSharpFunctionalExtensions;

using MerchApi.Http.Responses;

namespace MerchApi.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface IMerchService
    {
        Task<Maybe<GetMerchPackResponse>> GetMerchPack(long id);
        Task<Maybe<GetMerchDeliveryInfoResponse>> GetMerchDeliveryInfo(long id);
    }
}
