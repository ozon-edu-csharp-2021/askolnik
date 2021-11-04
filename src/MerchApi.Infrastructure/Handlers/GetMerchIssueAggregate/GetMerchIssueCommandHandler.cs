﻿using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using MerchApi.Domain.AggregationModels.EmployeeAggregate;
using MerchApi.Domain.AggregationModels.GetMerchIssueAggregate;
using MerchApi.Http.Models;
using MerchApi.Http.Responses;
using MerchApi.Infrastructure.Queries.GetMerchIssueAggregate;

using Microsoft.Extensions.Logging;

namespace MerchApi.Infrastructure.Handlers.GetMerchIssueAggregate
{
    public class GetMerchIssueCommandHandler : IRequestHandler<GetMerchIssueCommand, GetMerchIssueInfoResponse>
    {
        private readonly ILogger<GetMerchIssueCommandHandler> _logger;
        private readonly IMerchIssueRepository _merchIssueRepository;

        public GetMerchIssueCommandHandler(
            ILogger<GetMerchIssueCommandHandler> logger,
            IMerchIssueRepository merchIssueRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _merchIssueRepository = merchIssueRepository ?? throw new ArgumentNullException(nameof(merchIssueRepository));
        }

        public async Task<GetMerchIssueInfoResponse> Handle(GetMerchIssueCommand request, CancellationToken cancellationToken)
        {
            _logger.LogDebug($"[{nameof(GetMerchIssueCommandHandler)}] Проверка, выдавался ли мерч");

            var issuedMerches = await _merchIssueRepository.FindByEmployeeAsync(new Employee(request.EmployeeId), cancellationToken);
            if (issuedMerches is null || issuedMerches.Count == 0)
                throw new Exception($"Not found for EmployeeId = '{request.EmployeeId}'");

            var response = new GetMerchIssueInfoResponse();

            foreach (var item in issuedMerches)
            {
                if (Enum.TryParse<Http.Enums.MerchType>(item.MerchType.Name, out var merchType))
                {
                    response.IssuedMerchs.Add(new MerchIssueInfo(item.EmployeeId, item.IssueDate, merchType));
                }
                else
                {
                    throw new InvalidCastException($"Не смог привести '{item.MerchType.Name}' к типу '{typeof(Http.Enums.MerchType).FullName}'");
                }
            }
 
            return await Task.FromResult(response);
        }
    }
}
