using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

using MerchApi.Http.Responses;
using MerchApi.Services;

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
        private readonly IMerchService _merchService;

        public MerchController(ILogger<MerchController> logger, IMerchService merchService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _merchService = merchService ?? throw new ArgumentNullException(nameof(merchService));
        }

        /// <summary>
        /// Метод возвращает мерч по id
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
        [HttpGet("{id:long}")]
        public async Task<ActionResult<GetMerchPackResponse>> GetMerchPack([FromRoute][Required] long id)
        {
            _logger.LogInformation($"Поступил запрос на получения мерча");

            var response = await _merchService.GetMerchPack(id);

            return Ok(response);
        }

        /// <summary>
        /// Метод возвращает мерч по id
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
        public async Task<ActionResult<GetMerchPackResponse>> GetMerchDeliveryInfo([FromRoute][Required] long id)
        {
            _logger.LogInformation($"Поступил запрос на получение информации о выдаче мерча");

            var response = await _merchService.GetMerchDeliveryInfo(id);

            return response.HasValue ? Ok(response) : NotFound();
        }
    }
}