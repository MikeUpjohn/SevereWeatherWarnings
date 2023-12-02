using Newtonsoft.Json;
using SevereWeatherWarnings.Library.Extensions;
using SevereWeatherWarnings.Library.UseCases.Warnings.GetSingleWarning.Interfaces;
using SevereWeatherWarnings.Models.API;

namespace SevereWeatherWarnings.Library.UseCases.Warnings.GetSingleWarning
{
    public class MapWarningDetail : IMapWarningDetail
    {
        public WeatherWarning Map(string rawData)
        {
            try
            {
                var mappedWarning = JsonConvert.DeserializeObject<WeatherWarning>(rawData);
                if (mappedWarning != null)
                {
                    mappedWarning.WarningProperties.EventType = mappedWarning.GetEventFromEventDescription();
                }

                return mappedWarning ?? new WeatherWarning();
            } catch (Exception)
            {
                throw new Exception("Error during mapping warning detail");
            }
        }
    }
}
