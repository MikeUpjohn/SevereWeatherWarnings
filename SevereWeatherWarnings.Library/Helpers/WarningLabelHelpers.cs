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
    }
}