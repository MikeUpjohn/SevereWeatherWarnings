using Newtonsoft.Json;
using SevereWeatherWarnings.Library.Extensions;
using SevereWeatherWarnings.Library.UseCases.Warnings.Interfaces;
using SevereWeatherWarnings.Models;
using SevereWeatherWarnings.Models.API;

namespace SevereWeatherWarnings.Library.UseCases.Warnings
{
    public class MapWarnings : IMapWarnings
    {
        public WeatherWarningsResponse Map(RetrieveDataRequest request, string rawData)
        {
            try
            {
                var mappedWarnings = JsonConvert.DeserializeObject<WeatherWarningsResponse>(rawData);

                if (mappedWarnings != null)
                {
                    foreach (var weatherWarning in mappedWarnings.WeatherWarnings)
                    {
                        weatherWarning.WarningProperties.EventType = weatherWarning.GetEventFromEventDescription();
                    }
                }

                return mappedWarnings ?? new WeatherWarningsResponse();
            }
            catch(Exception)
            {
                throw new Exception($"Error during mapping warning data.");
            }
        }
    }
}
