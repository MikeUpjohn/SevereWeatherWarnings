﻿using SevereWeatherWarnings.Models.Enums;

namespace SevereWeatherWarnings.Models
{
    public class RetrieveDataRequest
    {
        public IList<Event?> Event { get; set; }
        public bool IsTestingMode { get; set; }
    }
}
