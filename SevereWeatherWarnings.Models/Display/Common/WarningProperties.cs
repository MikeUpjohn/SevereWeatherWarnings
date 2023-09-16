using SevereWeatherWarnings.Models.Enums;

namespace SevereWeatherWarnings.Models.Display.Common
{
    public class WarningProperties
    {
        public string UrlId { get; set; }
        public string Type { get; set; }
        public string Id { get; set; }
        public string AreaDescription { get; set; }
        public WarningDate SentDate { get; set; }
        public WarningDate EffectiveDate { get; set; }
        public WarningDate OnsetDate { get; set; }
        public WarningDate ExpiryDate { get; set; }
        public AlertStatus AlertStatus { get; set; }
        public MessageType MessageType { get; set; }
        public Category Category { get; set; }
        public Severity Severity { get; set; }
        public Certainty Certainty { get; set; }
        public Urgency Urgency { get; set; }
        public string Event { get; set; }
        public Event EventType { get; set; }
        public string SenderName { get; set; }
        public string Headline { get; set; }
        public string Description { get; set; }
        public string Instruction { get; set; }
        public Response Response { get; set; }
        public WarningParameters Parameters { get; set; }
    }
}
