using SevereWeatherWarnings.Library.UseCases.Warnings.GetAllWeatherWarnings.Interfaces;
using SevereWeatherWarnings.Library.UseCases.Warnings.GetSingleWarning.Interfaces;
using SevereWeatherWarnings.Library.UseCases.Warnings.Interfaces;
using SevereWeatherWarnings.Models;
using SevereWeatherWarnings.Models.API;

namespace SevereWeatherWarnings.Library.UseCases.Warnings
{
    public class Warnings : IWarnings
    {
        private IGetSingleWeatherWarning _getSingleWeatherWarning;
        private IGetWeatherWarnings _getWeatherWarnings;

        public Warnings(IGetSingleWeatherWarning getSingleWeatherWarnings
            , IGetWeatherWarnings getWeatherWarnings)
        {
            _getSingleWeatherWarning = getSingleWeatherWarnings;
            _getWeatherWarnings = getWeatherWarnings;
        }

        public Task<WeatherWarningsResponse> GetAllActiveWarnings(RetrieveDataRequest request)
            => _getWeatherWarnings.GetAllActiveWarnings(request);

        public Task<WeatherWarning> GetWeatherWarningDetail(RetrieveWarningRequest request)
            => _getSingleWeatherWarning.GetWeatherWarningDetail(request);
    }
}
