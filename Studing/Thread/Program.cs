using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadDemo
{
    class Program
    {
        private static readonly object obj = new object();
        static void Main(string[] args)
        {
            #region 后台线程
            //Thread t = new Thread(Worker);
            ///*应用程序必须运行完所有的前台线程才可以退出；
            // * 而对于后台线程，应用程序则可以不考虑其是否已经运行完毕而直接退出，
            // */
            //t.IsBackground = true;
            //t.Start();
            //Console.WriteLine("Running from Main");

            ////其他创建线程的方式
            //Thread tt = new Thread(new ParameterizedThreadStart(t1 => Console.WriteLine(t1)));
            //tt.Start("1234567890");
            //Thread t2 = new Thread(t1 => Console.WriteLine(t1));
            //t2.Start("1234567890");
            #endregion

            #region 锁
            //new TaskFactory().StartNew(() => { TestLock("子线程1"); });
            //new TaskFactory().StartNew(() => { TestLock("子线程2"); });
            //new TaskFactory().StartNew(() => { TestLock("子线程3"); });
            //new TaskFactory().StartNew(() => { TestLock("子线程4"); });
            //TestLock("主线程");
            #endregion

            #region 线程取消方式
            //CancellationTokenSource cts = new CancellationTokenSource();
            //Task.Run(() => Worker(), cts.Token);
            //Task<long> tr = new Task<long>(()=>WorkerInt(cts.Token, 1), cts.Token);
            //tr.Start();
            //Task<long> tr1 = Task.Run(() => WorkerInt(cts.Token, 900), cts.Token);
            //if (tr.Wait(10000))
            //{
            //    Console.WriteLine("**********速度贼快************");
            //    tr.ContinueWith(a => Console.WriteLine("111"), TaskContinuationOptions.OnlyOnRanToCompletion);
            //}
            //else
            //{
            //    Console.WriteLine("**********超时了************");
            //};
            //cts.Cancel();
            //tr.ContinueWith(a => Console.WriteLine("我感觉你被取消了"), TaskContinuationOptions.OnlyOnCanceled);
            //try
            //{
            //    Console.WriteLine("WorkerInt()返回结果{0}", tr.Result);
            //}
            //catch (AggregateException ex)
            //{
            //    Console.WriteLine("WorkerInt() is canceled");

            //}
            #endregion

            #region 并行处理任务
            //处理可并行处理的循环 不共同修改公共资源
            //ParalleTest();
            #endregion

            #region 线程池线程处理 获取线程池最大线程数  最小保留的线程数
            //如果没有线程池线程 就会自动创建  执行完任务后 返回到线程池  长时间闲置 会自己醒来自动释放自己
            //ThreadPool.QueueUserWorkItem(a => Console.WriteLine("当前线程id{0}", Thread.CurrentThread.ManagedThreadId), null);
            //ThreadPool.QueueUserWorkItem(a => Console.WriteLine("当前线程id{0}", Thread.CurrentThread.ManagedThreadId), null);
            //ThreadPool.QueueUserWorkItem(a => Console.WriteLine("当前线程id{0}", Thread.CurrentThread.ManagedThreadId), null);
            //ThreadPool.QueueUserWorkItem(a => Console.WriteLine("当前线程id{0}", Thread.CurrentThread.ManagedThreadId), null);

            //int workThreads = 0, IOThreads = 0;
            //ThreadPool.GetMaxThreads(out workThreads, out IOThreads);
            //Console.WriteLine("GetMaxThreads workThreads:{0},IOThreads:{1}", workThreads, IOThreads);
            //ThreadPool.GetMinThreads(out workThreads, out IOThreads);
            //Console.WriteLine("GetMinThreads workThreads:{0},IOThreads:{1}", workThreads, IOThreads);
            //ThreadPool.GetAvailableThreads(out workThreads, out IOThreads);
            //Console.WriteLine("GetAvailableThreads workThreads:{0},IOThreads:{1}", workThreads, IOThreads);
            #endregion

            #region 任务完成时启动新任务（延续任务）  
            //在前一个任务取消的情况下TaskContinuationOptions.OnlyOnCanceled
            // Task.Run(() => Worker()).ContinueWith(c => Worker(), TaskContinuationOptions.OnlyOnRanToCompletion);
            #endregion

            #region 启动子任务
            ////创建子任务TaskContinuationOptions.AttachedToParent
            //Task parent = new Task(() =>
            //{
            //    new Task(() => Console.WriteLine("1"), TaskCreationOptions.AttachedToParent).Start();
            //    new Task(() => Console.WriteLine("2"), TaskCreationOptions.DenyChildAttach).Start();
            //    new Task(() => Console.WriteLine("3"), TaskCreationOptions.PreferFairness).Start();
            //    new Task(() => Console.WriteLine("4"), TaskCreationOptions.AttachedToParent).Start();
            //});
            //parent.Start();
            #endregion

            #region 任务工厂使用
            /////*
            //// 统一去管理任务的配置     获取多个线程执行结果的最大值          
            //// */
            //CancellationTokenSource ctsss = new CancellationTokenSource();
            //Task Parent = new Task(() =>
            //{
            //    //相同的任务配置
            //    var tf = new TaskFactory(ctsss.Token, TaskCreationOptions.AttachedToParent,
            //        TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Default);

            //    var tasks = new[] {
            //    tf.StartNew(() => WorkerInt(ctsss.Token,300)),
            //    tf.StartNew(() => WorkerInt(ctsss.Token,500)),
            //    tf.StartNew(() => WorkerInt(ctsss.Token,6000))
            //    };
            //    for (int i = 0; i < tasks.Length; i++)
            //    {
            //        tasks[i].ContinueWith(t1 => ctsss.Cancel(), TaskContinuationOptions.OnlyOnFaulted);
            //    }
            //    tf.ContinueWhenAll(tasks, completetask =>
            //    completetask.Where(t1 => !t1.IsFaulted && !t1.IsCanceled).Max(t1 => t1.Result), TaskContinuationOptions.None)
            //    .ContinueWith(t1 => Console.WriteLine("the maximum is {0}", t1.Result), TaskContinuationOptions.ExecuteSynchronously);
            //});

            //Parent.ContinueWith(p =>
            //{
            //    StringBuilder sb = new StringBuilder(string.Format("The fpllpwing exceptions occurred: {0}", Environment.NewLine));
            //    foreach (var e in p.Exception.Flatten().InnerExceptions)
            //    {
            //        sb.AppendFormat(e.GetType().ToString());
            //        Console.WriteLine(sb.ToString());
            //    }
            //}, TaskContinuationOptions.OnlyOnFaulted);

            //Parent.Start();
            #endregion

            #region  定时器
            //TimerTest();//Timer
            //TaskDelayTest();// taskdelay+async+await
            //TaskDelayTest2();
            #endregion

            #region 异步读取文件
            //var v = ReadFile();
            //Console.WriteLine(v.Length);
            #endregion



            //Parallel.For(1, 3, a => {
            //    int begin = 0;//页
            //    for (int i = 1; i <= 10; i++)//数据是  50页*100条*batchNo  条
            //    {
            //        begin = (a - 1) * 50 + i;//当前是第几页
            //        Console.WriteLine($"当前第{begin}页，每页100条；");
            //    }

            //});




            List<long> piclistRes = new List<long>();
            for (int i = 1; i <= 134; i++)
            {
                piclistRes.Add(i);
            }

            List<Task> tasklist = new List<Task>();
            int pagesize = 11;
            int tasks = piclistRes.Count / pagesize;
            for (int i = 0; i <= tasks; i++)
            {
                List<long> li = piclistRes.Skip(i * pagesize).Take(pagesize).ToList();
                int ii = i;
                tasklist.Add(Task.Run(() =>
                {
                    if(li.Count>0)
                    {
                        count++;
                        Console.WriteLine($"我是第{ii}页数据,最大是{li.Last()}，最小是{li.First()}；");
                    }
                    Thread.Sleep(500);
                }));
            }
            Console.WriteLine($"count={count}");
            Task.WaitAll(tasklist.ToArray());
            Console.WriteLine($"count={count}");
            Console.ReadKey();
        }
        private static int count=0;
        private static void TestLock(string method)
        {

            lock (obj)
            {
                Console.WriteLine("{0}已经把obj锁住了,当前线程id{1}", method, Thread.CurrentThread.ManagedThreadId);
                SingleUnit.GetInstens();
                Thread.Sleep(1000);
                Console.WriteLine("{0}已经执行好了,当前线程id{1}", method, Thread.CurrentThread.ManagedThreadId);
            }
        }
        public static void Worker()
        {
            Thread.Sleep(7000);
            Console.WriteLine("Running from worker");
        }
        public static long WorkerInt(CancellationToken c, int length)
        {
            Stopwatch S = new Stopwatch();
            S.Start();
            long result = 0;
            if (length == 50000)
            {
                Convert.ToInt32("kfvsdnkbnf");
            }
            for (int i = 1; i <= length; i++)
            {
                Console.WriteLine("Running from WorkerInt(){0}", i);
                result += i;
                c.ThrowIfCancellationRequested();
            }
            S.Stop();
            Console.WriteLine("Running 耗时{0},结果:{1},threadId:{2}----{3}", S.ElapsedMilliseconds, result, Thread.CurrentThread.ManagedThreadId, length);
            return result;
        }
        public static long WorkerInt(int len)
        {
            Stopwatch S = new Stopwatch();
            S.Start();
            long result = 0;
            for (int i = 1; i <= len; i++)
            {
                result += i;
            }
            S.Stop();
            Console.WriteLine("Running 耗时{0},结果:{1},threadId:{2}----{3}", S.ElapsedMilliseconds, result, Thread.CurrentThread.ManagedThreadId, len);
            return result;
        }
        public static void ParalleTest()
        {
            Parallel.For(1, 3000000, i => { Thread.Sleep(10); Console.WriteLine(i); });
            //Parallel.ForEach(new List<int> { 1, 2, 3 }, i => Console.WriteLine(i));
            //Parallel.Invoke(() => Console.WriteLine("2222222222"), () => Console.WriteLine($"33333"));
        }
        public static void TimerTest()
        {
            Timer tr = new Timer(t => Console.WriteLine(t), "my  status", 1000, 100);//1000ms后执行，每次执行时间间隔100ms
            Thread.Sleep(2000);
            tr.Change(1000, 10);//1000ms后执行，每次执行时间间隔10ms
            Thread.Sleep(2000);
            tr.Change(0, Timeout.Infinite);//终止
            tr.Dispose();
        }
        /// <summary>
        /// 时钟
        /// </summary>
        public static async void TaskDelayTest()
        {
            while (true)
            {
                Console.WriteLine("{0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                await Task.Delay(1000);
            }
        }
        public static void TaskDelayTest2()
        {
            while (true)
            {
                Console.WriteLine("{0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                Thread.Sleep(1000);
            }
        }
        public static byte[] ReadFile()
        {
            byte[] bytearr = new byte[199900];
            FileStream fs = new FileStream(@"C:\1.txt", FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite, 1, FileOptions.Asynchronous);
            Task<int> t = fs.ReadAsync(bytearr, 0, 199900);
            t.ContinueWith(t2 => Console.WriteLine("读取完成"));
            return bytearr;
        }
    }

    public class SingleUnit
    {
        private SingleUnit()
        {

        }
        private static readonly object obj = new object();

        private static SingleUnit Unit;

        private List<int> list = new List<int> { 1, 2, 3, 4, 5 };

        public List<int> GetListInfo()
        {
            return list;
        }

        public static SingleUnit GetInstens()
        {
            if (Unit == null)
            {
                lock (obj)
                {
                    if (Unit == null)
                    {
                        return new SingleUnit();
                    }
                }
            }
            return Unit;
        }
    }
}
