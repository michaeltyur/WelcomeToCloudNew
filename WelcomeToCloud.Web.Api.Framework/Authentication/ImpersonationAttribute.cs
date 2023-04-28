using System.Web.Http.Controllers;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Security.Principal;

namespace WelcomeToCloud.Web.Api.Framework
{
    public class ImpersonationAttribute : ActionFilterAttribute
    {
        private static string IMPERSONATION_CONTEXT_NAME = "ImpersonationContext";
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var controller = actionContext.ControllerContext.Controller as ApiController;
            WindowsImpersonationContext impersonationContext = ((System.Security.Principal.WindowsIdentity)controller.User.Identity).Impersonate();
            actionContext.ActionArguments.Add(IMPERSONATION_CONTEXT_NAME, impersonationContext);
        }
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            //if (actionExecutedContext.ActionContext.ActionArguments.TryGetValue(IMPERSONATION_CONTEXT_NAME, out object result))
            //{
            //    WindowsImpersonationContext impersonationContext = (WindowsImpersonationContext)result;
            //    impersonationContext?.Undo();
            //    impersonationContext?.Dispose();
            //}
        }

    }
}