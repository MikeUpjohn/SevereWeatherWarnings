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

        public JsonResult GetData(RetrieveDataRequest request)
        {
            _getWeatherWarnings.GetActiveWeatherWarnings(request);
            return Json(new { });
        }
    }
}
