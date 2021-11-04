﻿using MediatR;

using MerchApi.Http.Responses;

namespace MerchApi.Infrastructure.Queries.GetMerchIssueAggregate
{
    public class GetMerchIssueCommand : IRequest<GetMerchIssueInfoResponse>
    {
        public int EmployeeId { get; }

        public GetMerchIssueCommand(int employeeId)
        {
            EmployeeId = employeeId;
        }
    }
}