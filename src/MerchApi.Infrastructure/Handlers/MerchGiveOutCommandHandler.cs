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
    public class MerchGiveOutCommandHandler : IRequestHandler<MerchGiveOutCommand, MerchGiveOutRequestResponse>
    {
        private readonly ILogger<MerchGiveOutCommandHandler> _logger;

        public MerchGiveOutCommandHandler(ILogger<MerchGiveOutCommandHandler> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<MerchGiveOutRequestResponse> Handle(MerchGiveOutCommand request, CancellationToken cancellationToken)
        {
            _logger.LogDebug($"[{nameof(MerchGiveOutCommandHandler)}] Обработка запроса на выдачу мерча");

            return await Task.FromResult(new MerchGiveOutRequestResponse(new GetMerchPackResponseUnit("Short", 1)));
        }
    }
}
