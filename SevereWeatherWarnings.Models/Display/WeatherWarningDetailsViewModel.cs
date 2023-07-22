using SevereWeatherWarnings.Models.Display.Common;
using SevereWeatherWarnings.Models.Enums;

namespace SevereWeatherWarnings.Models.Display
{
    public class WeatherWarningDetailsViewModel
    {
        public string Id { get; set; }
        public GeoJsonFeatureType Type { get; set; }
        public Geometry WarningGeometry { get; set; }
        public WarningProperties WarningProperties { get; set; }
    }
}
