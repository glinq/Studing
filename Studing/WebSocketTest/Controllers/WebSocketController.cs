using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
        public IActionResult PoolingTest()
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
        [HttpGet]
        public ContentResult GetSelectUser()
        {
            string employee = "[{\"EmpCode\":\"11807\",\"EmpName\":\"陈志寅\"},{\"EmpCode\":\"02754\",\"EmpName\":\"孙黎\"}," +
                "{\"EmpCode\":\"00281\",\"EmpName\":\"阮文超\"},{\"EmpCode\":\"10552\",\"EmpName\":\"邱吉良\"}," +
                "{\"EmpCode\":\"06129\",\"EmpName\":\"戴加兵\"},{\"EmpCode\":\"06657\",\"EmpName\":\"周军\"},{\"EmpCode\":\"10497\",\"EmpName\":\"刘鹏\"}," +
                "{\"EmpCode\":\"13534\",\"EmpName\":\"叶盛\"},{\"EmpCode\":\"13551\",\"EmpName\":\"顾林仟\"},{\"EmpCode\":\"16901\",\"EmpName\":\"祝进云\"}," +
                "{\"EmpCode\":\"19318\",\"EmpName\":\"王申\"},{\"EmpCode\":\"21751\",\"EmpName\":\"刘晓敏\"},{\"EmpCode\":\"29739\",\"EmpName\":\"王亮\"}," +
                "{\"EmpCode\":\"09564\",\"EmpName\":\"丁勇\"},{\"EmpCode\":\"10238\",\"EmpName\":\"李绍可\"},{\"EmpCode\":\"10681\",\"EmpName\":\"杨世宇\"}," +
                "{\"EmpCode\":\"10824\",\"EmpName\":\"邢甜\"},{\"EmpCode\":\"16005\",\"EmpName\":\"孔令德\"},{\"EmpCode\":\"13983\",\"EmpName\":\"张锐\"}," +
                "{\"EmpCode\":\"32135\",\"EmpName\":\"施蕾\"},{\"EmpCode\":\"10810\",\"EmpName\":\"卜庆庆\"},{\"EmpCode\":\"10863\",\"EmpName\":\"李铖凯\"}," +
                "{\"EmpCode\":\"17436\",\"EmpName\":\"时伟\"},{\"EmpCode\":\"03311\",\"EmpName\":\"李小伟\"},{\"EmpCode\":\"06216\",\"EmpName\":\"周黎\"}," +
                "{\"EmpCode\":\"09905\",\"EmpName\":\"王延\"},{\"EmpCode\":\"06111\",\"EmpName\":\"胡彬\"},{\"EmpCode\":\"16304\",\"EmpName\":\"吴旭芬\"}," +
                "{\"EmpCode\":\"22829\",\"EmpName\":\"曹竟\"},{\"EmpCode\":\"26298\",\"EmpName\":\"李旦\"},{\"EmpCode\":\"06765\",\"EmpName\":\"李红明\"}," +
                "{\"EmpCode\":\"15118\",\"EmpName\":\"乔雪健\"},{\"EmpCode\":\"25488\",\"EmpName\":\"阳林\"},{\"EmpCode\":\"35584\",\"EmpName\":\"殷晓东\"}]";
            return Content(employee);
        }
        [HttpGet]
        public ContentResult GetRander()
        {

            while (true)
            {
                int i = new Random().Next(0, 99);
                if (i % 3 == 0)
                {
                    return Content(i.ToString());
                }
                Thread.Sleep(3000);
            }
        }
    }
}