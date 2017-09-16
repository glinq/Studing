using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    class Program
    {

        static void Main(string[] args)
        {
            #region 委托方式
            MyEvent myevent = new MyEvent();
            /**********事件***********/
            myevent.eatSomething_Event += Myevent_eatSomething;
            //myevent.eatSomething_Event = Myevent_eatSomething;//事件不能外面直接赋值  只能出现+=  -= 的左边 只能加上自己的行为 ----保证安全
            //myevent.eatSomething_Event();//事件不允许外界直接调用   -----保证安全
            myevent.EatAction_Event();//----事件只能内部去执行
            /**********委托***********/
            myevent.eatSomething_Delegate += Myevent_eatSomething;
            myevent.eatSomething_Delegate = Myevent_eatSomething;//委托可以重新赋值
            myevent.eatSomething_Delegate();//委托外部可以随意调用
            myevent.EatAction_Event();
            //委托的写法  
            Cat.Miao();
            //事件的方式
            Cat cat = new Cat();
            cat.CatMiao_Event += Dog.Wang;
            cat.CatMiao_Event += Stealer.Hide;
            cat.CatMiao_Event += Neighbor.WakeUp;
            cat.MiaoEvent();
            #endregion

            #region 事件订阅
            Console.WriteLine("*********************事件发布、订阅*********************");
            var _dealer = new CarDealer();//经销商
            var gu = new Customer("顾");
            _dealer.NewCarInfo_event += gu.NewCarIsHere;
            _dealer.NewCar("法拉利");

            var lin = new Customer("林");
            _dealer.NewCarInfo_event += lin.NewCarIsHere;
            _dealer.NewCar("玛莎拉蒂");

            var qian = new Customer("仟");
            _dealer.NewCarInfo_event += qian.NewCarIsHere;
            _dealer.NewCar("保时捷");
            #endregion

            Console.ReadKey();
        }

        private static void Myevent_eatSomething()
        {
            Console.WriteLine("Myevent_eatSomething");
        }
    }
}
