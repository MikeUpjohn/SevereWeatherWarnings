using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using SevereWeatherWarnings.Library.Extensions;
using SevereWeatherWarnings.Models.Display.Common;
using SevereWeatherWarnings.Models.Display.Enums;

namespace SevereWeatherWarnings.Library.Helpers
{
    public static class WarningLabelHelpers
    {
        public static IHtmlContent WindThreatLabel(this IHtmlHelper htmlHelper, WindThreatParameter windThreatParameter)
        {
            return SevereWeatherLabel(htmlHelper, windThreatParameter.ParameterType, windThreatParameter.DisplayValue, windThreatParameter.CssClass);
        }

        public static IHtmlContent MaxWindGustLabel(this IHtmlHelper htmlHelper, MaxWindGustParameter maxWindGustParameter)
        {
            return SevereWeatherLabel(htmlHelper, maxWindGustParameter.ParameterType, maxWindGustParameter.DisplayValue, maxWindGustParameter.CssClass);
        }

        public static IHtmlContent HailThreatLabel(this IHtmlHelper htmlHelper, HailThreatParameter hailThreatParameter)
        {
            return SevereWeatherLabel(htmlHelper, hailThreatParameter.ParameterType, hailThreatParameter.DisplayValue, hailThreatParameter.CssClass);
        }

        public static IHtmlContent ThunderstormDamageThreatLabel(this IHtmlHelper htmlHelper, ThunderstormDamageParameter thunderstormDamageParameter)
        {
            return SevereWeatherLabel(htmlHelper, thunderstormDamageParameter.ParameterType, thunderstormDamageParameter.DisplayValue, thunderstormDamageParameter.CssClass);
        }

        public static IHtmlContent MaxHailSizeLabel(this IHtmlHelper htmlHelper, MaxHailSizeParameter maxHailSizeParameter)
        {
            return SevereWeatherLabel(htmlHelper, maxHailSizeParameter.ParameterType, maxHailSizeParameter.DisplayValue, maxHailSizeParameter.CssClass);
        }

        public static IHtmlContent TornadoDetectionLabel(this IHtmlHelper htmlHelper, TornadoDetectionParameter tornadoDetectionParameter)
        {
            return SevereWeatherLabel(htmlHelper, tornadoDetectionParameter.ParameterType, tornadoDetectionParameter.DisplayValue, tornadoDetectionParameter.CssClass);
        }

        private static IHtmlContent SevereWeatherLabel(this IHtmlHelper htmlHelper, WarningParameterType warningParameterType, Enum displayValue, string cssClass)
        {
            var label = new TagBuilder("span");
            label.MergeAttribute("class", "standard-label");
            label.InnerHtml.SetContent(EnumExtensions.GetDescription(warningParameterType));

            var value = new TagBuilder("span");
            value.MergeAttribute("class", $"standard-label-value {cssClass}");
            value.InnerHtml.SetContent(EnumExtensions.GetDescription(displayValue));

            var container = new TagBuilder("span");
            container.MergeAttribute("class", "container-label");
            container.InnerHtml.AppendHtml(label.GetString());
            container.InnerHtml.AppendHtml(value.GetString());

            return new HtmlString(container.GetString());
        }

        private static IHtmlContent SevereWeatherLabel(this IHtmlHelper htmlHelper, WarningParameterType warningParameterType, string displayValue, string cssClass)
        {
            var label = new TagBuilder("span");
            label.MergeAttribute("class", "standard-label");
            label.InnerHtml.SetContent(EnumExtensions.GetDescription(warningParameterType));

            var value = new TagBuilder("span");
            value.MergeAttribute("class", $"standard-label-value {cssClass}");
            value.InnerHtml.SetContent(displayValue);

            var container = new TagBuilder("span");
            container.MergeAttribute("class", "container-label");
            container.InnerHtml.AppendHtml(label.GetString());
            container.InnerHtml.AppendHtml(value.GetString());

            return new HtmlString(container.GetString());
        }
    }
}