using Newtonsoft.Json;
using SevereWeatherWarnings.Library.Extensions;
using SevereWeatherWarnings.Library.UseCases.Warnings.GetAllWeatherWarnings.Interfaces;
using SevereWeatherWarnings.Models.API;

namespace SevereWeatherWarnings.Library.UseCases.Warnings.GetAllWeatherWarnings
{
    public class MapWarnings : IMapWarnings
    {
        public WeatherWarningsResponse Map(string rawData)
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
            } catch (Exception)
            {
                throw new Exception("Error during mapping warning data.");
            }
        }
    }
}
