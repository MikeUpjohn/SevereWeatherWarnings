using SevereWeatherWarnings.Map.Presenters.Interfaces;
using SevereWeatherWarnings.Models.Display;
using APIWeatherWarning = SevereWeatherWarnings.Models.API.WeatherWarning;
using DisplayGeometry = SevereWeatherWarnings.Models.Display.Common.Geometry;
using DisplayWarningProperties = SevereWeatherWarnings.Models.Display.Common.WarningProperties;

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
                WarningGeometry = MapWarningGeometry(weatherWarning),
                WarningProperties = MapWarningProperties(weatherWarning),
            };

            return viewModel;
        }

        private DisplayGeometry MapWarningGeometry(APIWeatherWarning weatherWarning)
        {
            var displayGeometry = new DisplayGeometry
            {
                Type = weatherWarning.WarningGeometry.Type,
                CoOrdinates = weatherWarning.WarningGeometry.CoOrdinates,
            };

            return displayGeometry;
        }

        private DisplayWarningProperties MapWarningProperties(APIWeatherWarning weatherWarning)
        {
            var warningProperties = weatherWarning.WarningProperties;
            var displayWarningProperties = new DisplayWarningProperties
            {
                Event = warningProperties.Event
            };

            return displayWarningProperties;
        }
    }
}
