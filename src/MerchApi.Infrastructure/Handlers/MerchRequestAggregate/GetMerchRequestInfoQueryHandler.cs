using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using MerchApi.Domain.AggregationModels.MerchRequestAggregate;
using MerchApi.Http.Models;
using MerchApi.Http.Responses;
using MerchApi.Infrastructure.Queries.MerchRequestAggregate;

using Microsoft.Extensions.Logging;

namespace MerchApi.Infrastructure.Handlers.MerchRequestAggregate
{
    public class GetMerchRequestInfoQueryHandler : IRequestHandler<GetMerchRequestInfoQuery, GetMerchRequestInfoResponse>
    {
        private readonly ILogger<GetMerchRequestInfoQueryHandler> _logger;
        private readonly IGiveOutMerchRequestRepository _merchRepository;

        public GetMerchRequestInfoQueryHandler(
            ILogger<GetMerchRequestInfoQueryHandler> logger,
            IGiveOutMerchRequestRepository merchRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _merchRepository = merchRepository ?? throw new ArgumentNullException(nameof(merchRepository));
        }

        public async Task<GetMerchRequestInfoResponse> Handle(GetMerchRequestInfoQuery request, CancellationToken cancellationToken)
        {
            _logger.LogDebug($"[{nameof(GetMerchRequestInfoQueryHandler)}] Проверка, выдавался ли мерч");

            var issuedMerches = await _merchRepository.FindByEmployeeIdAsync(request.EmployeeEmail, cancellationToken);

            if (issuedMerches is null || issuedMerches.Count == 0)
            {
                throw new Exception($"Not found for EmployeeEmail = '{request.EmployeeEmail}'");
            }

            var response = new GetMerchRequestInfoResponse();

            foreach (var item in issuedMerches)
            {
                if (Enum.TryParse<Http.Enums.MerchType>(item.MerchPack.MerchType.Name, out var merchType))
                {
                    response.IssuedMerchs.Add(new MerchIssueInfo(item.IssueDate, merchType));
                }
                else
                {
                    throw new InvalidCastException($"Не смог привести '{item.MerchPack.MerchType.Name}' к типу '{typeof(Http.Enums.MerchType).FullName}'");
                }
            }

            return await Task.FromResult(response);
        }
    }
}