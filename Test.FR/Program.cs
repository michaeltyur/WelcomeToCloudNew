using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Test.FR
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage();
            request.RequestUri = new Uri("https://api.api-ninjas.com/v1/facts?limit=1");
            request.Method = HttpMethod.Get;
            request.Headers.Add("X-Api-Key", "CGgSQ8XfPI+KXqooLgN/tw==oeaU0gIHca3UeD57");
            HttpResponseMessage response = httpClient.SendAsync(request).GetAwaiter().GetResult();
            var responseString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var statusCode = response.StatusCode;
        }
    }
}
