using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using MerchApi.Domain.AggregationModels.MerchAggregate;
using MerchApi.Http.Models;
using MerchApi.Http.Responses;
using MerchApi.Infrastructure.Queries.MerchAggregate;

using Microsoft.Extensions.Logging;

namespace MerchApi.Infrastructure.Handlers.MerchAggregate
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

            var issuedMerches = await _merchRepository.FindByEmployeeAsync(request.EmployeeId, cancellationToken);

            if (issuedMerches is null || issuedMerches.Count == 0)
            {
                throw new Exception($"Not found for EmployeeId = '{request.EmployeeId}'");
            }

            var response = new GetMerchRequestInfoResponse();

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