using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MerchApi.Infrastructure.Middlewares
{
    /// <summary>
    /// Будет логгировать response поступающих http запросов, выводя при этом заголовки и route, по которому прошел запрос. Grpc запросы в этих middleware компонентах необходимо исключить.
    /// </summary>
    public class ResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ResponseLoggingMiddleware> _logger;

        public ResponseLoggingMiddleware(RequestDelegate next, ILogger<ResponseLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);
            await LogResponse(context);
        }

        private async Task LogResponse(HttpContext context)
        {
            try
            {
                if (context.Request.ContentType == "application/grpc" && context.Request.Protocol == "HTTP/2")
                {
                    return;
                }

                var hasStatus = Enum.TryParse<HttpStatusCode>(context.Response.StatusCode.ToString(), out var status);
                _logger.LogInformation($"[{nameof(ResponseLoggingMiddleware)}] -> StatusCode = '{(hasStatus ? status.ToString() : context.Response.StatusCode)}', ResponsePath = '{context.Request.Path}', Headers = '{JsonSerializer.Serialize(context.Response.Headers)}'");
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Could not log request body");
            }
        }
    }
}
