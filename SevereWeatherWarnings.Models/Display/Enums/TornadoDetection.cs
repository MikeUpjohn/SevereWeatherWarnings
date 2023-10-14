using System.ComponentModel;

namespace SevereWeatherWarnings.Models.Display.Enums
{
    public enum TornadoDetection
    {
        [Description("RADAR INDICATED")]
        RadarIndicated = 1,

        [Description("OBSERVED")]
        Observed = 2
    }
}
