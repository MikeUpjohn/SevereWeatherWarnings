using SevereWeatherWarnings.Library.UseCases.Warnings.GetSingleWarning.Interfaces;
using SevereWeatherWarnings.Library.Utilities.Interfaces;
using SevereWeatherWarnings.Models;
using SevereWeatherWarnings.Models.API;

namespace SevereWeatherWarnings.Library.UseCases.Warnings.GetSingleWarning
{
    public class GetSingleWeatherWarning : IGetSingleWeatherWarning
    {
        private readonly IMapWarningDetail _mapWarningDetail;
        private readonly IWebServiceRetriever _webServiceRetriever;

        public GetSingleWeatherWarning(IMapWarningDetail mapWarningDetail, IWebServiceRetriever webServiceRetriever)
        {
            _mapWarningDetail = mapWarningDetail;
            _webServiceRetriever = webServiceRetriever;
        }

        public async Task<WeatherWarning> GetWeatherWarningDetail(RetrieveWarningRequest request)
        {
            var apiUrl = GenerateAPIUrl(request);
            var response = await _webServiceRetriever.GetData(apiUrl);
            var mappedResponse = _mapWarningDetail.Map(response);

            return mappedResponse;
        }

        private string GenerateAPIUrl(RetrieveWarningRequest request)
        {
            if(!request.IsInTestMode)
            {
                return "https://api.weather.gov/alerts/" + request.Id;
            }

            return $"https://severeweathermap.confessions-of-a-storm-geek.co.uk/sample-alerts/{request.Id}.json";
        }
    }
}
