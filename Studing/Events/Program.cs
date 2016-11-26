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

            //普通的写法  
            Cat.Miao();

            //事件的方式
            Cat cat = new Cat();
            cat.CatMiao_Event += Dog.Wang;
            cat.CatMiao_Event += Stealer.Hide;
            cat.CatMiao_Event += Neighbor.WakeUp;
            cat.MiaoEvent();
            Console.ReadKey();
        }

        private static void Myevent_eatSomething()
        {
            Console.WriteLine("Myevent_eatSomething");
        }
    } 
}
