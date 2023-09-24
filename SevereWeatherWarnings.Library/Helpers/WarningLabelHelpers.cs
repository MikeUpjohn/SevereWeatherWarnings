using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using SevereWeatherWarnings.Library.Extensions;
using SevereWeatherWarnings.Models.Display.Common;

namespace SevereWeatherWarnings.Library.Helpers
{
    public static class WarningLabelHelpers
    {
        public static IHtmlContent WindThreatLabel(this IHtmlHelper htmlHelper, WindThreatParameter windThreatParameter)
        {
            var label = new TagBuilder("span");
            label.MergeAttribute("class", "standard-label");
            label.InnerHtml.SetContent(EnumExtensions.GetDescription(windThreatParameter.ParameterType));

            var value = new TagBuilder("span");
            value.MergeAttribute("class", $"standard-label-value {windThreatParameter.CssClass}");
            value.InnerHtml.SetContent(EnumExtensions.GetDescription(windThreatParameter.DisplayValue));

            var container = new TagBuilder("span");
            container.MergeAttribute("class", "container-label");
            container.InnerHtml.AppendHtml(label.GetString());
            container.InnerHtml.AppendHtml(value.GetString());

            return new HtmlString(container.GetString());
        }

        public static IHtmlContent MaxWindGustLabel(this IHtmlHelper htmlHelper, MaxWindGustParameter maxWindGustParameter)
        {
            var label = new TagBuilder("span");
            label.MergeAttribute("class", "standard-label");
            label.InnerHtml.SetContent(EnumExtensions.GetDescription(maxWindGustParameter.ParameterType));

            var value = new TagBuilder("span");
            value.MergeAttribute("class", $"standard-label-value {maxWindGustParameter.CssClass}");
            value.InnerHtml.SetContent(maxWindGustParameter.DisplayValue);

            var container = new TagBuilder("span");
            container.MergeAttribute("class", "container-label");
            container.InnerHtml.AppendHtml(label.GetString());
            container.InnerHtml.AppendHtml(value.GetString());

            return new HtmlString(container.GetString());
        }

        public static IHtmlContent HailThreatLabel(this IHtmlHelper htmlHelper, HailThreatParameter hailThreatParameter)
        {
            var label = new TagBuilder("span");
            label.MergeAttribute("class", "standard-label");
            label.InnerHtml.SetContent(EnumExtensions.GetDescription(hailThreatParameter.ParameterType));

            var value = new TagBuilder("span");
            value.MergeAttribute("class", $"standard-label-value {hailThreatParameter.CssClass}");
            value.InnerHtml.SetContent(EnumExtensions.GetDescription(hailThreatParameter.DisplayValue));

            var container = new TagBuilder("span");
            container.MergeAttribute("class", "container-label");
            container.InnerHtml.AppendHtml(label.GetString());
            container.InnerHtml.AppendHtml(value.GetString());

            return new HtmlString(container.GetString());
        }

        public static IHtmlContent ThunderstormDamageThreatLabel(this IHtmlHelper htmlHelper, ThunderstormDamageParameter thunderstormDamageParameter)
        {
            var label = new TagBuilder("span");
            label.MergeAttribute("class", "standard-label");
            label.InnerHtml.SetContent(EnumExtensions.GetDescription(thunderstormDamageParameter.ParameterType));

            var value = new TagBuilder("span");
            value.MergeAttribute("class", $"standard-label-value {thunderstormDamageParameter.CssClass}");
            value.InnerHtml.SetContent(EnumExtensions.GetDescription(thunderstormDamageParameter.DisplayValue));

            var container = new TagBuilder("span");
            container.MergeAttribute("class", "container-label");
            container.InnerHtml.AppendHtml(label.GetString());
            container.InnerHtml.AppendHtml(value.GetString());

            return new HtmlString(container.GetString());
        }
    }
}