using API.Attributes;
using System.Reflection;

namespace API.Extensions.Enums
{
    public static class EnumStringExtension
    {
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
