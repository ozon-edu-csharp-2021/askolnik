using MediatR;

using MerchApi.Domain.AggregationModels.MerchRequestAggregate;
using MerchApi.Domain.SharedKernel.Interfaces;
using MerchApi.GrpcServices;
using MerchApi.Infrastructure.Configuration;
using MerchApi.Infrastructure.Extensions;
using MerchApi.Infrastructure.Repositories.Implementation;
using MerchApi.Infrastructure.Repositories.Infrastructure;
using MerchApi.Infrastructure.Repositories.Infrastructure.Interfaces;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Npgsql;

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
            AddMediator(services);
            AddDatabaseComponents(services);
            AddRepositories(services);
        }

        private static void AddMediator(IServiceCollection services)
        {
            services.AddMediatR();
        }

        private void AddDatabaseComponents(IServiceCollection services)
        {
            services.Configure<DatabaseConnectionOptions>(Configuration.GetSection(nameof(DatabaseConnectionOptions)));
            services.AddScoped<IDbConnectionFactory<NpgsqlConnection>, NpgsqlConnectionFactory>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IChangeTracker, ChangeTracker>();
            services.AddScoped<IQueryExecutor, QueryExecutor>();
        }

        private void AddRepositories(IServiceCollection services)
        {
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
            services.AddScoped<IGiveOutMerchRequestRepository, GiveOutMerchRequestRepository>();
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