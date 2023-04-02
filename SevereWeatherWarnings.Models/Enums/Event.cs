using System.ComponentModel;

namespace SevereWeatherWarnings.Models.Enums
{
    public enum Event
    {
        [Description("Blowing Dust Warning")]
        BlowingDustWarning = 1,
        [Description("Flash Flood Statement")]
        FlashFloodStatement = 38,
        [Description("Flash Flood Warning")]
        FlashFloodWarning = 39,
        [Description("Flash Flood Watch")]
        FlashFloodWatch = 40,
        [Description("Severe Thunderstorm Warning")]
        SevereThunderstormWarning = 90,
        [Description("Severe Thunderstorm Watch")]
        SevereThunderstormWatch = 91,
        [Description("Severe Weather Statement")]
        SevereWeatherStatement = 92,
        [Description("Tornado Warning")]
        TornadoWarning = 108,
        [Description("Tornado Watch")]
        TornadoWatch = 109
    }
}
