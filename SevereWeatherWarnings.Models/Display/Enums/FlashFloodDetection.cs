using System.ComponentModel;

namespace SevereWeatherWarnings.Models.Display.Enums
{
    public enum FlashFloodDetection
    {
        [Description("RADAR INDICATED")]
        RadarIndicated = 1,

        [Description("RADAR AND GAUGE INDICATED")]
        RadarAndGaugeIndicated = 2,

        [Description("OBSERVED")]
        Observed = 3
    }
}
