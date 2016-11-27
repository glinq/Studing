using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asnyc
{
    public partial class AsnycForm : Form
    {
        public AsnycForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 所有的异步都是基于委托实现的 
        /// </summary>
        /// <param name="str"></param>
        private delegate void DoSomething(string str);
        private void btnAsnyc_Click(object sender, EventArgs e)
        {
            //实例化一个委托
            //DoSomething dosomething = new DoSomething(t => Console.WriteLine("这里是异步调用，str是{0}",t));
            //DoSomething dosomething =t => Console.WriteLine("这里是btnAsnyc_Click，str是{0},当前线程Id:{1}", t,Thread.CurrentThread.ManagedThreadId);
            //dosomething("直接调用");//主线程调用
            //dosomething.Invoke("Invoke调用");//主线程调用
            //dosomething.BeginInvoke("BeginInvoke调用", null, null);//这就是异步调用  子线程在调用

            Console.WriteLine("**************btnAsnyc_Click异步开始******************");
            DoSomething todo = DoSomethingTest;
            for (int i = 0; i < 5; i++)
            {
                todo.BeginInvoke(string.Format("btnAsnyc_Click异步"),null,null);
            }
            Console.WriteLine("**************btnAsnyc_Click异步结束******************");

            /***************总结异步的特点*******************
            1.同步会卡住界面，异步不会；原因：异步启动了子线程，主线程得到释放；
            2.同步方法会慢，异步方法会快，但是消耗的资源比较多，因为启动了多个子线程；
            3.异步线程启动是无序的，结束也是无序的，由操作系统决定；
            
            *****************总结异步的特点***********/

        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            Console.WriteLine("**************btnSync_Click同步开始******************");
            for (int i = 0; i < 5; i++)
            {
                DoSomethingTest("btnSync_Click同步");
            }
            Console.WriteLine("**************btnSync_Click同步结束******************");
        }

        private void DoSomethingTest(string name)
        {
            long lResult = 0;
            Stopwatch watch = new Stopwatch();
            watch.Start();
            for (int i = 0; i < 1000000; i++)
            {
                lResult += i;
            }
            Thread.Sleep(1000);
            watch.Stop();
            Console.WriteLine("这里是{0}，计算结果是{1}，耗时{2},,当前线程Id{3}", name, lResult, watch.ElapsedMilliseconds, Thread.CurrentThread.ManagedThreadId);
        }

        private void btnAsnycAdvance_Click(object sender, EventArgs e)
        {
            Console.WriteLine("**************btnAsnycAdvance_Click异步进阶开始******************");
            DoSomething todo = DoSomethingTest;
            AsyncCallback asyncCallback = t=> Console.WriteLine("这是asyncCallback,当前线程Id:{0}，AsyncState={1}", Thread.CurrentThread.ManagedThreadId,t.AsyncState);
            //todo.BeginInvoke 的执行结果就是IAsyncResult   其实t就是异步执行的结果
            IAsyncResult result= todo.BeginInvoke(string.Format("btnAsnycAdvance_Click异步进阶"), asyncCallback, "我是什么啊");


            //异步主线程等待三种方式

            //1 
            //result.AsyncWaitHandle.WaitOne(-1);//无限期等待


            //2
            //while (!result.IsCompleted)
            //{
            //    Console.WriteLine("请继续等待.....");
            //}


            //3
            todo.EndInvoke(result);



            Console.WriteLine("**************btnAsnycAdvance_Click异步进阶结束******************");
        }
    }
}
