using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLq
{
    /// <summary>
    /// 实体比较
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EntityCompare<T> where T : class
    {
        /// <summary>
        /// 实体更新 改动日志
        /// </summary>
        /// <param name="oldEntity"></param>
        /// <param name="newEntity"></param>
        /// <returns></returns>
        public static string CompareEntityDiffrent(T oldEntity, T newEntity)
        {
            try
            {
                System.Reflection.PropertyInfo[] pInfo = typeof(T).GetProperties();
                StringBuilder str = new StringBuilder(string.Empty);
                foreach (var pi in pInfo)
                {
                    object oldValue = pi.GetValue(oldEntity);
                    object newValue = pi.GetValue(newEntity);
                    if (!oldValue.Equals(newValue))
                    {
                        object[] desc = pi.GetCustomAttributes(typeof(EntityDes), false);
                        foreach (EntityDes item in desc)
                        {
                            str.AppendFormat("【{0}由{1}->{2}】,", item.Desc, oldValue, newValue);
                        }
                    }
                }
                return str.ToString().TrimEnd(',');
            }
            catch (Exception ex)
            {
                return "转换异常";
            }
        }
        /// <summary>
        /// 实体新增  日志
        /// </summary>
        /// <param name="newEntity"></param>
        /// <returns></returns>
        public static string CompareEntityAdd(T newEntity)
        {
            try
            {
                System.Reflection.PropertyInfo[] pInfo = typeof(T).GetProperties();
                StringBuilder str = new StringBuilder(string.Empty);
                for (int i = 0; i < pInfo.Length; i++)
                {
                    System.Reflection.PropertyInfo pi = pInfo[i];
                    object newValue = pi.GetValue(newEntity);
                    object[] desc = pi.GetCustomAttributes(typeof(EntityDes), false);
                    foreach (EntityDes item in desc)
                    {
                        str.AppendFormat("【{0}={1}】,", item.Desc, newValue);
                    }
                }
                return str.ToString().TrimEnd(',');
            }
            catch (Exception ex)
            {
                return "转换异常";
            }

        }
    }
    /// <summary>
    /// 字段特性
    /// </summary>
    public class EntityDes : Attribute
    {
        public string Desc { get; set; }
    }
}
