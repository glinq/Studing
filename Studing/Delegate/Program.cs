using Delegate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            //多播委托(栈方式  只执行后入的那个方法)
            _calculate_Delegate += _MyCalculate.Subtraction;
            _calculate_Delegate += _MyCalculate.Multiplication;
            _calculate_Delegate -= _MyCalculate.Subtraction;
            _calculate_Delegate -= _MyCalculate.Divide;//可以去除不存在的方法
            double result;
            //执行的多种方法
            result = _calculate_Delegate.Invoke(4, 3);
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

            Console.ReadKey();
        }

    }
}
