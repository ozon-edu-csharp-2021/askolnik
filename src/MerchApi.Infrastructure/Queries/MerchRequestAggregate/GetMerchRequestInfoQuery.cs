using MediatR;

using MerchApi.Http.Responses;

namespace MerchApi.Infrastructure.Queries.MerchRequestAggregate
{
    public class GetMerchRequestInfoQuery : IRequest<GetMerchRequestInfoResponse>
    {
        public string EmployeeEmail { get; }

        public GetMerchRequestInfoQuery(string employeeEmail)
        {
            EmployeeEmail = employeeEmail;
        }
    }
}