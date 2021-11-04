using MerchApi.Domain.AggregationModels.GetMerchIssueAggregate;
using MerchApi.GrpcServices;
using MerchApi.Infrastructure.Extensions;
using MerchApi.Infrastructure.Interceptors;
using MerchApi.Infrastructure.Stubs;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MerchApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMediatR();
            services.AddSingleton<IMerchIssueRepository, MerchIssueRepository>();

            services.AddGrpc(options => options.Interceptors.Add<GrpcLoggingInterceptor>());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<MerchApiGrpService>();
                endpoints.MapControllers();
            });
        }
    }
}
