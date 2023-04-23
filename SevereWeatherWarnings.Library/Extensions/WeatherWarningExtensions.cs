using SevereWeatherWarnings.Models.API;
using SevereWeatherWarnings.Models.Enums;

namespace SevereWeatherWarnings.Library.Extensions
{
    public static class WeatherWarningExtensions
    {
        public static Event GetEventFromEventDescription(this WeatherWarning weatherWarning)
        {
            return EnumExtensions.GetEnumValueFromDescription<Event>(weatherWarning.WarningProperties.Event);
        }

        public static string GetWarningColours(this WeatherWarning weatherWarning)
        {
            switch (weatherWarning.WarningProperties.EventType)
            {
                case Event.BlowingDustWarning:
                    break;
                case Event.FlashFloodStatement:
                    break;
                case Event.FlashFloodWarning:
                    break;
                case Event.FlashFloodWatch:
                    break;
                case Event.FloodWarning:
                    return "#00FF00";
                case Event.SevereThunderstormWarning:
                    return "#FFA500";
                case Event.SevereThunderstormWatch:
                    break;
                case Event.SevereWeatherStatement:
                    break;
                case Event.TornadoWarning:
                    break;
                case Event.TornadoWatch:
                    break;
            }

            return "";
        }
    }
}
