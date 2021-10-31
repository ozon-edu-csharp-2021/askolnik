using MediatR;

using MerchApi.Http.Requests;
using MerchApi.Http.Responses;

namespace MerchApi.Infrastructure.Commands
{
    public class MerchGiveOutCommand : IRequest<MerchGiveOutRequestResponse>
    {
        public MerchGiveOutRequest Request { get; }

        public MerchGiveOutCommand(MerchGiveOutRequest request)
        {
            Request = request;
        }
    }
}
