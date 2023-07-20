using Microsoft.AspNetCore.Mvc;
using SevereWeatherWarnings.Library.UseCases.Warnings.Interfaces;

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
        {   
            ViewData["MapBoxConnectionString"] = _configuration["Settings:MapBoxToken"];
            ViewData["IsTestingMode"] = bool.Parse(_configuration["Settings:IsTestingMode"]);
            ViewData["MainClass"] = "warning-detail";

            return View();
        }
    }
}
