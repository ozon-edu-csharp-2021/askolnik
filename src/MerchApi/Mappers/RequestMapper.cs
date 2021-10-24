using MerchApi.Http.Requests;
using MerchApi.Models;

namespace MerchApi.Mappers
{
    /// <summary>
    /// 
    /// </summary>
    public static class RequestMapper
    {
        public static MerchPackDto CreateDto(GetMerchPackRequest request)
        {
            var result = new MerchPackDto
            {
                Id = request.Id,
            };

            return result;
        }
    }
}
