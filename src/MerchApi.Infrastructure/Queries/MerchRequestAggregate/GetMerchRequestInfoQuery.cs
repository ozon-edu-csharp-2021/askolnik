using MediatR;

using MerchApi.Http.Responses;

namespace MerchApi.Infrastructure.Queries.MerchRequestAggregate
{
    public record GetMerchRequestInfoQuery(string EmployeeEmail) : IRequest<GetMerchRequestInfoResponse>;
}