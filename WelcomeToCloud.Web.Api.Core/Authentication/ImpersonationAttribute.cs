using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Principal;

namespace WelcomeToCloud.Web.Api.Core
{
    public class ImpersonationAttribute : ActionFilterAttribute
    {
        //public override async void OnActionExecuting(ActionExecutingContext context)
        //{
        //    var currentIdentity = (WindowsIdentity)context.HttpContext.User.Identity;
        //    // impersonate the current identity
        //    await WindowsIdentity.RunImpersonatedAsync(currentIdentity.AccessToken, () =>
        //    {
        //        base.OnActionExecuting(context);
        //        return Task.CompletedTask;
        //    });

            //WindowsIdentity.RunImpersonated(currentIdentity.AccessToken, () => base.OnActionExecuting(context));

            // store the impersonated identity in the request properties
            // actionContext.HttpContext.Items["ImpersonatedIdentity"] = impersonatedIdentity;

            // base.OnActionExecutionAsync(context, next);

        //}
        public override  async Task OnActionExecutionAsync(ActionExecutingContext context,ActionExecutionDelegate next)
        {
            var currentIdentity = (WindowsIdentity)context.HttpContext.User.Identity;
            await WindowsIdentity.RunImpersonatedAsync(currentIdentity.AccessToken, async () =>
            {
               await base.OnActionExecutionAsync(context, next);
               return Task.CompletedTask;
            }).ConfigureAwait(true);
        }
        //public override void OnActionExecuted(ActionExecutedContext context)
        //{
        //    // retrieve the impersonated identity from the request properties
        //    var impersonatedIdentity = context.HttpContext.Items["ImpersonatedIdentity"] as WindowsIdentity;

        //    // undo the impersonation
        //    impersonatedIdentity?.Dispose();

        //    base.OnActionExecuted(context);
        //}

    }
}