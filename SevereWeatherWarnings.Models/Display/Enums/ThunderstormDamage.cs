using System.ComponentModel;

namespace SevereWeatherWarnings.Models.Display.Enums
{
    public enum ThunderstormDamage
    {
        [Description("CONSIDERABLE")]
        Considerable = 1,
        [Description("DESTRUCTIVE")]
        Destructive = 2
    }
}
