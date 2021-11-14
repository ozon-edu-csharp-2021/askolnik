using MerchApi.Domain.AggregationModels.MerchAggregate;
using MerchApi.GrpcServices;
using MerchApi.Infrastructure.Extensions;
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
            MerchApi.Infrastructure.ExtensionsAddMediator(services);


            services.AddSingleton<IGiveOutMerchRequestRepository, GiveOutMerchRequestRepositoryStub>();

           
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<MerchApiGrpcService>();
                endpoints.MapControllers();
            });
        }
    }
}