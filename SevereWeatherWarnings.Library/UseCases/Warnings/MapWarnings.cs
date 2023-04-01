using Newtonsoft.Json;
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
                // Will be expanded on later to add additional non-JSON fields.
                var mappedWarnings = JsonConvert.DeserializeObject<WeatherWarningsResponse>(rawData);
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
