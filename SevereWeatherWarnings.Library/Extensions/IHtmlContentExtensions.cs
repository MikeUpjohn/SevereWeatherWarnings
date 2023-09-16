using Microsoft.AspNetCore.Html;
using System.Text.Encodings.Web;

namespace SevereWeatherWarnings.Library.Extensions
{
    public static class IHtmlContentExtensions
    {
        public static string GetString(this IHtmlContent htmlContent)
        {
            using(var writer = new StringWriter())
            {
                htmlContent.WriteTo(writer, HtmlEncoder.Default);
                return writer.ToString();
            }
        }
    }
}
