using SevereWeatherWarnings.Map.Presenters.Interfaces;
using SevereWeatherWarnings.Models.Display;
using SevereWeatherWarnings.Models.Display.Common;
using APIWeatherWarning = SevereWeatherWarnings.Models.API.WeatherWarning;

namespace SevereWeatherWarnings.Map.Presenters
{
    public class MapWarningDetailPresenter : IMapWarningDetailPresenter
    {
        public WeatherWarningDetailsViewModel Present(APIWeatherWarning weatherWarning)
        {
            WeatherWarningDetailsViewModel viewModel = new WeatherWarningDetailsViewModel
            {
                Id = weatherWarning.Id,
                Type = weatherWarning.Type,
                WarningGeometry = MapWarningGeometry(weatherWarning)
            };

            return viewModel;
        }

        private Geometry MapWarningGeometry(APIWeatherWarning weatherWarning)
        {
            throw new NotImplementedException();
        }
    }
}
