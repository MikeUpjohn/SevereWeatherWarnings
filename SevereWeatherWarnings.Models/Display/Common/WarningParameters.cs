using SevereWeatherWarnings.Models.Display.Enums;

namespace SevereWeatherWarnings.Models.Display.Common
{
    public class WarningParameters
    {
        public WindThreatParameter WindThreat { get; set; }
        public MaxWindGustParameter MaxWindGust { get; set; }
        public HailThreatParameter HailThreat { get; set; }
    }

    public class WindThreatParameter : WarningParameterBase
    {
        public WindThreat DisplayValue { get; set; }
    }

    public class MaxWindGustParameter : WarningParameterBase
    {
        public string DisplayValue { get; set; }
    }

    public class HailThreatParameter : WarningParameterBase
    {
        public HailThreat DisplayValue { get; set; }
    }
}
