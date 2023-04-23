namespace SevereWeatherWarnings.Library.Extensions
{
    public static class DateTimeExtensions
    {
        public static string ToFormattedDate(this DateTime dateTime)
        {
            return dateTime.ToString("ddd, dd MMM yyyy HH:mm:ss");
        }
    }
}
