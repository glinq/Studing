using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 单例模式
{
    public class LockMethod
    {
        private LockMethod()
        {
            Console.WriteLine("我被创建了，线程id={0}",Thread.CurrentThread.ManagedThreadId);
        }
        private static LockMethod _LockMethod = null;
        private static readonly object lock_this = new object();
        public static LockMethod GetInstance()
        {
            if (_LockMethod == null)
            {
                lock (lock_this)
                {
                    if (_LockMethod == null)
                    {
                        _LockMethod = new LockMethod();
                    }
                }
            }
            return _LockMethod;
        }

        public void PrintHello()
        {
            Console.WriteLine("*********HELLO*LINQ******线程={0}******", Thread.CurrentThread.ManagedThreadId);
        }
    }
}
