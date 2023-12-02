using Microsoft.AspNetCore.Mvc;
using SevereWeatherWarnings.Library.UseCases.Warnings.GetAllWeatherWarnings.Interfaces;
using SevereWeatherWarnings.Library.UseCases.Warnings.Interfaces;
using SevereWeatherWarnings.Map.Presenters.Interfaces;
using SevereWeatherWarnings.Models;

namespace SevereWeatherWarnings.Map.Controllers
{
    public class RetrieveDataController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IMapWarningDataPresenter _mapWarningDataPresenter;
        private readonly IWarnings _warnings;

        public RetrieveDataController(IConfiguration configuration, IMapWarningDataPresenter mapWarningDataPresenter, IWarnings warnings)
        {
            _configuration = configuration;
            _mapWarningDataPresenter = mapWarningDataPresenter;
            _warnings = warnings;
        }

        public async Task<JsonResult> GetAllLiveWarnings(RetrieveDataRequest request)
        {
            request.IsTestingMode = bool.Parse(_configuration["Settings:IsTestingMode"]);
            var allLiveWarnings = await _warnings.GetAllActiveWarnings(request);
            var mappedWarningData = _mapWarningDataPresenter.Present(allLiveWarnings);

            return Json(mappedWarningData);
        }
    }
}
