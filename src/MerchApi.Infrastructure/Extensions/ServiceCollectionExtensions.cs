using System.Reflection;

using MediatR;

using Microsoft.Extensions.DependencyInjection;

namespace MerchApi.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Добавление в DI контейнер инфраструктурных сервисов
        /// </summary>
        /// <param name="services">Объект IServiceCollection</param>
        /// <returns>Объект <see cref="IServiceCollection"/></returns>
        public static IServiceCollection AddMediatR(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            // Add MediatR
            services.AddMediatR(assembly);

            return services;
        }
    }
}