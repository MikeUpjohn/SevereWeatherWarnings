using SevereWeatherWarnings.Models.API;

namespace SevereWeatherWarnings.Library.Utilities.Interfaces
{
    public interface IWebServiceRetriever
    {
        Task<WeatherWarningsResponse> GetData(string url);
    }
}
