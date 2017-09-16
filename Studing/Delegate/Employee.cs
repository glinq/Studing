using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    public class Employee
    {
        public Employee()
        {

        }
        public Employee(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public string Name = string.Empty;
        public int Age = 0;

        public override string ToString()
        {
            return $"姓名：{Name},年龄：{Age}";
        }
        /// <summary>
        /// 一个比较方法  如果第一个人的年龄比第二个年龄小 久返回True
        /// </summary>
        /// <param name="one"></param>
        /// <param name="two"></param>
        /// <returns></returns>
        public static bool CompareAge(Employee one, Employee two)
        {
            if (one.Age < two.Age)
            {
                return true;
            }
            return false;
        }
    }
}
