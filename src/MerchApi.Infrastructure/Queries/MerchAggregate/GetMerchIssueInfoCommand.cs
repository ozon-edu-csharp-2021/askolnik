using MediatR;

using MerchApi.Http.Responses;

namespace MerchApi.Infrastructure.Queries.MerchAggregate
{
    public class GetMerchIssueInfoCommand : IRequest<GetMerchIssueInfoResponse>
    {
        public long MerchId { get; }

        public GetMerchIssueInfoCommand(long merchId)
        {
            MerchId = merchId;
        }
    }
}
