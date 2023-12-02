using SevereWeatherWarnings.Models;
using SevereWeatherWarnings.Models.API;

namespace SevereWeatherWarnings.Library.UseCases.Warnings.GetAllWeatherWarnings.Interfaces
{
    public interface IGetWeatherWarnings
    {
        Task<WeatherWarningsResponse> GetAllActiveWarnings(RetrieveDataRequest request);
    }
}
