using System.Web;
using System.Web.Mvc;

namespace Tech_Career_School_MVC_web_api
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
