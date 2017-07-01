using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 单例模式
{
    public class StaticBianLiang
    {
        private StaticBianLiang()
        {
            Console.WriteLine("我被创建了，线程id={0}", Thread.CurrentThread.ManagedThreadId);
        }
        private static StaticBianLiang _LockMethod = new StaticBianLiang(); //CLR static静态机制，当程序启动时肯定会被创建且只创建一次
        public static StaticBianLiang GetInstance()
        {
            return _LockMethod;
        }
        public void PrintHello()
        {
            Console.WriteLine("*********HELLO*LINQ******线程={0}******", Thread.CurrentThread.ManagedThreadId);
        }
    }
}
