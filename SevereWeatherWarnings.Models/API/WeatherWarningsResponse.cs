using Newtonsoft.Json;
using SevereWeatherWarnings.Models.Enums;

namespace SevereWeatherWarnings.Models.API
{
    public class WeatherWarningsResponse
    {
        public AlertCollectionGeoJSONType Type { get; set; }

        [JsonProperty("features")]
        public IList<WeatherWarning> WeatherWarnings { get; set; }
    }

    public class WeatherWarning
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public GeoJsonFeatureType Type { get; set; }

        [JsonProperty("geometry")]
        public Geometry WarningGeometry { get; set; }

        [JsonProperty("properties")]
        public WarningProperties WarningProperties { get; set; }
    }

    public class Geometry
    {
        [JsonProperty("type")]
        public GoeJsonType Type { get; set; }

        [JsonProperty("coordinates")]
        public decimal[][][] CoOrdinates { get; set; }
    }

    public class WarningProperties
    {
        [JsonProperty("@id")]
        public string UrlId { get; set; }

        [JsonProperty("@type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("areaDesc")]
        public string AreaDescription { get; set; }

        [JsonProperty("sent")]
        public DateTime? SentDate { get; set; }

        [JsonProperty("effective")]
        public DateTime? EffectiveDate { get; set; }

        [JsonProperty("onset")]
        public DateTime? OnsetDate { get; set; }

        [JsonProperty("expires")]
        public DateTime? ExpiryDate { get; set; }

        [JsonProperty("status")]
        public AlertStatus AlertStatus { get; set; }

        [JsonProperty("messageType")]
        public MessageType MessageType { get; set; }

        [JsonProperty("category")]
        public Category Category { get; set; }

        [JsonProperty("severity")]
        public Severity Severity { get; set; }

        [JsonProperty("certainty")]
        public Certainty Certainty { get; set; }

        [JsonProperty("urgency")]
        public Urgency Urgency { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        public Event EventType { get; set; }

        [JsonProperty("headline")]
        public string Headline { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("instruction")]
        public string Instruction { get; set; }

        [JsonProperty("response")]
        public Response Response { get; set; }
    }
}
