using SevereWeatherWarnings.Models;
using SevereWeatherWarnings.Models.API;

namespace SevereWeatherWarnings.Library.UseCases.Warnings.GetSingleWarning.Interfaces
{
    public interface IGetSingleWeatherWarning
    {
        Task<WeatherWarning> GetWeatherWarningDetail(RetrieveWarningRequest request);
    }
}
