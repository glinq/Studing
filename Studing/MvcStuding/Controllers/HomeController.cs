using MvcStuding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcStuding.Controllers
{
    //[Filters_Linqian]
    public class HomeController : Controller
    {
        public ActionResult Index(string abc = "", int id = 0)
        {
            ViewBag.abc = abc;
            ViewData["id"] = id;
            if (!string.IsNullOrWhiteSpace(abc))
            {
                Response.Write("当请使用的事linqian路由配置<br/>");
            }
            else
            {
                Response.Write("当请使用的事default路由配置<br/>");
            }

            return View();
        }

        public ActionResult noauth()
        {
            return View();
        }

        public ActionResult GetProduct([ModelBinder(typeof(ProductModelBinder))]Product p)
        {
            return View(p);
        }
    }
}