using SevereWeatherWarnings.Models.API;
using SevereWeatherWarnings.Models.Display;

namespace SevereWeatherWarnings.Map.Presenters.Interfaces
{
    public interface IMapWarningDataPresenter
    {
        WeatherWarningsViewModel Present(WeatherWarningsResponse weatherWarningsResponse);
    }
}
