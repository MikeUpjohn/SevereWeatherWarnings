using Microsoft.AspNetCore.Mvc;
using SevereWeatherWarnings.Map.Models;
using System.Diagnostics;

namespace SevereWeatherWarnings.Map.Controllers
{
    public class SevereWeatherMapController : Controller
    {
        private readonly ILogger<SevereWeatherMapController> _logger;
        private readonly IConfiguration _configuration;

        public SevereWeatherMapController(ILogger<SevereWeatherMapController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            var isWarningDetailPageOn = bool.Parse(_configuration["FeatureToggles:WarningDetailsPage"]);
            ViewData["MapBoxConnectionString"] = _configuration["Settings:MapBoxToken"];
            ViewData["IsTestingMode"] = bool.Parse(_configuration["Settings:IsTestingMode"]);
            ViewData["MainClass"] = "main-map";
            ViewData["IsWarningDetailPageOn"] = isWarningDetailPageOn;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}