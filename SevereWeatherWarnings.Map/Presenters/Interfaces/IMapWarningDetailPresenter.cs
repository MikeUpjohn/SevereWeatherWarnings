using SevereWeatherWarnings.Models.Display;

using APIWeatherWarning = SevereWeatherWarnings.Models.API.WeatherWarning;

namespace SevereWeatherWarnings.Map.Presenters.Interfaces
{
    public interface IMapWarningDetailPresenter
    {
        WeatherWarningDetailsViewModel Present(APIWeatherWarning weatherWarning);
    }
}
