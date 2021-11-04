﻿using System;
using System.IO;
using System.Reflection;

using MediatR;

using MerchApi.Infrastructure.Filters;
using MerchApi.Infrastructure.StartupFilters;
using MerchApi.Infrastructure.Swagger;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace MerchApi.Infrastructure.Extensions
{
    /// <summary>
    /// Класс для расширения функионала CreateHostBuilder
    /// </summary>
    public static class HostBuilderExtensions
    {
        /// <summary>
        /// Настройка инфраструктуры сервиса
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IHostBuilder AddInfrastructure(this IHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var assembly = Assembly.GetExecutingAssembly();
                // Add filters
                services.AddSingleton<IStartupFilter, TerminalStartupFilter>();
                services.AddSingleton<IStartupFilter, SwaggerStartupFilter>();

                services.AddSwaggerGen(c =>
                {
                    var attributes = assembly.CustomAttributes;
                    var swaggerDocVersion = ReflectionHelper.AttributeReader<AssemblyVersionAttribute>(attributes) ?? ReflectionHelper.AttributeReader<AssemblyFileVersionAttribute>(attributes);
                    var swaggerDocTitle = ReflectionHelper.AttributeReader<AssemblyTitleAttribute>(attributes);
                    var swaggerDocDescription = ReflectionHelper.AttributeReader<AssemblyDescriptionAttribute>(attributes);

                    c.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Title = swaggerDocTitle,
                        Version = swaggerDocVersion,
                        Description = swaggerDocDescription
                    });

                    c.CustomSchemaIds(x => x.FullName);

                    var xmlFile = $"{assembly.GetName().Name}.xml";
                    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                    c.IncludeXmlComments(xmlPath);
                });
            });

            return builder;
        }

        /// <summary>
        /// Добавление глобального фильтра прерываний
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IHostBuilder AddGlobalExceptionFilter(this IHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddControllers(options => options.Filters.Add<GlobalExceptionFilter>());
            });

            return builder;
        }
    }
}