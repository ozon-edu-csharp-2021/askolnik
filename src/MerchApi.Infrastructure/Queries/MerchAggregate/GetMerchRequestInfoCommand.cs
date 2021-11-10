using MediatR;

using MerchApi.Http.Responses;

namespace MerchApi.Infrastructure.Queries.MerchAggregate
{
    public class GetMerchRequestInfoCommand : IRequest<GetMerchRequestInfoResponse>
    {
        public int EmployeeId { get; }

        public GetMerchRequestInfoCommand(int employeeId)
        {
            EmployeeId = employeeId;
        }
    }
}