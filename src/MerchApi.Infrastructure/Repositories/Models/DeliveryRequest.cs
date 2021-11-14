using System.Diagnostics.CodeAnalysis;

namespace MerchApi.Infrastructure.Repositories.Models
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class DeliveryRequest
    {
        public long Id { get; set; }

        public long RequestId { get; set; }

        public int RequestStatus { get; set; }
    }
}