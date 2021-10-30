using System;
using System.Text.Json;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MerchApi.Infrastructure.Middlewares
{
    /// <summary>
    /// Будет логгировать request поступающих http запросов, выводя при этом заголовки и route, по которому прошел запрос. Grpc запросы в этих middleware компонентах необходимо исключить.
    /// </summary>
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            LogRequest(context);
            await _next(context);
        }

        private void LogRequest(HttpContext context)
        {
            try
            {
                if (context.Request.ContentType == "application/grpc" && context.Request.Protocol == "HTTP/2")
                {
                    return;
                }

                _logger.LogInformation($"[{nameof(RequestLoggingMiddleware)}] -> RequestMethod = '{context.Request.Method}', RequestPath = '{context.Request.Path}', Headers = '{JsonSerializer.Serialize(context.Request.Headers)}'");
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Could not log request body");
            }
        }
    }
}