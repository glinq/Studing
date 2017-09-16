using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    public delegate void EatSomething();//声明一个委托类型
    public class MyEvent
    {
        public EatSomething eatSomething_Delegate;
        //事件就是委托的一个实例 加上了一个关键Event修饰
        public event EatSomething eatSomething_Event;
        /// <summary>
        /// 使用事件方法
        /// </summary>
        /// <param name="eatSomething"></param>
        public void EatAction_Event()
        {
            eatSomething_Event?.Invoke();
        }
        /// <summary>
        /// 使用委托方法
        /// </summary>
        public void EatAction_Delegate()
        {
            eatSomething_Delegate?.Invoke();
        }
    }
}
