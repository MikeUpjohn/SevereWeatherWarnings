using System.ComponentModel;

namespace SevereWeatherWarnings.Models.Display.Enums
{
    public enum TornadoDamageThreat
    {
        [Description("CONSIDERABLE")]
        Considerable = 1,

        [Description("CATASTROPHIC")]
        Catastrophic = 2,
    }
}
