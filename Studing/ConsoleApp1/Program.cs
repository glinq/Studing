using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Task> tasks = new List<Task>();
            for (int a = 1; a < 100; a++)
            {
                //tasks.Add(Task.Run(() => { Wash_SupplierId_s($" dppid>{a * 10000} and dppid<={(a + 1) * 10000} "); }));
                int b = a;
                tasks.Add(Task.Run(() => { hhhh($" dppid>{b} and dppid<={b + 1} "); }));
                if (tasks.Count > 10)
                {
                    tasks.RemoveAt(Task.WaitAny(tasks.ToArray()));
                }
            }
            Console.WriteLine("Hello World!");
            Console.Read();
        }
        private static void hhhh(string s)
        {
            Thread.Sleep(5000);
            Console.WriteLine(s+"....."); 
        }
    }
}
