using Microsoft.AspNetCore.Mvc;
using SevereWeatherWarnings.Map.Models;
using System.Diagnostics;

namespace SevereWeatherWarnings.Map.Controllers
{
    public class SevereWeatherMapController : Controller
    {
        private readonly ILogger<SevereWeatherMapController> _logger;

        public SevereWeatherMapController(ILogger<SevereWeatherMapController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}