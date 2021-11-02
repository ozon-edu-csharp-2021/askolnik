using MediatR;

using MerchApi.Http.Responses;

namespace MerchApi.Infrastructure.Queries.MerchAggregate
{
    public class GetMerchIssueCommand : IRequest<GetMerchDeliveryInfoResponse>
    {
        public long MerchId { get; }

        public GetMerchIssueCommand(long merchId)
        {
            MerchId = merchId;
        }
    }
}
