using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using MerchApi.Infrastructure.Commands.GiveOutMerchRequestAggregate;

using Microsoft.Extensions.Logging;

namespace MerchApi.Infrastructure.Handlers.GiveOutMerchRequestAggregate
{
    public class GiveOutMerchCommandHandler : IRequestHandler<GiveOutMerchCommand>
    {
        private readonly ILogger<GiveOutMerchCommandHandler> _logger;

        public GiveOutMerchCommandHandler(ILogger<GiveOutMerchCommandHandler> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Обработка запроса на выдачу мерча
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Возвращает id созданного мерча</returns>
        public async Task<Unit> Handle(GiveOutMerchCommand request, CancellationToken cancellationToken)
        {
            _logger.LogDebug($"[{nameof(GiveOutMerchCommandHandler)}] Обработка запроса на выдачу мерча");

            return Unit.Value;
        }
    }
}
