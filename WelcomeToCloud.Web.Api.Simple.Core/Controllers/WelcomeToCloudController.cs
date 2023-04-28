using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

namespace WelcomeToCloud.Web.Api.Simple.Core.Controllers
{
    [Route("welcome-to-cloud-simple")]
    [ApiController]
    public class WelcomeToCloudController : ControllerBase
    {
        public WelcomeToCloudController()
        {
        }

        [HttpGet("hello")]
        public string Hello()
        {
            string messsage = $"TimeStamp: {DateTime.Now}";
            return messsage;
        }

        [HttpGet("hello-delay/{delay}")]
        public string HelloWithDelay(int delay)
        {
            string messsage = $"Delay:{delay}. TimeStamp: {DateTime.Now}";
            Thread.Sleep(TimeSpan.FromSeconds(delay));
            return messsage;
        }

        [HttpGet("hello-auth")]
        public string HelloWithAuth(int delay)
        {
            string messsage = $"Identity.Name: {HttpContext.User.Identity.Name}. TimeStamp: {DateTime.Now}";
            return messsage;
        }
    }
}
