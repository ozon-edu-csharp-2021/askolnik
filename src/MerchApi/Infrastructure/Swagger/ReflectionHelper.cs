﻿using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MerchApi.Infrastructure.Swagger
{
    /// <summary>
    /// 
    /// </summary>
    public static class ReflectionHelper
    {
        public static string? AttributeReader<TAttr>(IEnumerable<CustomAttributeData> attributes)
        {
            var attr = attributes.FirstOrDefault(a => a.AttributeType == typeof(TAttr))?.ConstructorArguments.FirstOrDefault();
            return (attr != null && attr.Value != null) ? attr.Value.Value?.ToString() : null;
        }
    }
}