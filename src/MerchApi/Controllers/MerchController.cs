using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

using MediatR;

using MerchApi.Http.Requests;
using MerchApi.Http.Responses;
using MerchApi.Infrastructure.Commands;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MerchApi.Controllers
{
    [Route("api/merches")]
    [Produces("application/json")]
    [ApiController]
    public class MerchController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediator;

        public MerchController(
            ILogger<MerchController> logger,
            IMediator mediator)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// Запрос на выдачу мерча
        /// </summary>
        /// <returns>GetMerchPackResponse</returns>
        /// <response code="200">Request is accepted</response>
        /// <response code="400">Invalid request</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpPost]
        public async Task<ActionResult<MerchGiveOutRequestResponse>> GetMerchPack([FromBody][Required] MerchGiveOutRequest request)
        {
            _logger.LogInformation($"Поступил запрос на выдачу мерча");

            var response = await _mediator.Send(new MerchGiveOutCommand(request));

            return Ok(response);
        }

        /// <summary>
        /// Метод возвращает информацию о выдаче мерча по id
        /// </summary>
        /// <returns>GetMerchPackResponse</returns>
        /// <response code="200">Request is accepted</response>
        /// <response code="400">Invalid request</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpGet("{id:long}/delivery")]
        public async Task<ActionResult<MerchGiveOutRequestResponse>> GetMerchDeliveryInfo([FromRoute][Required] long id)
        {
            _logger.LogInformation($"Поступил запрос на получение информации о выдаче мерча");

            var response = await _mediator.Send(new GetMerchDeliveryInfoCommand(id));

            return Ok(response);
        }
    }
}