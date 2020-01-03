using System.Web;
using System.Web.Mvc;

namespace Web_NoiThat
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //GlobalFilters.Filters.Add(new AuthorizeAttribute() { Roles = "Admin, User" });
        }
    }
}
