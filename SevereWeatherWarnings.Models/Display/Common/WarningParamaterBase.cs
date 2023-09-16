using SevereWeatherWarnings.Models.Display.Enums;

namespace SevereWeatherWarnings.Models.Display.Common
{
    public class WarningParamaterBase
    {
        public WarningParamaterType ParameterType { get; set; }
        public string[] RawValue { get; set; }
        public string CssClass { get; set; }
    }
}
