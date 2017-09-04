using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

            DateTime now = DateTime.Now;
            DateTime StopDate=Convert.ToDateTime("2017-6-1 00:00:00");
            for (DateTime m = new DateTime(now.Year, now.Month, now.Day, 0,0, 0); m >= StopDate; m = m.AddDays(-10))
            {
                if (m.AddDays(-10) < StopDate)
                {
                    Console.WriteLine("{0},{1}", StopDate.ToString("yyyy-MM-dd HH:mm:ss"), m.ToString("yyyy-MM-dd HH:mm:ss"));
                }
                else
                {
                    Console.WriteLine("{0},{1}", m.AddDays(-10).ToString("yyyy-MM-dd HH:mm:ss"), m.ToString("yyyy-MM-dd HH:mm:ss"));
                }                
            }
            //string s = "12222";
            //string[] sarr = s.Split(',');
            //List<string> LI = new List<string> { "1", "23", "3" };
            //string ss = LI.FirstOrDefault(f => sarr.Contains(f)) ?? "11111111111111111";
            //Console.WriteLine(ss);


            //LI = LI.Where(w => w == "4").ToList();
            //string aaa= LI.FirstOrDefault(w => w == "4");
            //for (int i = 0; i < LI.Count; i++)
            //{
            //    Console.WriteLine(LI[i]);
            //}
            //List<string> list = new List<string> {"fdasfdsa","ee222","3445","fr5","7y" };
            //list = list.Skip(2).ToList();
            //string str = string.Format("where name in ({0})",string.Join("','",list));
            //str = str.Replace("(", "('").Replace(")","')");
            //Console.WriteLine(str);


            //var taskList = new List<Task>();
            //var excutelist = new List<int>();
            //Parallel.For(0, 100, a =>show(a,1));
            //Parallel.For(0, 3, b => Parallel.For(0, 9, a => show(a, b)));
            int x = 1, y = 2, z = 3;
            //var res = --ii + jj++;
            Console.WriteLine("y＋＝z－－/＋＋x,结果是{0}", y += z-- / ++x);
            Console.ReadKey();
        }

        public async static void show(int str, int b)
        {
            Thread.Sleep(500);
            await Task.Run(() => Console.WriteLine("{0}_{1}", b, str));
        }
    }
}
