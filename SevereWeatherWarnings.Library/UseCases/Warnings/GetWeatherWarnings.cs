using SevereWeatherWarnings.Library.Extensions;
using SevereWeatherWarnings.Library.UseCases.Warnings.Interfaces;
using SevereWeatherWarnings.Library.Utilities.Interfaces;
using SevereWeatherWarnings.Models;
using SevereWeatherWarnings.Models.API;

namespace SevereWeatherWarnings.Library.UseCases.Warnings
{
    public class GetWeatherWarnings : IGetWeatherWarnings
    {
        private readonly IMapWarnings _mapWarnings;
        private readonly IWebServiceRetriever _webServiceRetriever;

        public GetWeatherWarnings(IMapWarnings mapWarnings, IWebServiceRetriever webServiceRetriever)
        {
            _mapWarnings = mapWarnings;
            _webServiceRetriever = webServiceRetriever;
        }

        public async Task<WeatherWarningsResponse> GetAllActiveWarnings(RetrieveDataRequest request)
        {
            var apiUrl = GenerateAPIUrl(request);
            var response = await _webServiceRetriever.GetData(apiUrl);
            var mappedResponse = _mapWarnings.Map(request, response);

            return mappedResponse;
        }

        private string GenerateAPIUrl(RetrieveDataRequest request)
        {
            if (!request.IsTestingMode)
            {
                var baseUrl = "https://api.weather.gov/alerts/active?";
                return baseUrl + "event=" + string.Join(",", request.Event.Select(s => EnumExtensions.GetDescription(s.Value)));
            }

            var testBaseUrl = $"https://severeweathermap.confessions-of-a-storm-geek.co.uk/sample-alerts/sample-alerts-";
            return testBaseUrl += request.Event.Count() == 1 ? $"{EnumExtensions.GetDescription(request.Event.FirstOrDefault())}.json" : "all.json";
        }
    }
}
