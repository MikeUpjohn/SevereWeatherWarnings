﻿using SevereWeatherWarnings.Models.Display.Enums;

namespace SevereWeatherWarnings.Models.Display.Common
{
    public class WarningParameters
    {
        public WindThreatParameter WindThreat { get; set; }
        public MaxWindGustParameter MaxWindGust { get; set; }
    }

    public class WindThreatParameter : WarningParamaterBase
    {
        public WindThreat DisplayValue { get; set; }
    }

    public class MaxWindGustParameter : WarningParamaterBase
    {
        public string DisplayValue { get; set; }
    }
}