using API.Attributes;
using System.Reflection;

namespace API.Extensions.Enums
{
    /// <summary>
    /// Класс расширение для Enum
    /// </summary>
    public static class EnumStringExtension
    {
        /// <summary>
        /// Метод для получение данных строки из аттрибута
        /// </summary>
        /// <param name="value">Enum из которого необходимо получить строку</param>
        /// <returns>Значение строки для данного Enum</returns>
        public static string GetStringValue(this Enum value)
        {
            var type = value.GetType();
            var fieldInfo = type.GetField(value.ToString());
            if (fieldInfo == null)
            {
                return string.Empty;
            }
            var attribs = fieldInfo.GetCustomAttributes(
                typeof(StringValueAttribute), false) as StringValueAttribute[];
            if (attribs == null)
            {
                return string.Empty;
            }
            var attrib = attribs.FirstOrDefault();
            if (attrib == null)
            {
                return string.Empty;
            }
            return attrib.StringValue;
        }
    }
}
