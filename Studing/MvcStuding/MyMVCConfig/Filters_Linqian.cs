using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcStuding
{
    /// <summary>
    /// 针对方法或controller作权限过滤    
    /// IAuthorizationFilter  授权筛选器   
    /// IExceptionFilter   异常筛选器
    /// IResultFilter：结果筛选器
    /// IActionFilter:操作筛选器中
    /// </summary>
    public class Filters_Linqian : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request["abc"] != "0123456789")
            {
                filterContext.HttpContext.Response.Redirect("/error/index");
                // filterContext.HttpContext.Response.RedirectToRoute("Default");
            }
        }
    }
    /// <summary>
    /// 异常处理
    /// </summary>
    public class MyErrorFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            filterContext.Result = new ViewResult()
            {
                ViewName = "Error",
                ViewData = new ViewDataDictionary<string>(filterContext.Exception.StackTrace)
            };
            filterContext.ExceptionHandled = true;
            return;
        }
    }


}