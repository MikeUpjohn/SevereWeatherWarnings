namespace SevereWeatherWarnings.Library.Extensions
{
    public static class StringExtensions
    {
        public static string ToHtmlTrimmedString(this string rawData)
        {
            return !string.IsNullOrEmpty(rawData) ? rawData.Replace("\n", "<br />").Trim() : string.Empty;
        }
    }
}
