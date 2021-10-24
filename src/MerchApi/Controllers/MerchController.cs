using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;

using MerchApi.Http.Requests;
using MerchApi.Http.Responses;
using MerchApi.Mappers;
using MerchApi.Services;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MerchApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/merches")]
    [Produces("application/json")]
    [ApiController]
    public class MerchController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IMerchService _merchService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="merchService"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public MerchController(ILogger<MerchController> logger, IMerchService merchService)
        {
            _logger = logger;
            _merchService = merchService ?? throw new ArgumentNullException(nameof(merchService));
        }


        ///// <summary>
        ///// Метод создает кампанию
        ///// </summary>
        ///// <remarks>
        ///// </remarks>
        ///// <param name="request"></param>
        ///// <returns></returns>
        ///// <response code="201">Request is created</response>            
        ///// <response code="400">Invalid request</response>                                                                                                                       
        ///// <response code="500">Internal Server Error</response>                                          
        ///// <response code="503">Service Unavailable</response>                                          
        //[ProducesResponseType(200)]
        //[ProducesResponseType(400)]
        //[ProducesResponseType(500)]
        //[ProducesResponseType(503)]
        //[HttpGet]
        //public async Task<ActionResult<GetMerchPackResponse>> CreateCampaign(GetMerchPackRequest request)
        //{
        //    _logger.LogInformation($"Поступил запрос на получения мерча");

        //    var campaignDto = RequestMapper.CreateDto(request);
        //    var response = await _merchService.GetMerchPack(campaignDto);

        //    return Ok(response);
        //}

        /// <summary>
        /// Метод возвращает кампанию по id
        /// </summary>
        /// <returns>OfferDtoList</returns>
        /// <response code="200">Request is accepted</response>            
        /// <response code="400">Invalid request</response>                                                             
        /// <response code="404">Not Found</response>                                                            
        /// <response code="500">Internal Server Error</response>                                          
        /// <response code="503">Service Unavailable</response>                                          
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [ProducesResponseType(503)]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult> ReadCampaign([FromRoute][Required] Guid id)
        {
            return Ok();
        }

    }
}