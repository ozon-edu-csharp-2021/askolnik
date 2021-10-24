using System.Net;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

namespace MerchApi.Infrastructure.Middlewares
{
    /// <summary>
    /// возвращать по пути "/ready" ответ 200 Ok.
    /// </summary>
    public class ReadyMiddleware
    {
        public ReadyMiddleware(RequestDelegate next)
        {
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Response.StatusCode = (int)HttpStatusCode.OK;

            await Task.CompletedTask;
        }
    }
}
