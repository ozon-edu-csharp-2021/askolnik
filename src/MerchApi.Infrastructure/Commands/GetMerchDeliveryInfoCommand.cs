using MediatR;

using MerchApi.Http.Responses;

namespace MerchApi.Infrastructure.Commands
{
    public class GetMerchDeliveryInfoCommand : IRequest<GetMerchDeliveryInfoResponse>
    {
        public long MerchId { get; }

        public GetMerchDeliveryInfoCommand(long merchId)
        {
            MerchId = merchId;
        }
    }
}
