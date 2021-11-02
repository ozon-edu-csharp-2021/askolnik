using MerchApi.Http.Models;

namespace MerchApi.Http.Responses
{
    public class GiveOutMerchRequestResponse
    {
        public GetMerchPackResponseUnit MerchPack { get; set; }

        public GiveOutMerchRequestResponse(GetMerchPackResponseUnit merchPack)
        {
            MerchPack = merchPack;
        }
    }
}
