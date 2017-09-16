using System;
using System.Windows;

namespace Events
{
    /// <summary>
    /// 事件参数类(中间的桥梁)
    /// </summary>
    public class CarInfoEventArgs //: EventArgs//派生自事件参数基类
    {
        public CarInfoEventArgs(string car)
        {
            Car = car;
        }
        public string Car { get; }
    }
    /// <summary>
    /// 事件发布器   经销商
    /// </summary>
    public class CarDealer
    {
        /// <summary>
        /// 定义 EventHandler<CarInfoEventArgs> 类型的事件event   NewCarInfo_event
        /// </summary>
        public event EventHandler<CarInfoEventArgs> NewCarInfo_event;

        public void NewCar(string car)
        {
            Console.WriteLine($"汽车经销商：新的car:{car}，到了啊");
            //此事件是否有人订阅，如果有就执行方法
            //sender  this:事件的发送者 ，args:事件有关的信息
            NewCarInfo_event?.Invoke(this, new CarInfoEventArgs(car));
        }
    }
    /// <summary>
    /// 事件侦听器1  消费者(强连接)
    /// </summary>
    public class Customer//: IWeakEventListener
    {
        private string _name;

        public Customer(string name)
        {
            _name = name;
        }
        /// <summary>
        /// 事件侦听器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void NewCarIsHere(object sender, CarInfoEventArgs e)
        {
            Console.WriteLine($"{_name}：哇！ {e.Car} ！，赶快去看看");
        }


    }

}
