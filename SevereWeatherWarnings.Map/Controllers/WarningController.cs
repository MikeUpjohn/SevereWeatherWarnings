using Microsoft.AspNetCore.Mvc;
using SevereWeatherWarnings.Library.UseCases.Warnings.Interfaces;
using SevereWeatherWarnings.Models;

namespace SevereWeatherWarnings.Map.Controllers
{
    public class WarningController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IWarnings _warnings;

        public WarningController(IConfiguration configuration, IWarnings warnings)
        {
            _configuration = configuration;
            _warnings = warnings;
        }

        public IActionResult Index(string id)
        {   var isInTestingMode = bool.Parse(_configuration["Settings:IsTestingMode"]);

            ViewData["MapBoxConnectionString"] = _configuration["Settings:MapBoxToken"];
            ViewData["IsTestingMode"] = isInTestingMode;
            ViewData["MainClass"] = "warning-detail";

            var request = new RetrieveWarningRequest { IsInTestMode = isInTestingMode, Id = id };
            var result = _warnings.GetWeatherWarningDetail(request);

            return View();
        }
    }
}
