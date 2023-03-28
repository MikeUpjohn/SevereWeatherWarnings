using Newtonsoft.Json;
using SevereWeatherWarnings.Models.Enums;

namespace SevereWeatherWarnings.Models.API
{
    public class WeatherWarningsResponse
    {
        public AlertCollectionGeoJSONType Type { get; set; }
        public IList<Features> Features { get; set; }
    }

    public class Features
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public GeoJsonFeatureType Type { get; set; }

        [JsonProperty("geometry")]
        public Geometry Geometry { get; set; }
    }

    public class Geometry
    {
        [JsonProperty("type")]
        public GoeJsonType Type { get; set; }

        [JsonProperty("coordinates")]
        public decimal[][][] CoOrdinates { get; set; }
    }
}
