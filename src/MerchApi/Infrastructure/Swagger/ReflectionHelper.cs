using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MerchApi.Infrastructure.Swagger
{
    public static class ReflectionHelper
    {
        public static string? AttributeReader<TAttr>(IEnumerable<CustomAttributeData> attributes)
        {
            var attr = attributes.FirstOrDefault(a => a.AttributeType == typeof(TAttr))?.ConstructorArguments.FirstOrDefault();
            return attr?.Value?.ToString();
        }
    }
}