using System;
using System.Threading.Tasks;

using CSharpFunctionalExtensions;

using MerchApi.Http.Models;
using MerchApi.Http.Responses;

using Microsoft.Extensions.Logging;

namespace MerchApi.Services.Implementation
{
    public class MerchService : IMerchService
    {
        private readonly ILogger _logger;

        public MerchService(ILogger<MerchService> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Task<Maybe<GetMerchPackResponse>> GetMerchPack(long id)
        {
            _logger.LogDebug("Получаем мерч...");

            // Для того, чтобы проверить логгирование ошибок, кинем тут исключение
            throw new NotImplementedException();
        }

        public Task<Maybe<GetMerchDeliveryInfoResponse>> GetMerchDeliveryInfo(long id)
        {
            _logger.LogDebug("Получаем информацию о выдаче мерча...");

            var result = id != 0
                ? Maybe<GetMerchDeliveryInfoResponse>.From(new GetMerchDeliveryInfoResponse
                {
                    MerchDeliveryInfo = new GetMerchDeliveryInfoResponseUnit
                    {
                        Id = 1,
                        DeliveryDate = DateTime.UtcNow
                    }
                })
                : Maybe<GetMerchDeliveryInfoResponse>.None;

            return Task.FromResult(result);
        }
    }
}
