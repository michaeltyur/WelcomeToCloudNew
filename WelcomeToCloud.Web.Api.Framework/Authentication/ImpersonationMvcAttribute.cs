using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web.Mvc;
using ActionExecutingContext = System.Web.Mvc.ActionExecutingContext;

namespace WelcomeToCloud.Web.Api.Framework
{
    public class ImpersonationMvcAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var currentIdentity = (WindowsIdentity)context.HttpContext.User.Identity;
            // impersonate the current identity
            //await WindowsIdentity.RunImpersonatedAsync(currentIdentity.AccessToken, () =>
            //{
            //    base.OnActionExecuting(context);
            //    return Task.CompletedTask;
            //});
            currentIdentity.Impersonate();
            //WindowsIdentity.RunImpersonated(currentIdentity.AccessToken, () => base.OnActionExecuting(context));

         //   store the impersonated identity in the request properties
         //actionContext.HttpContext.Items["ImpersonatedIdentity"] = impersonatedIdentity;

         //   base.OnActionExecutionAsync(context, next);

        }
        //public override async Task OnActionExecutionAsync(Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext context, ActionExecutionDelegate next)
        //{
        //    var currentIdentity = (WindowsIdentity)context.HttpContext.User.Identity;
        //    await WindowsIdentity.RunImpersonatedAsync(currentIdentity.AccessToken, async () =>
        //    {
        //        await base.OnActionExecutionAsync(context, next);
        //        return Task.CompletedTask;
        //    });
        //}
    }

}