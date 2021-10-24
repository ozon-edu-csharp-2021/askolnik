using System.Reflection;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

namespace MerchApi.Infrastructure.Middlewares
{
    /// <summary>
    /// 
    /// </summary>
    public class VersionMiddleware
    {
        public VersionMiddleware(RequestDelegate next)
        {
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "no version";
            await context.Response.WriteAsync(version);
        }
    }
}
