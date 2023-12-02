using SevereWeatherWarnings.Models;
using SevereWeatherWarnings.Models.API;

namespace SevereWeatherWarnings.Library.UseCases.Warnings.Interfaces
{
    public interface IWarnings
    {
        Task<WeatherWarningsResponse> GetAllActiveWarnings(RetrieveDataRequest request);

        Task<WeatherWarning> GetWeatherWarningDetail(RetrieveWarningRequest request);
    }
}
