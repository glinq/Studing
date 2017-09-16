using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    /*********
 * 归纳加减乘除的方法共同的规律
 * 定一个委托  可以避免更多的if(){}else{};switch();
 * **********************/
    public delegate double Calculate_Delegate(double x, double y);//申明一个委托类型
    public class MyCalculate
    {
        /// <summary>
        /// 将委托方法method比如（Add）传给另一个方法DoCalculate作为参数
        /// </summary>
        /// <param name="method"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public double DoCalculate(Calculate_Delegate method, double x, double y)
        {
            return method(x, y);
        }
        /// <summary>
        /// 利用Func<T>或Action<T>委托替代自定义委托
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public double DoCalculate<T>(T x, T y, Func<T, T, double> method)
        {
            return method(x, y);
        }
        public double Add(double x, double y)
        {
            return x + y;
        }
        public double Subtraction(double x, double y)
        {
            return x - y;
        }
        public double Multiplication(double x, double y)
        {
            return x * y;
        }
        public double Divide(double x, double y)
        {
            return x / y;
        }
    }
}
