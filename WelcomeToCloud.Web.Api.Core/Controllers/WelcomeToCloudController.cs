using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;
using static System.Net.Mime.MediaTypeNames;

namespace WelcomeToCloud.Web.Api.Core.Controllers
{
    [Route("welcome-to-cloud")]
    [ApiController]
    public class WelcomeToCloudController : ControllerBase
    {
        DataHelper _dataHelper;
        public WelcomeToCloudController()
        {
            _dataHelper = new DataHelper();
        }

        [HttpGet("hello")]
        //[Impersonation]
        public string Hello()
        {
            try
            {
                //Environment.UserName
               // return $"Hello  TimeStamp: {DateTime.Now}";
                //string messsage = $"{WindowsIdentity.GetCurrent().Name}. TimeStamp: {DateTime.Now}";
                string  messsage = $"{Environment.UserName}. TimeStamp: {DateTime.Now}";
                return messsage;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.ToString());
                throw;
            }
        }

        [HttpPost("get-data")]
        [Impersonation]
        public ResponseEntity GetData(RequestEntity data)
        {
            //ResponseEntity result = null;
            //var currentIdentity = (WindowsIdentity)HttpContext.User.Identity;
            //WindowsIdentity.RunImpersonatedAsync(currentIdentity.AccessToken, () =>
            //{
            //    result = ProcessGetData(data);
            //    return Task.CompletedTask;
            //});
            try
            {
                return ProcessGetData(data);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.ToString());
                throw;
            }
        }
        private ResponseEntity ProcessGetData(RequestEntity data)
        {
            ResponseEntity responseEntity = new ResponseEntity();
            responseEntity.MetaData = $"Received from client: {data.Data}";
            responseEntity.CurrentUser = User.Identity.Name;
            try
            {
               // responseEntity.ImpersonatedUser = HttpHelper.GetImpersonatedUser();
            }
            catch (Exception ex)
            {
                responseEntity.ImpersonatedUser = $"Error: {ex.Message}";
            }
            //
            if (string.IsNullOrEmpty(responseEntity.Data))
            {
                responseEntity.Data = _dataHelper.GetRandomFact();
                responseEntity.MetaData += " From Local Data";
            }
            return responseEntity;
        }
    }

}
