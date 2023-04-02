using Microsoft.AspNetCore.Mvc;
using SevereWeatherWarnings.Library.UseCases.Warnings.Interfaces;
using SevereWeatherWarnings.Models;

namespace SevereWeatherWarnings.Map.Controllers
{
    public class RetrieveDataController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IGetWeatherWarnings _getWeatherWarnings;

        public RetrieveDataController(IConfiguration configuration, IGetWeatherWarnings getWeatherWarnings)
        {
            _configuration = configuration;
            _getWeatherWarnings = getWeatherWarnings;
         }

        public async Task<JsonResult> GetData(RetrieveDataRequest request)
        {
            request.IsTestingMode = bool.Parse(_configuration["Settings:IsTestingMode"]);
            var warnings = await _getWeatherWarnings.GetActiveWeatherWarnings(request);
            return Json(warnings);
        }
    }
}
