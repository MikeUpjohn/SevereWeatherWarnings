using Microsoft.AspNetCore.Mvc;

namespace SevereWeatherWarnings.Map.Controllers
{
    public class WarningController : Controller
    {
        private readonly IConfiguration _configuration;

        public WarningController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index(string id)
        {   
            ViewData["MapBoxConnectionString"] = _configuration["Settings:MapBoxToken"];
            ViewData["IsTestingMode"] = bool.Parse(_configuration["Settings:IsTestingMode"]);

            return View();
        }
    }
}
