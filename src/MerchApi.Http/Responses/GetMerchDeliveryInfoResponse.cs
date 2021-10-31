using MerchApi.Http.Models;

namespace MerchApi.Http.Responses
{
    public class GetMerchDeliveryInfoResponse
    {
        public GetMerchDeliveryInfoResponseUnit MerchDeliveryInfo { get; set; }

        public GetMerchDeliveryInfoResponse(GetMerchDeliveryInfoResponseUnit merchDeliveryInfo)
        {
            MerchDeliveryInfo = merchDeliveryInfo;
        }
    }
}
