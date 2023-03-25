using System.ComponentModel;
using System.Reflection;

namespace SevereWeatherWarnings.Library.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(Enum value)
        {
            if(value == null) { return ""; }

            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[]) fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if(attributes != null && attributes.Length > 0)
            {
                return attributes[0].Description;
            }

            return "";
        }
    }
}
