using SevereWeatherWarnings.Map.Presenters.Interfaces;
using SevereWeatherWarnings.Models.API;
using SevereWeatherWarnings.Models.Display;
using APIWeatherWarning = SevereWeatherWarnings.Models.API.WeatherWarning;
using DisplayWeatherWarning = SevereWeatherWarnings.Models.Display.WeatherWarning;
using DisplayGeometry = SevereWeatherWarnings.Models.Display.Geometry;
using DisplayWarningProperties = SevereWeatherWarnings.Models.Display.WarningProperties;
using SevereWeatherWarnings.Library.Extensions;

namespace SevereWeatherWarnings.Map.Presenters
{
    public class MapWarningDataPresenter : IMapWarningDataPresenter
    {
        public WeatherWarningsViewModel Present(WeatherWarningsResponse weatherWarningsResponse)
        {
            WeatherWarningsViewModel? viewModel = new WeatherWarningsViewModel
            {
                Type = weatherWarningsResponse.Type,
                WeatherWarnings = new List<DisplayWeatherWarning>()
            };

            MapWeatherWarnings(viewModel, weatherWarningsResponse.WeatherWarnings);

            return viewModel;
        }

        private void MapWeatherWarnings(WeatherWarningsViewModel viewModel, IList<APIWeatherWarning> apiWeatherWarnings)
        {
            foreach (var apiWeatherWarning in apiWeatherWarnings)
            {
                var displayWeatherWarning = new DisplayWeatherWarning
                {
                    Id = apiWeatherWarning.Id,
                    Type = apiWeatherWarning.Type,
                    WarningGeometry = MapWarningGeometry(apiWeatherWarning),
                    WarningProperties = MapWarningProperties(apiWeatherWarning),
                    DisplayProperties = MapDisplayProperties(apiWeatherWarning)
                };

                viewModel.WeatherWarnings.Add(displayWeatherWarning);
            };
        }

        private DisplayGeometry MapWarningGeometry(APIWeatherWarning weatherWarning)
        {
            var displayGeometry = new DisplayGeometry
            {
                Type = weatherWarning.WarningGeometry.Type,
                CoOrdinates = weatherWarning.WarningGeometry.CoOrdinates
            };

            return displayGeometry;
        }

        private DisplayWarningProperties MapWarningProperties(APIWeatherWarning weatherWarning)
        {
            var warningProperties = weatherWarning.WarningProperties;
            var displayWarningProperties = new DisplayWarningProperties
            {
                UrlId = warningProperties.UrlId,
                Type = warningProperties.Type,
                Id = warningProperties.Id,
                AreaDescription = warningProperties.AreaDescription,
                SentDate = MapDateProperties(warningProperties.SentDate),
                EffectiveDate = MapDateProperties(warningProperties.EffectiveDate),
                OnsetDate = MapDateProperties(warningProperties.OnsetDate),
                ExpiryDate = MapDateProperties(warningProperties.ExpiryDate),
                AlertStatus = warningProperties.AlertStatus,
                MessageType = warningProperties.MessageType,
                Category = warningProperties.Category,
                Severity = warningProperties.Severity,
                Certainty = warningProperties.Certainty,
                Urgency = warningProperties.Urgency,
                Event = warningProperties.Event,
                Headline = warningProperties.Headline,
                Description = warningProperties.Description,
                Instruction = warningProperties.Instruction,
                Response = warningProperties.Response,
            };

            return displayWarningProperties;
        }

        private WarningDate MapDateProperties(DateTimeOffset? dateTimeOffset)
        {
            var date = dateTimeOffset.GetValueOrDefault().DateTime;
            var warningDate = new WarningDate
            {
                Date = date,
                FormattedDate = date.ToFormattedDate()
            };

            return warningDate;
        }

        private DisplayProperties MapDisplayProperties(APIWeatherWarning apiWeatherWarning)
        {
            var fillColour = apiWeatherWarning.GetWarningColours();
            var displayProperties = new DisplayProperties()
            {
                FillColourHexCode = fillColour,
                LineColourHexCode = fillColour
            };

            return displayProperties;
        }
    }
}
