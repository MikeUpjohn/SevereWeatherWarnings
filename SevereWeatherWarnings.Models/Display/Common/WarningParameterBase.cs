using SevereWeatherWarnings.Models.Display.Enums;

namespace SevereWeatherWarnings.Models.Display.Common
{
    public class WarningParameterBase
    {
        public WarningParameterType ParameterType { get; set; }
        public string[] RawValue { get; set; }
        public string CssClass { get; set; }
    }
}
