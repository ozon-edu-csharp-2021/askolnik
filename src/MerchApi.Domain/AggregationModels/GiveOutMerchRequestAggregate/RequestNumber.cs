namespace MerchApi.Domain.AggregationModels.GiveOutMerchRequestAggregate
{
    public class RequestNumber
    {
        public long Value { get; }

        public RequestNumber(long value)
        {
            Value = value;
        }
    }
}
