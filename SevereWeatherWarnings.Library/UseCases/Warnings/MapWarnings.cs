using Newtonsoft.Json;
using SevereWeatherWarnings.Library.Extensions;
using SevereWeatherWarnings.Library.UseCases.Warnings.Interfaces;
using SevereWeatherWarnings.Models;
using SevereWeatherWarnings.Models.API;
using SevereWeatherWarnings.Models.Enums;

namespace SevereWeatherWarnings.Library.UseCases.Warnings
{
    public class MapWarnings : IMapWarnings
    {
        public WeatherWarningsResponse Map(RetrieveDataRequest request, string rawData)
        {
            try
            {
                var mappedWarnings = JsonConvert.DeserializeObject<WeatherWarningsResponse>(rawData);

                // Mapping Custom Fields
                foreach(var weatherWarning in mappedWarnings.WeatherWarnings)
                {
                    weatherWarning.WarningProperties.EventType = EnumExtensions.GetEnumValueFromDescription<Event>(weatherWarning.WarningProperties.Event); 
                }

                return mappedWarnings;
            }
            catch(Exception)
            {
                int a = 1;
                return null;
            }
        }
    }
}
