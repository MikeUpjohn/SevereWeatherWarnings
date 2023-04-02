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

        public static T GetEnumValueFromDescription<T>(string value)
        {
            if(Enum.IsDefined(typeof(T), value))
            {
                return (T) Enum.Parse(typeof(T), value, true);
            } else
            {
                string[] enumNames = Enum.GetNames(typeof(T));
                foreach(var enumName in enumNames)
                {
                    object parsedEnumValue = Enum.Parse(typeof(T), enumName);
                    if(value == GetDescription((Enum)parsedEnumValue))
                    {
                        return (T) parsedEnumValue;
                    }
                }
            }

            return default(T);
        }
    }
}
