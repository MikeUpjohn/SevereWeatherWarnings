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
        public DateTimeOffset? SentDate { get; set; }

        [JsonProperty("effective")]
        public DateTimeOffset? EffectiveDate { get; set; }

        [JsonProperty("onset")]
        public DateTimeOffset? OnsetDate { get; set; }

        [JsonProperty("expires")]
        public DateTimeOffset? ExpiryDate { get; set; }

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

        public Event? EventType { get; set; }

        [JsonProperty("senderName")]
        public string SenderName { get; set; }

        [JsonProperty("headline")]
        public string Headline { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("instruction")]
        public string Instruction { get; set; }

        [JsonProperty("response")]
        public Response Response { get; set; }

        [JsonProperty("parameters")]
        public WarningParameters Parameters { get; set; }
    }

    public class WarningParameters
    {
        [JsonProperty("windThreat")]
        public string[] WindThreat { get; set; }

        [JsonProperty("maxWindGust")]
        public string[] MaxWindGust { get; set; }

        [JsonProperty("hailThreat")]
        public string[] HailThreat { get; set; }

        [JsonProperty("maxHailSize")]
        public string[] MaxHailSize { get; set; }

        [JsonProperty("thunderstormDamage")]
        public string[] ThunderstormDamage { get; set; }

        [JsonProperty("tornadoDetection")]
        public string[] TornadoDetection { get; set; }

        [JsonProperty("tornadoDamageThreat")]
        public string[] TornadoDamageThreat { get; set; }

        [JsonProperty("flashFloodDetection")]
        public string[] FlashFloodDetection { get; set; }

        [JsonProperty("flashFloodDamageThreat")]
        public string[] FlashFloodDamageThreat { get; set; }

        [JsonProperty("snowSquallDetection")]
        public string[] SnowSquallDetection { get; set; }

        [JsonProperty("snowSquallImpact")]
        public string[] SnowSquallImpact { get; set; }

        [JsonProperty("waterspoutDetection")]
        public string[] WaterspoutDetection { get; set; }
    }
}
