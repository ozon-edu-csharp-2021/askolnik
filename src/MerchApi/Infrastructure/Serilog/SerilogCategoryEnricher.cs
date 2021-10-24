using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Serilog.Core;
using Serilog.Events;

namespace MerchApi.Infrastructure.Serilog
{
    public class SerilogCategoryEnricher : ILogEventEnricher
    {
        private readonly static Dictionary<string, LogEventProperty> _properties = new Dictionary<string, LogEventProperty>();

        /// <summary>
        /// Регистрация категории для класса
        /// </summary>
        /// <remarks>
        /// Метод явно регистрирует свойство 'Category', которое можно указать в шаблоне сообщения лога.
        /// Если явно не указывать это свойство, то его значение автоматически возьмётся из имени вызывающего лог класса.
        /// </remarks>
        /// <typeparam name="TCategoryUser">Класс, для которого регистрируется категория.</typeparam>
        /// <param name="categoryName">Имя категории. Если не указывать, то возьмётся имя класса из generic-а.</param>
        public static void RegisterCategory<TCategoryUser>(string categoryName = null)
        {
            var type = typeof(TCategoryUser);
            lock (_properties)
            {
                if (!_properties.ContainsKey(type.FullName))
                {
                    _properties.Add(type.FullName, new LogEventProperty("Category", new LogEventStringPropertyValue(categoryName ?? type.Name)));
                }
            }
        }

        /// <summary>
        /// Метод автоматически вызывается логгером при попытке записать лог.
        /// </summary>
        /// <remarks>
        /// В методе реализовано добавление свойства 'Category' в контекст сообщения.
        /// Значение свойства берётся из зарегистрированных значений.
        /// Если значение не зарегистрировано, то происходит его регистрация по имени класса из SourceContext или имени приложения.
        /// </remarks>
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var textWriter = new StringWriter();
            var key = logEvent.Properties.Keys.FirstOrDefault(k => k == "SourceContext");
            string source;
            if (key == null)
            {
                source = "UnknownCategory";
            }
            else
            {
                logEvent.Properties[key].Render(textWriter);
                source = textWriter.ToString().Trim('\"');
            }

            lock (_properties)
            {
                if (!_properties.TryGetValue(source, out var property))
                {
                    var dotIndex = source.LastIndexOf('.');
                    var category = dotIndex > 0 ? source.Substring(dotIndex + 1) : source;
                    property = propertyFactory.CreateProperty("Category", category);
                    _properties.Add(source, property);
                }
                logEvent.AddOrUpdateProperty(property);
            }
        }

        private class LogEventStringPropertyValue : LogEventPropertyValue
        {
            private readonly string _value;

            public LogEventStringPropertyValue(string value)
            {
                _value = value;
            }

            public override void Render(TextWriter output, string format = null, IFormatProvider formatProvider = null)
            {
                output.Write(_value);
            }
        }
    }
}
