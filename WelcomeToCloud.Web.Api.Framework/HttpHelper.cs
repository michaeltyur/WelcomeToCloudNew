using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace WelcomeToCloud.Web.Api.Framework
{
    public class HttpHelper :IDisposable
    {
        //private HttpClient _httpClient;
        public HttpHelper()
        {
           // _httpClient = new HttpClient();
        }

        public void Dispose()
        {
            //_httpClient?.Dispose();
        }

        public string GetFactFromApiNinjas()
        {
            HttpClient httpClient = new HttpClient(); ;
            HttpRequestMessage request = new HttpRequestMessage();
            request.RequestUri = new Uri("https://api.api-ninjas.com/v1/facts?limit=1");
            request.Method = HttpMethod.Get;
            request.Headers.Add("X-Api-Key", "CGgSQ8XfPI+KXqooLgN/tw==oeaU0gIHca3UeD57");
            HttpResponseMessage response = httpClient.SendAsync(request).ConfigureAwait(false).GetAwaiter().GetResult();
            var responseString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            //var statusCode = response.StatusCode;
            ApiNinjasResponseEntity[] entities = JsonConvert.DeserializeObject<ApiNinjasResponseEntity[]>(responseString);
            return entities.FirstOrDefault().Fact;
        }
        public string GetCelebrityFromApiNinjas(string name)
        {
            HttpClient httpClient = new HttpClient(); ;
            HttpRequestMessage request = new HttpRequestMessage();
            request.RequestUri = new Uri("https://api.api-ninjas.com/v1/celebrity?name="+ name);
            request.Method = HttpMethod.Get;
            request.Headers.Add("X-Api-Key", "CGgSQ8XfPI+KXqooLgN/tw==oeaU0gIHca3UeD57");
            HttpResponseMessage response = httpClient.SendAsync(request).ConfigureAwait(false).GetAwaiter().GetResult();
            var responseString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            return responseString;
            //var statusCode = response.StatusCode;
            //ApiNinjasResponseEntity[] entities = JsonConvert.DeserializeObject<ApiNinjasResponseEntity[]>(responseString);
            //return entities.FirstOrDefault().Fact;
        }
        public static string GetImpersonatedUser()
        {
            string url = "http://bamadevws126/welcome_to_cloud_core/welcome-to-cloud/hello";
            //string url = "http://bamadevwscore01/WelcomeToCloud.Core/welcome-to-cloud/hello";
            HttpClient httpClient = new HttpClient(new HttpClientHandler() { UseDefaultCredentials = true });
            HttpRequestMessage request = new HttpRequestMessage();
            request.RequestUri = new Uri(url);
            request.Method = HttpMethod.Get;
            var response = httpClient.GetStringAsync(url).ConfigureAwait(false).GetAwaiter().GetResult();
            return response;
        }
    }
}