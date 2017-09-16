using Delegate;
using System;
using System.Collections.Generic;

namespace Deleget
{

    class Program
    {
        static void Main(string[] args)
        {
            #region 计算器
            MyCalculate _MyCalculate = new MyCalculate();
            //一般的调用
            Calculate_Delegate _calculate_Delegate;
            //创建的多种方法
            _calculate_Delegate = new Calculate_Delegate(_MyCalculate.Add);
            //_calculate_Delegate = _MyCalculate.Add; //可以直接这么写（只要符合委托签名即可）
            //多播委托(栈方式 如果有返回值，则只返回后入的那个方法返回值)
            _calculate_Delegate += _MyCalculate.Subtraction;
            _calculate_Delegate += _MyCalculate.Multiplication;
            _calculate_Delegate -= _MyCalculate.Subtraction;
            _calculate_Delegate -= _MyCalculate.Divide;//可以去除不存在的方法
            double result;
            //执行的多种方法
            result = _calculate_Delegate.Invoke(4, 3);
            //Func<T> 委托
            result = _MyCalculate.DoCalculate<double>(4, 5, _MyCalculate.Add);
            Console.WriteLine($"{result}");
            result = _calculate_Delegate(4, 3);
            Console.WriteLine($"{result}");
            //方法作为参数传递给另一个方法
            result = _MyCalculate.DoCalculate(_MyCalculate.Divide, 4, 3);
            Console.WriteLine("计算结果是：" + result);

            #endregion

            #region 通用排序实例
            List<Employee> Employees = new List<Employee>
            {
                new Employee("和",6),
                new Employee("林",8),
                new Employee("粥",5),
                new Employee("轮",3),
                new Employee("顾",9),
                new Employee("小",4),
                new Employee("仟",7)
            };

            MySort.Sort(Employees, Employee.CompareAge);
            Employees.ForEach(
                f =>
                {
                    Console.WriteLine(f);
                });

            #endregion

            #region 多播委托和异常处理
            Action actions = One;
            actions += Two;
            ////第一种：这种多播委托 如果第一个方法异常了  就会停止迭代了  不会去执行后面的方法了
            try
            {
                actions.Invoke();
                
            }
            catch (Exception ex)
            {

                Console.WriteLine("actions.Invoke() exception");
            }
            //第二种：将多播委托使用GetInvocationList() ，得到一个Delegate[]，再执行，出异常可以继续下一次迭代
            System.Delegate[] d = actions.GetInvocationList();
            foreach (Action item in d)
            {
                try
                {
                    item();
                }
                catch (Exception)
                {

                    Console.WriteLine("Delegate[] d , item() exception");
                }
            }

            #endregion

            Action a = () => Console.WriteLine("1");
            Console.ReadKey();
        }

        static void One()
        {
            Console.WriteLine("I am One");
            throw new Exception("one exception");
        }
        static void Two()
        {
            Console.WriteLine("I am Two");
        }

    }
}
