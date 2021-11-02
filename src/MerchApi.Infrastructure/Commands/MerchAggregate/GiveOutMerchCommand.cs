using MediatR;

using MerchApi.Http.Requests;
using MerchApi.Http.Responses;

namespace MerchApi.Infrastructure.Commands.MerchAggregate
{
    public class GiveOutMerchCommand : IRequest<GiveOutMerchRequestResponse>
    {
        public GiveOutMerchRequest Request { get; }

        public GiveOutMerchCommand(GiveOutMerchRequest request)
        {
            Request = request;
        }
    }
}
