using MediatR;

using MerchApi.Http.Responses;

namespace MerchApi.Infrastructure.Queries.MerchRequestAggregate
{
    public class GetMerchRequestInfoQuery : IRequest<GetMerchRequestInfoResponse>
    {
        public int EmployeeId { get; }

        public GetMerchRequestInfoQuery(int employeeId)
        {
            EmployeeId = employeeId;
        }
    }
}