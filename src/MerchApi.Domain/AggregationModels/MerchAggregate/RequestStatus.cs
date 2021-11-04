using MerchApi.Domain.SharedKernel.Models;

namespace MerchApi.Domain.AggregationModels.MerchAggregate
{
    public class RequestStatus : Enumeration
    {
        public static RequestStatus Draft = new(0, "Draft");
        public static RequestStatus Created = new(1, "Created");
        public static RequestStatus InWork = new(2, "InWork");
        public static RequestStatus Done = new(3, "Done");

        public RequestStatus(int id, string name) : base(id, name)
        {
        }
    }
}