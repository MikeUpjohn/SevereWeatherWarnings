using Microsoft.AspNetCore.Mvc;
using SevereWeatherWarnings.Library.UseCases.Warnings.Interfaces;
using SevereWeatherWarnings.Map.Presenters.Interfaces;
using SevereWeatherWarnings.Models;

namespace SevereWeatherWarnings.Map.Controllers
{
    public class WarningController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IWarnings _warnings;
        private readonly IMapWarningDetailPresenter _weatherWarningDetailPresenter;

        public WarningController(IConfiguration configuration, IWarnings warnings, IMapWarningDetailPresenter weatherWarningDetailPresenter)
        {
            _configuration = configuration;
            _warnings = warnings;
            _weatherWarningDetailPresenter = weatherWarningDetailPresenter;
        }

        public async Task<IActionResult> Index(string id)
        {   var isInTestingMode = bool.Parse(_configuration["Settings:IsTestingMode"]);

            ViewData["MapBoxConnectionString"] = _configuration["Settings:MapBoxToken"];
            ViewData["IsTestingMode"] = isInTestingMode;
            ViewData["MainClass"] = "warning-detail";

            var request = new RetrieveWarningRequest { IsInTestMode = isInTestingMode, Id = id };
            var result = await _warnings.GetWeatherWarningDetail(request);

            var viewModel = _weatherWarningDetailPresenter.Present(result);

            return View(viewModel);
        }
    }
}
