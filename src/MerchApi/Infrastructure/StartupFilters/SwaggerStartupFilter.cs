using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;


namespace MerchApi.Infrastructure.StartupFilters
{
    /// <summary>
    /// 
    /// </summary>
    public class SwaggerStartupFilter : IStartupFilter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="next"></param>
        /// <returns></returns>
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return app =>
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                next(app);
            };
        }
    }
}
