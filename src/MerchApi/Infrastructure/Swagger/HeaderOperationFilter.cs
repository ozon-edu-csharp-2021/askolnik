using System.Collections.Generic;

using Microsoft.OpenApi.Models;

using Swashbuckle.AspNetCore.SwaggerGen;

namespace MerchApi.Infrastructure.Swagger
{
    /// <summary>
    /// 
    /// </summary>
    public class HeaderOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Parameters ??= new List<OpenApiParameter>();
            operation.Parameters.Add(new OpenApiParameter
            {
                In = ParameterLocation.Header,
                Name = "Askolnik",
                Required = false,
                Schema = new OpenApiSchema { Type = "string" }
            });
        }
    }
}
