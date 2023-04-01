using SevereWeatherWarnings.Models;
using SevereWeatherWarnings.Models.API;

namespace SevereWeatherWarnings.Library.UseCases.Warnings.Interfaces
{
    public interface IMapWarnings
    {
        WeatherWarningsResponse Map(RetrieveDataRequest request, string rawData);
    }
}
