using Microsoft.AspNetCore.Mvc;
using SevereWeatherWarnings.Library.UseCases.Warnings.Interfaces;
using SevereWeatherWarnings.Map.Presenters.Interfaces;
using SevereWeatherWarnings.Models;

namespace SevereWeatherWarnings.Map.Controllers
{
    public class RetrieveDataController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IGetWeatherWarnings _getWeatherWarnings;
        private readonly IMapWarningDataPresenter _mapWarningDataPresenter;

        public RetrieveDataController(IConfiguration configuration, IGetWeatherWarnings getWeatherWarnings, IMapWarningDataPresenter mapWarningDataPresenter)
        {
            _configuration = configuration;
            _getWeatherWarnings = getWeatherWarnings;
            _mapWarningDataPresenter = mapWarningDataPresenter;
        }

        public async Task<JsonResult> GetAllLiveWarnings(RetrieveDataRequest request)
        {
            request.IsTestingMode = bool.Parse(_configuration["Settings:IsTestingMode"]);
            var allLiveWarnings = await _getWeatherWarnings.GetAllActiveWarnings(request);
            var mappedWarningData = _mapWarningDataPresenter.Present(allLiveWarnings);

            return Json(mappedWarningData);
        }
    }
}
