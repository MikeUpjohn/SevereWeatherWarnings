using SevereWeatherWarnings.Models.API;

namespace SevereWeatherWarnings.Library.UseCases.Warnings.GetSingleWarning.Interfaces
{
    public interface IMapWarningDetail
    {
        WeatherWarning Map(string rawData);
    }
}
