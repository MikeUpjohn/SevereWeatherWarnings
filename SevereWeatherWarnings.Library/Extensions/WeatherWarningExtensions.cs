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

        public static DisplayProperties GetWarningColours(this WeatherWarning weatherWarning)
        {
            var displayProperties = new DisplayProperties();

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
                    displayProperties.FillColourHexCode = "#00FF00";
                    displayProperties.LineColourHexCode = "#00FF00";
                    break;
                case Event.SevereThunderstormWarning:
                    displayProperties.FillColourHexCode = "#FFA500";
                    displayProperties.LineColourHexCode = "#FFA500";
                    break;
                case Event.SevereThunderstormWatch:
                    break;
                case Event.SevereWeatherStatement:
                    break;
                case Event.TornadoWarning:
                    break;
                case Event.TornadoWatch:
                    break;
                    
            }

            return displayProperties;
        }
    }
}
