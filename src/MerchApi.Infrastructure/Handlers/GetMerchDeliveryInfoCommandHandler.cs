using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using MerchApi.Http.Models;
using MerchApi.Http.Responses;
using MerchApi.Infrastructure.Commands;

using Microsoft.Extensions.Logging;

namespace MerchApi.Infrastructure.Handlers
{
    public class GetMerchDeliveryInfoCommandHandler : IRequestHandler<GetMerchDeliveryInfoCommand, GetMerchDeliveryInfoResponse>
    {
        private readonly ILogger<GetMerchDeliveryInfoCommandHandler> _logger;

        public GetMerchDeliveryInfoCommandHandler(ILogger<GetMerchDeliveryInfoCommandHandler> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<GetMerchDeliveryInfoResponse> Handle(GetMerchDeliveryInfoCommand request, CancellationToken cancellationToken)
        {
            _logger.LogDebug($"[{nameof(GetMerchDeliveryInfoCommandHandler)}] Проверка, выдавалсяли мерч");

            return await Task.FromResult(new GetMerchDeliveryInfoResponse(new GetMerchDeliveryInfoResponseUnit(1, DateTime.UtcNow)));
        }
    }
}
