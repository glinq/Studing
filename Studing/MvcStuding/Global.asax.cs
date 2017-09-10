using MvcStuding.Models;
using MvcStuding.MyMVCConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MvcStuding
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //路由控制
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //控制器控制
            ControllerBuilder.Current.SetControllerFactory(new CustomControllerFactory());
            //Model控制
            ModelBinders.Binders.Add(typeof(Product), new ProductModelBinder());
            ModelBinders.Binders.Add(typeof(decimal), new DecimalModelBinder());
        }
    }
}
