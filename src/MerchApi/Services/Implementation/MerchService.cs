using System;
using System.Threading.Tasks;

using MerchApi.Http.Models;
using MerchApi.Http.Responses;

using Microsoft.Extensions.Logging;

namespace MerchApi.Services.Implementation
{
    /// <summary>
    /// 
    /// </summary>
    public class MerchService : IMerchService
    {
        private readonly ILogger _logger;

        public MerchService(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<MerchService>();
        }


        public Task<GetMerchPackResponse> GetMerchPack(long id)
        {
            _logger.LogDebug("Получаем мерч");
            throw new NotImplementedException();
        }

        public Task<GetMerchDeliveryInfoResponse> GetMerchDeliveryInfo(long id)
        {
            _logger.LogDebug("Получаем информацию о выдаче мерча");

            return Task.FromResult(new GetMerchDeliveryInfoResponse()
            {
                MerchDeliveryInfo = new GetMerchDeliveryInfoResponseUnit
                {
                    Id = id,
                    DeliveryDate = DateTime.UtcNow
                }
            });
        }
    }
}
