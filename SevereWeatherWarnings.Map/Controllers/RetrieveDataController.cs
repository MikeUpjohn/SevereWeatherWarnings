using Microsoft.AspNetCore.Mvc;
using SevereWeatherWarnings.Library.UseCases.Warnings.Interfaces;
using SevereWeatherWarnings.Models;

namespace SevereWeatherWarnings.Map.Controllers
{
    public class RetrieveDataController : Controller
    {
        private readonly IGetWeatherWarnings _getWeatherWarnings;

        public RetrieveDataController(IGetWeatherWarnings getWeatherWarnings)
        {
            _getWeatherWarnings = getWeatherWarnings;
         }

        public async Task<JsonResult> GetData(RetrieveDataRequest request)
        {
            var warnings = await _getWeatherWarnings.GetActiveWeatherWarnings(request);
            return Json(warnings);
        }
    }
}
