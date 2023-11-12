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
using SevereWeatherWarnings.Models.Enums;

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
                Parameters = MapWarningParameters(warningProperties.Parameters, warningProperties.EventType.Value)
            };

            return displayWarningProperties;
        }

        private DisplayWarningParameters MapWarningParameters(APIWarningParameters warningParameters, Event eventType)
        {
            DisplayWarningParameters displayWarningParameters = new DisplayWarningParameters();
            displayWarningParameters.WindThreat = warningParameters.WindThreat != null ? MapWindThreat(warningParameters.WindThreat) : null;
            displayWarningParameters.MaxWindGust = warningParameters.MaxWindGust != null ? MapMaxWindGust(warningParameters.MaxWindGust) : null;
            displayWarningParameters.HailThreat = warningParameters.HailThreat != null ? MapHailThreat(warningParameters.HailThreat) : null;
            displayWarningParameters.ThunderstormDamage = warningParameters.ThunderstormDamage != null ? MapThunderstormDamage(warningParameters.ThunderstormDamage) : null;
            displayWarningParameters.MaxHailSize = warningParameters.MaxHailSize != null ? MapMaxHailSize(warningParameters.MaxHailSize) : null;
            displayWarningParameters.TornadoDetection = warningParameters.TornadoDetection != null ? MapTornadoDetection(warningParameters.TornadoDetection, eventType) : null;
            displayWarningParameters.TornadoDamageThreat = warningParameters.TornadoDamageThreat != null ? MapTornadoDamageThreat(warningParameters.TornadoDamageThreat) : null;
            displayWarningParameters.FlashFloodDetection = warningParameters.FlashFloodDetection != null ? MapFlashFloodDetection(warningParameters.FlashFloodDetection) : null;
            displayWarningParameters.FlashFloodDamageThreat = warningParameters.FlashFloodDamageThreat != null ? MapFlashFloodDamageThreat(warningParameters.FlashFloodDamageThreat) : null;

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
            switch (thunderstormDamage)
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

        #region MaxHailSize

        private static MaxHailSizeParameter MapMaxHailSize(string[] maxHailSize)
        {
            var rawValue = maxHailSize;
            var displayValue = rawValue[0];
            double.TryParse(maxHailSize[0].Replace("Up to ", ""), out double maxHailSizeValue);
            var cssClass = GetMaxHailSizeCssClass(maxHailSizeValue);

            return new MaxHailSizeParameter
            {
                ParameterType = WarningParameterType.MaxHailSize,
                RawValue = rawValue,
                DisplayValue = displayValue,
                CssClass = cssClass
            };
        }

        private static string GetMaxHailSizeCssClass(double maxHailSizeValue)
        {
            if (maxHailSizeValue > 0 && maxHailSizeValue <= 0.5) { return "max-hail-size-1"; }
            if (maxHailSizeValue > 0.5 && maxHailSizeValue <= 1) { return "max-hail-size-2"; }
            if (maxHailSizeValue > 1 && maxHailSizeValue <= 1.75) { return "max-hail-size-3"; }
            if (maxHailSizeValue > 1.75 && maxHailSizeValue <= 2.25) { return "max-hail-size-4"; }
            if (maxHailSizeValue > 2.25 && maxHailSizeValue <= 2.75) { return "max-hail-size-5"; }
            if (maxHailSizeValue > 2.75 && maxHailSizeValue <= 3.5) { return "max-hail-size-6"; }
            if (maxHailSizeValue > 3.5 && maxHailSizeValue <= 4.5) { return "max-hail-size-7"; }
            if (maxHailSizeValue > 4.5) { return "max-hail-size-8"; }

            return "";
        }

        #endregion

        #region Tornado Detection

        public TornadoDetectionParameter MapTornadoDetection(string[] tornadoDetection, Event eventType)
        {
            var rawValue = tornadoDetection;
            var displayValue = EnumExtensions.GetEnumValueFromDescription<TornadoDetection>(rawValue[0]);
            var cssClass = GetTornadoDetectionCssClass(displayValue, eventType);

            return new TornadoDetectionParameter
            {
                ParameterType = WarningParameterType.TornadoDetection,
                RawValue = rawValue,
                DisplayValue = displayValue,
                CssClass = cssClass
            };
        }

        private static string GetTornadoDetectionCssClass(TornadoDetection tornadoDetection, Event eventType)
        {
            if (eventType == Event.SevereThunderstormWarning) { return "tornado-detection-3"; }

            switch (tornadoDetection)
            {
                case TornadoDetection.RadarIndicated:
                    return "tornado-detection-1";
                case TornadoDetection.Observed:
                    return "tornado-detection-2";
                default:
                    return "";
            }
        }

        #endregion

        #region Tornado Damage Threat

        public TornadoDamageThreatParameter MapTornadoDamageThreat(string[] tornadoDamageThreat)
        {
            var rawValue = tornadoDamageThreat;
            var displayValue = EnumExtensions.GetEnumValueFromDescription<TornadoDamageThreat>(rawValue[0]);
            var cssClass = GetTornadoDamageThreatCssClass(displayValue);

            return new TornadoDamageThreatParameter
            {
                ParameterType = WarningParameterType.TornadoDamageThreat,
                RawValue = rawValue,
                DisplayValue = displayValue,
                CssClass = cssClass
            };
        }

        private string GetTornadoDamageThreatCssClass(TornadoDamageThreat displayValue)
        {
            switch (displayValue)
            {
                case TornadoDamageThreat.Considerable:
                    return "tornado-damage-threat-1";
                case TornadoDamageThreat.Catastrophic:
                    return "tornado-damage-threat-2";
                default:
                    return "";
            }
        }

        #endregion

        #region Flash Flood Detection
        public FlashFloodDetectionParameter MapFlashFloodDetection(string[] flashFloodDetection)
        {
            var rawValue = flashFloodDetection;
            var displayValue = EnumExtensions.GetEnumValueFromDescription<FlashFloodDetection>(rawValue[0]);
            var cssClass = GetFlashFloodDetectionCssClass(displayValue);

            return new FlashFloodDetectionParameter
            {
                ParameterType = WarningParameterType.FlashFloodDetection,
                RawValue = rawValue,
                DisplayValue = displayValue,
                CssClass = cssClass
            };
        }

        private string GetFlashFloodDetectionCssClass(FlashFloodDetection displayValue)
        {
            switch (displayValue)
            {
                case FlashFloodDetection.RadarIndicated:
                    return "flash-flood-detection-1";
                case FlashFloodDetection.RadarAndGaugeIndicated:
                    return "flash-flood-detection-2";
                case FlashFloodDetection.Observed:
                    return "flash-flood-detection-3";
                default:
                    return "";
            }
        }

        #endregion

        #region Flash Flood Damage Threat

        public FlashFloodDamageThreatParameter MapFlashFloodDamageThreat(string[] flashFloodDamageThreat)
        {
            var rawValue = flashFloodDamageThreat;
            var displayValue = EnumExtensions.GetEnumValueFromDescription<FlashFloodDamageThreat>(rawValue[0]);
            var cssClass = GetFlashFloodDamageThreatCssClass(displayValue);

            return new FlashFloodDamageThreatParameter
            {
                ParameterType = WarningParameterType.FlashFloodDamageThreat,
                RawValue = rawValue,
                DisplayValue = displayValue,
                CssClass = cssClass
            };
        }

        private string GetFlashFloodDamageThreatCssClass(FlashFloodDamageThreat displayValue)
        {
            switch (displayValue)
            {
                case FlashFloodDamageThreat.Considerable:
                    return "flash-flood-damage-threat-1";
                case FlashFloodDamageThreat.Catastrophic:
                    return "flash-flood-damage-threat-2";
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
