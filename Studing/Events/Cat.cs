using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{

    public delegate void CatMiao_Delegate();
    /// <summary>
    /// 触发者
    /// </summary>
    public class Cat
    {
        public static void Miao()
        {
            Console.WriteLine("*****************Miao*******************");
            Console.WriteLine("猫 喵一声");
            Dog.Wang();
            Stealer.Hide();
            Neighbor.WakeUp();
        }

        public  event CatMiao_Delegate CatMiao_Event;
        /// <summary>
        ///事件的方式
        /// </summary>
        public  void MiaoEvent()
        {
            Console.WriteLine("*****************MiaoEvent*******************");
            Console.WriteLine("猫 喵一声");
            CatMiao_Event?.Invoke();
        }
    }
}
