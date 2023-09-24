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
            displayWarningParameters.HailThreat = warningParameters.HailThreat != null ? MapHailThreat(warningParameters.HailThreat) : null;
            displayWarningParameters.ThunderstormDamage = warningParameters.ThunderstormDamage != null ? MapThunderstormDamage(warningParameters.ThunderstormDamage) : null;

            return displayWarningParameters;
        }

        #region WindThreat
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
        #endregion

        #region MaxWindGust
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
        #endregion

        #region HailThreat

        public HailThreatParameter MapHailThreat(string[] hailThreat)
        {
            var rawValue = hailThreat;
            var displayValue = EnumExtensions.GetEnumValueFromDescription<HailThreat>(rawValue[0]);
            var cssClass = GetHailThreatCssClass(displayValue);

            return new HailThreatParameter
            {
                ParameterType = WarningParameterType.HailThreat,
                RawValue = rawValue,
                DisplayValue = displayValue,
                CssClass = cssClass,
            };
        }

        public string GetHailThreatCssClass(HailThreat hailThreat)
        {
            switch (hailThreat)
            {
                case HailThreat.RadarIndicated:
                    return "hail-threat-1";
                case HailThreat.Observed:
                    return "hail-threat-2";
                default:
                    return string.Empty;
            }
        }

        #endregion

        #region Thunderstorm Damage

        public ThunderstormDamageParameter MapThunderstormDamage(string[] thunderstormDamage)
        {
            var rawValue = thunderstormDamage;
            var displayValue = EnumExtensions.GetEnumValueFromDescription<ThunderstormDamage>(rawValue[0]);
            var cssClass = GetThunderstormDamageCssClass(displayValue);

            return new ThunderstormDamageParameter
            {
                ParameterType = WarningParameterType.ThunderstormDamage,
                RawValue = rawValue,
                DisplayValue = displayValue,
                CssClass = cssClass
            };
        }

        private string GetThunderstormDamageCssClass(ThunderstormDamage thunderstormDamage)
        {
            switch(thunderstormDamage)
            {
                case ThunderstormDamage.Considerable:
                    return "thunderstorm-damage-1";
                case ThunderstormDamage.Destructive:
                    return "thunderstorm-damage-2";
                default:
                    return "";
            }
        }

        #endregion

        #region Helpers
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
        #endregion
    }
}
