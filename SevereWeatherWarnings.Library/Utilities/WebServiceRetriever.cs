using SevereWeatherWarnings.Library.Utilities.Interfaces;
using SevereWeatherWarnings.Models.API;
using System.Net;
using System.Net.Http.Headers;

namespace SevereWeatherWarnings.Library.Utilities
{
    public class WebServiceRetriever : IWebServiceRetriever
    {
        public async Task<WeatherWarningsResponse> GetData(string url)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("confessions-of-a-storm-geek.co.uk", "michael.upjohn@hotmail.co.uk"));
            HttpResponseMessage result = await client.GetAsync(url);

            if(result.IsSuccessStatusCode)
            {
                var response = result.Content.ReadAsStringAsync();
            }

            return new WeatherWarningsResponse();
        }
    }
}
