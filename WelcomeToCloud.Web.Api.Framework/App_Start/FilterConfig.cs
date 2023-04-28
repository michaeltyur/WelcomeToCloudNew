using System.Web;
using System.Web.Mvc;

namespace WelcomeToCloud.Web.Api.Framework
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
