using MerchApi.GrpcServices;
using MerchApi.Infrastructure.Interceptors;
using MerchApi.Services;
using MerchApi.Services.Implementation;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Serilog;
using Serilog.Extensions.Logging;


namespace MerchandiseService
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
            var providers = new LoggerProviderCollection();
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(Configuration).CreateLogger();

            services.AddSingleton<IMerchService, MerchService>();
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