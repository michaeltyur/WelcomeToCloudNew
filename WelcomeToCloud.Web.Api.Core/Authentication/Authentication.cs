using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Web;
using System.Security.Principal;
using Microsoft.AspNetCore.Authorization;

namespace WelcomeToCloud.Web.Api.Core
{
    public static class Authentication
    {
        public static string GetUser(this ControllerBase controller)
        {

            return (controller.User == null || controller.User.Identity == null || controller.User.Identity.Name == null) ?
                null :
                controller.User.Identity.Name.Substring(controller.User.Identity.Name.LastIndexOf(@"\") + 1);
        }
        //[SupportedOSPlatform("windows")]
        public static void SetImpersonationContext(this ControllerBase controller)
        {
            //System.Web.HttpContext context = System.Web.HttpContext.Current;
            WindowsIdentity user = WindowsIdentity.GetCurrent();
            //user.I
            //((System.Security.Principal.WindowsIdentity)controller.User.Identity).Impersonate();
            // string curUser2 = context.User.Identity.Name.ToString();
            //System.Security.Principal.WindowsImpersonationContext impersonationContext = ((System.Security.Principal.WindowsIdentity)context.User.Identity).Impersonate();
        }
    }
}