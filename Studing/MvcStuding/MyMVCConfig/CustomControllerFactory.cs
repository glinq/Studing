using MvcStuding.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

namespace MvcStuding.MyMVCConfig
{
    /// <summary>
    /// 自定义控制器生成
    /// </summary>
    public class CustomControllerFactory : IControllerFactory
    {

        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            Type targetType = null;
            switch (controllerName.ToLower())
            {
                case "home":
                    targetType = typeof(HomeController);
                    break;
                case "error":
                    targetType = typeof(ErrorController);
                    break;
                default:
                    requestContext.RouteData.Values["controller"] = "Error";
                    targetType = typeof(ErrorController);
                    break;
            }
            return targetType == null ? null : (IController)DependencyResolver.Current.GetService(targetType);
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Default;
        }

        public void ReleaseController(IController controller)
        {
            IDisposable disposable = controller as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }
    }
}