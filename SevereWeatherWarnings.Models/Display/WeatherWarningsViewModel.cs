using SevereWeatherWarnings.Models.Display.Common;
using SevereWeatherWarnings.Models.Enums;

namespace SevereWeatherWarnings.Models.Display
{
    public class WeatherWarningsViewModel
    {
        public AlertCollectionGeoJSONType Type { get; set; }
        public IList<WeatherWarning> WeatherWarnings { get; set; }
    }

    public class WeatherWarning
    {
        public string Id { get; set; }
        public string FriendlyId { get; set; }
        public GeoJsonFeatureType Type { get; set; }
        public Geometry WarningGeometry { get; set; }
        public WarningProperties WarningProperties { get; set; }
        public DisplayProperties DisplayProperties { get; set; }
    }
}
