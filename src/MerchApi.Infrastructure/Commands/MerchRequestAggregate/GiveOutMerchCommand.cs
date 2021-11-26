using MediatR;

using MerchApi.Http.Requests;

namespace MerchApi.Infrastructure.Commands.MerchRequestAggregate
{
    public record GiveOutMerchCommand(GiveOutMerchRequest Request) : IRequest;
}