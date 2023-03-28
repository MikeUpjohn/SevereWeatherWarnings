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
    }
}
