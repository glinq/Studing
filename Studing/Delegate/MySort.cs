using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    /// <summary>
    /// 对象数组排序方法
    /// </summary>
    public class MySort
    {
        /// <summary>
        /// 排序方法
        /// </summary>
        /// <param name="list">对象数组</param>
        /// <param name="comparemethod">需要对象自己去实现比较方法  返回bool类型</param>
        public static void Sort<T>(IList<T> list, Func<T, T, bool> comparemethod)
        {
            //使用冒泡排序算法（从大到小排序）
            bool IsContinu = true;
            do
            {
                IsContinu = false;
                for (int i = 0; i < list.Count() - 1; i++)
                {
                    if (comparemethod(list[i], list[i + 1]))//第一个比第二个小
                    {
                        T temp = list[i + 1];
                        list[i + 1] = list[i];
                        list[i] = temp;
                        IsContinu = true;
                    }
                }
            } while (IsContinu);
        }
    }
}
