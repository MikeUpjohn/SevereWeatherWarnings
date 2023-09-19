using SevereWeatherWarnings.Library.Extensions;
using SevereWeatherWarnings.Map.Presenters.Interfaces;
using SevereWeatherWarnings.Models.Display;
using SevereWeatherWarnings.Models.Display.Common;
using APIWeatherWarning = SevereWeatherWarnings.Models.API.WeatherWarning;
using DisplayGeometry = SevereWeatherWarnings.Models.Display.Common.Geometry;
using DisplayWarningProperties = SevereWeatherWarnings.Models.Display.Common.WarningProperties;
using APIWarningParameters = SevereWeatherWarnings.Models.API.WarningParameters;
using DisplayWarningParameters = SevereWeatherWarnings.Models.Display.Common.WarningParameters;
using SevereWeatherWarnings.Models.Display.Enums;

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
                Id = warningProperties.Id,
                Type = warningProperties.Type,
                AreaDescription = warningProperties.AreaDescription,
                SentDate = MapDateProperties(warningProperties.SentDate),
                EffectiveDate = MapDateProperties(warningProperties.EffectiveDate),
                OnsetDate = MapDateProperties(warningProperties.OnsetDate),
                ExpiryDate = MapDateProperties(warningProperties.ExpiryDate),
                //End Date property needed here in future
                AlertStatus = warningProperties.AlertStatus,
                MessageType = warningProperties.MessageType,
                Category = warningProperties.Category,
                Severity = warningProperties.Severity,
                Certainty = warningProperties.Certainty,
                Urgency = warningProperties.Urgency,
                Event = warningProperties.Event,
                EventType = warningProperties.EventType.Value,
                SenderName = warningProperties.SenderName,
                Headline = warningProperties.Headline,
                Description = warningProperties.Description,
                Instruction = warningProperties.Instruction,
                Response = warningProperties.Response,
                Parameters = MapWarningParameters(warningProperties.Parameters)
            };

            return displayWarningProperties;
        }

        private DisplayWarningParameters MapWarningParameters(APIWarningParameters warningParameters)
        {
            DisplayWarningParameters displayWarningParameters = new DisplayWarningParameters();
            displayWarningParameters.WindThreat = warningParameters.WindThreat != null ? MapWindThreat(warningParameters.WindThreat) : null;
            displayWarningParameters.MaxWindGust = warningParameters.MaxWindGust != null ? MapMaxWindGust(warningParameters.MaxWindGust) : null;

            return displayWarningParameters;
        }

        private WindThreatParameter MapWindThreat(string[] windThreat)
        {
            var rawValue = windThreat;
            var displayValue = EnumExtensions.GetEnumValueFromDescription<WindThreat>(rawValue[0]);
            var cssClass = GetWindThreatCssClass(displayValue);

            return new WindThreatParameter
            {
                ParameterType = WarningParameterType.WindThreat,
                RawValue = rawValue,
                DisplayValue = displayValue,
                CssClass = cssClass
            };
        }

        private string GetWindThreatCssClass(WindThreat displayValue)
        {
            switch (displayValue)
            {
                case WindThreat.RadarIndicated:
                    return "wind-threat-1";
                case WindThreat.Observed:
                    return "wind-threat-2";
                default:
                    return string.Empty;
            }
        }

        private MaxWindGustParameter MapMaxWindGust(string[] maxWindGust)
        {
            var rawValue = maxWindGust;
            var displayValue = rawValue[0];
            int.TryParse(maxWindGust[0].Replace(" MPH", ""), out int maxWindGustValue);
            var cssClass = GetMaxWindGustCssClass(maxWindGustValue);

            return new MaxWindGustParameter
            {
                ParameterType = WarningParameterType.MaxWindGust,
                RawValue = rawValue,
                DisplayValue = displayValue,
                CssClass = cssClass
            };
        }

        private string GetMaxWindGustCssClass(int maxWindGust)
        {
            if (maxWindGust >= 50 && maxWindGust < 60) { return "max-wind-gust-1"; }
            if (maxWindGust >= 60 && maxWindGust < 70) { return "max-wind-gust-2"; }
            if (maxWindGust >= 70 && maxWindGust < 80) { return "max-wind-gust-3"; }
            if (maxWindGust >= 80 && maxWindGust < 90) { return "max-wind-gust-4"; }
            if (maxWindGust >= 90 && maxWindGust < 100) { return "max-wind-gust-5"; }
            if (maxWindGust >= 100 && maxWindGust < 110) { return "max-wind-gust-6"; }
            if (maxWindGust >= 110) { return "max-wind-gust-7"; }

            return "";
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
    }
}
