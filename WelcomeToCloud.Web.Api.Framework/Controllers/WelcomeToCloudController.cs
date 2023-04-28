using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Web.Http;
//using System.Web.Mvc;
using WelcomeToCloud.Web.Api.Framework.Models;

namespace WelcomeToCloud.Web.Api.Framework
{
    //[Route("welcome-to-cloud")]
    public class WelcomeToCloudController : ApiController
    {
        DataHelper _dataHelper;
        public WelcomeToCloudController()
        {
            _dataHelper = new DataHelper();
        }

        [Route("welcome-to-cloud/hello")]
        [Impersonation]
        [HttpGet]
        public string Hello()
        {
            string result = $"{WindowsIdentity.GetCurrent().Name}. TimeStamp: {DateTime.Now}";
            return result;
        }

        [Route("welcome-to-cloud/get-data")]
        [Impersonation]
        [HttpPost]
        public ResponseEntity GetData(RequestEntity data)
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
            if (string.IsNullOrEmpty(responseEntity.Data))
            {
                responseEntity.Data = _dataHelper.GetRandomFact();
                responseEntity.MetaData += " From Local Data";
            }
            return responseEntity;
        }

    }
}
