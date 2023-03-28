using SevereWeatherWarnings.Library.Utilities.Interfaces;
using System.Net.Http.Headers;

namespace SevereWeatherWarnings.Library.Utilities
{
    public class WebServiceRetriever : IWebServiceRetriever
    {
        public async Task<string> GetData(string url)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(url),
                Method = HttpMethod.Get
            };

            request.Headers.UserAgent.Add(new ProductInfoHeaderValue("www.confessions-of-a-storm-geek.co.uk", "hello-at-mike-upjohn.co.uk"));

            string jsonObject = "";
            return await client.SendAsync(request)
                .ContinueWith((result) =>
                {
                    var response = result.Result;
                    var jsonResult = response.Content.ReadAsStringAsync();
                    jsonResult.Wait();

                    return jsonResult.Result;
                });
        }
    }
}
