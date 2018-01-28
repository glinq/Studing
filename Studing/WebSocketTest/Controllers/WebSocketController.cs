using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebSocketSimpleService;

namespace WebSocketTest.Controllers
{
    public class WebSocketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ContentResult GetAllUserInfo()
        {
            return Content(Newtonsoft.Json.JsonConvert.SerializeObject(MyWebSocketService.ConnectPool));
        }
        [HttpGet]
        public ContentResult MessageInfo()
        {
            return Content(Newtonsoft.Json.JsonConvert.SerializeObject(MyWebSocketService.MessagePool));
        }

        public static string GetNow()
        {
            return DateTime.Now.ToString("HH:mm:ss");
        }
    }
}