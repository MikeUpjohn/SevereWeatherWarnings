using SevereWeatherWarnings.Models.API;

namespace SevereWeatherWarnings.Library.UseCases.Warnings.Interfaces
{
    public interface IMapWarnings
    {
        WeatherWarningsResponse Map(string rawData);
    }
}
