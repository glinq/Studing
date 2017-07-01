using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 单例模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("我是第1种lock的方式**********Begin********");
            //多线程调用
            List<Task> tasklist = new List<Task>();
            TaskFactory tf = new TaskFactory();
            for (int i = 0; i < 10; i++)
            {
                tasklist.Add(tf.StartNew(() => LockMethod.GetInstance().PrintHello()));
            }
            Task.WaitAll(tasklist.ToArray());
            Console.WriteLine("我是第1种lock的方式**********End********");

            Console.WriteLine("我是第2种StaticGouZhaoHanShu的方式**********Begin********");
            //多线程调用
            List<Task> tasklist2 = new List<Task>();
            TaskFactory tf2 = new TaskFactory();
            for (int i = 0; i < 10; i++)
            {
                tasklist2.Add(tf2.StartNew(() => StaticGouZhaoHanShu.GetInstance().PrintHello()));
            }
            Task.WaitAll(tasklist2.ToArray());
            Console.WriteLine("我是第2种StaticGouZhaoHanShu的方式**********End********");

            Console.WriteLine("我是第3种StaticBianLiang的方式**********Begin********");
            //多线程调用
            List<Task> tasklist3 = new List<Task>();
            TaskFactory tf3 = new TaskFactory();
            for (int i = 0; i < 10; i++)
            {
                tasklist3.Add(tf3.StartNew(() => StaticBianLiang.GetInstance().PrintHello()));
            }
            Task.WaitAll(tasklist3.ToArray());
            Console.WriteLine("我是第3种StaticBianLiang的方式**********End********");

            //如果是web项目 可以在globle的application_start()方法中直接创建一个普通的类的对象也可以

            Console.ReadKey();
        }
    }
}
