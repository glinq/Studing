using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deleget
{
    /*********
     * 归纳加减乘除的方法共同的规律
     * 定一个委托  可以避免更多的if(){}else{};switch();
     * **********************/
    delegate double Calculate(double x, double y);//申明一个委托类型
    class Program
    {
        static void Main(string[] args)
        {
            //一般的调用
            Calculate calculate;
            //创建的多种方法
            calculate = new Calculate(Add);
            calculate = Add;
            //多播委托
            calculate += Subtraction;
            calculate += Multiplication;
            calculate -= Subtraction;
            calculate -= Divide;
            double result;
            //执行的多种方法
            result = calculate.Invoke(4, 3);
            result = calculate(4, 3);

            //方法作为参数传递给另一个方法
            result = DoCalculate(Divide, 4, 3);
            Console.WriteLine("计算结果是：" + result);
            Console.ReadKey();

        }
        /// <summary>
        /// 将委托方法method比如（Add）传给另一个方法DoCalculate作为参数
        /// </summary>
        /// <param name="method"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        static double DoCalculate(Calculate method, double x, double y)
        {
            return method(x, y);
        }

        static double Add(double x, double y)
        {
            return x + y;
        }
        static double Subtraction(double x, double y)
        {
            return x - y;
        }
        static double Multiplication(double x, double y)
        {
            return x * y;
        }
        static double Divide(double x, double y)
        {
            return x / y;
        }
    }
}
