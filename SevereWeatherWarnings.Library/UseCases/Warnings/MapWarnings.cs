using Newtonsoft.Json;
using SevereWeatherWarnings.Library.UseCases.Warnings.Interfaces;
using SevereWeatherWarnings.Models.API;

namespace SevereWeatherWarnings.Library.UseCases.Warnings
{
    public class MapWarnings : IMapWarnings
    {
        public WeatherWarningsResponse Map(string rawData)
        {
            // Will be expanded on later to add additional non-JSON fields.
            return JsonConvert.DeserializeObject<WeatherWarningsResponse>(rawData);
        }
    }
}
