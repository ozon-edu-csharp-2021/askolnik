using MediatR;

using MerchApi.Http.Requests;

namespace MerchApi.Infrastructure.Commands.MerchRequestAggregate
{
    public class GiveOutMerchCommand : IRequest
    {
        public GiveOutMerchRequest Request { get; }

        public GiveOutMerchCommand(GiveOutMerchRequest request)
        {
            Request = request;
        }
    }
}