using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using MerchApi.Http.Models;
using MerchApi.Http.Responses;
using MerchApi.Infrastructure.Queries.MerchAggregate;

using Microsoft.Extensions.Logging;

namespace MerchApi.Infrastructure.Handlers.MerchAggregate
{
    public class GetMerchDeliveryInfoCommandHandler : IRequestHandler<GetMerchIssueInfoCommand, GetMerchIssueInfoResponse>
    {
        private readonly ILogger<GetMerchDeliveryInfoCommandHandler> _logger;

        public GetMerchDeliveryInfoCommandHandler(ILogger<GetMerchDeliveryInfoCommandHandler> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<GetMerchIssueInfoResponse> Handle(GetMerchIssueInfoCommand request, CancellationToken cancellationToken)
        {
            _logger.LogDebug($"[{nameof(GetMerchDeliveryInfoCommandHandler)}] Проверка, выдавалсяли мерч");

            var response = new GetMerchIssueInfoResponse();

            response.IssuedMerchs.Add(new MerchIssueInfo(1, DateTime.UtcNow, Http.Enums.MerchType.WelcomePack));

            return await Task.FromResult(response);
        }
    }
}
