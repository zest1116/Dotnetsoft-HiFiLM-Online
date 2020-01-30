using System.Web;
using System.Web.Mvc;

namespace Dotnetsoft.HiFiLM.Management.Tool
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
