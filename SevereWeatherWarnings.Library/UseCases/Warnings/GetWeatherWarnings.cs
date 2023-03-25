using SevereWeatherWarnings.Library.Extensions;
using SevereWeatherWarnings.Library.UseCases.Warnings.Interfaces;
using SevereWeatherWarnings.Library.Utilities.Interfaces;
using SevereWeatherWarnings.Models;
using SevereWeatherWarnings.Models.API;

namespace SevereWeatherWarnings.Library.UseCases.Warnings
{
    public class GetWeatherWarnings : IGetWeatherWarnings
    {
        private readonly IWebServiceRetriever _webServiceRetriever;

        public GetWeatherWarnings(IWebServiceRetriever webServiceRetriever)
        {
            _webServiceRetriever = webServiceRetriever;
        }

        public async Task<WeatherWarningsResponse> GetActiveWeatherWarnings(RetrieveDataRequest request)
        {
            var apiUrl = GenerateAPIUrl(request);
            var response = await _webServiceRetriever.GetData(apiUrl);

            return response;
        }

        private string GenerateAPIUrl(RetrieveDataRequest request)
        {
            var baseUrl = "https://api.weather.gov/alerts/active?";
            return baseUrl + "event=" + EnumExtensions.GetDescription(request.Event);
        }
    }
}
