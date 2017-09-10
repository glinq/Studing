using System.Web;
using System.Web.Mvc;

namespace MvcStuding
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //是否对所有请求做权限过滤
            //filters.Add(new Filters_Linqian());
        }
    }
}
