using System;

using MerchApi.Http.Enums;

namespace MerchApi.Http.Models
{
    public class MerchIssueInfo
    {
        public long Id { get; set; }
        public DateTime DeliveryDate { get; set; }
        public MerchType MerchType { get; set; }

        public MerchIssueInfo(long id, DateTime deliveryDate, MerchType merchType)
        {
            Id = id;
            DeliveryDate = deliveryDate;
            MerchType = merchType;
        }
    }
}
