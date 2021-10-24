using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace MerchApi.Infrastructure.Filters
{
    /// <summary>
    /// Глобальный фильтр всех исключений приложения
    /// </summary>
    public class GlobalExceptionFilter : ExceptionFilterAttribute
    {
        private readonly ILogger<GlobalExceptionFilter> _logger;

        public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// Выдает response с json, в котором будет наименование исключения (его тип) и стэк-трейс.
        /// </summary>
        /// <param name="context"></param>
        public override void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, $"[{nameof(GlobalExceptionFilter)}] -> {context.Exception.Message}");

            var resultObject = new
            {
                ExceptionType = context.Exception.GetType().FullName,
                Message = context.Exception.Message,
                StackTrace = context.Exception.StackTrace
            };

            var jsonResult = new JsonResult(resultObject)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };

            context.Result = jsonResult;
        }
    }
}
