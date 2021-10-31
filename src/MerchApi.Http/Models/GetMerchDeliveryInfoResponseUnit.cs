using System;

namespace MerchApi.Http.Models
{
    public class GetMerchDeliveryInfoResponseUnit
    {
        public long Id { get; set; }
        public DateTime DeliveryDate { get; set; }

        public GetMerchDeliveryInfoResponseUnit(long id, DateTime deliveryDate)
        {
            Id = id;
            DeliveryDate = deliveryDate;
        }
    }
}
