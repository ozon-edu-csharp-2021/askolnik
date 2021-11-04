using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using MerchApi.Http.Requests;
using MerchApi.Http.Responses;
using MerchApi.Infrastructure.Commands.MerchAggregate;
using MerchApi.Infrastructure.Queries.MerchAggregate;

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
        /// Обработка запроса от Админки на выдачу мерча сотруднику
        /// </summary>
        /// <returns>GiveOutMerchResponse</returns>
        /// <response code="200">Request is accepted</response>
        /// <response code="400">Invalid request</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpPost]
        public async Task<ActionResult<int>> GiveOutMerch([FromBody][Required] GiveOutMerchRequest request, CancellationToken token)
        {
            _logger.LogInformation($"Поступил запрос на выдачу мерча");

            var command = new GiveOutMerchCommand(request);
            var response = await _mediator.Send(command, token);

            return response != 0 ? StatusCode((int)HttpStatusCode.OK, response) : StatusCode((int)HttpStatusCode.InternalServerError);
        }

        /// <summary>
        /// Обработка запроса от Админки на получение информации о выдаче мерча по employeeId сотрудника
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
        [HttpGet("{employeeId:long}")]
        public async Task<ActionResult<GetMerchIssueInfoResponse>> GetMerchDeliveryInfo([FromRoute][Required] long employeeId, CancellationToken token)
        {
            _logger.LogInformation($"Поступил запрос на получение информации о выдаче мерча для сотрудника = '{employeeId}'");

            var query = new GetMerchIssueInfoCommand(employeeId);
            var response = await _mediator.Send(query, token);

            return Ok(response);
        }
    }
}