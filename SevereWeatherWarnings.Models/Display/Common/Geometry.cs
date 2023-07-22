using SevereWeatherWarnings.Models.Enums;

namespace SevereWeatherWarnings.Models.Display.Common
{
    public class Geometry
    {
        public GoeJsonType Type { get; set; }
        public decimal[][][] CoOrdinates { get; set; }
    }
}
