using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcStuding
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //自定义路由参数
            routes.MapRoute(
                name: "linqian",
                url: "linqian/{controller}/{action}/{id}/{abc}",
                constraints: new//参数值的规则
                {
                    id = "\\d+",//必须是数字
                    abc = "\\w{10}",//有10位字符
                    HttpMethod = new HttpMethodConstraint("GET")//以GET方式请求
                },
                defaults: new { controller = "HOME", Action = "INDEX" },
                namespaces: new string[] { "MvcStuding" }
                );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
