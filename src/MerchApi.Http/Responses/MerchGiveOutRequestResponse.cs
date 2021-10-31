using MerchApi.Http.Models;

namespace MerchApi.Http.Responses
{
    public class MerchGiveOutRequestResponse
    {
        public GetMerchPackResponseUnit MerchPack { get; set; }

        public MerchGiveOutRequestResponse(GetMerchPackResponseUnit merchPack)
        {
            MerchPack = merchPack;
        }
    }
}
