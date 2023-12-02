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

        public string WeatherWarningClassFor(Event eventType)
        {
            switch(eventType)
            {
                case Event.TornadoWarning:
                    return "tornado-warning";
                case Event.SevereThunderstormWarning:
                    return "severe-thunderstorm-warning";
                case Event.FloodWarning:
                    return "flood-warning";
                default:
                    return "";
            }
        }
    }
}
