using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Console;

namespace StringAndRegularExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 3, y = 4;
            FormattableString s = $"{x} +{y}={x + y}";//插值字符串
            WriteLine($"format:{s.Format}");//得到格式字符串
            for (int i = 0; i < s.ArgumentCount; i++)
            {
                WriteLine($"argument{i}:{s.GetArgument(i)}");
            }

            var day = DateTime.Now;
            WriteLine($"{day:d}");
            WriteLine($"{day:D}");
            WriteLine(FormattableString.Invariant($"{day:d}"));//不变的区域值
            WriteLine(FormattableString.Invariant($"{day:D}"));//不变的区域值
            WriteLine($"{day:yyyy-MM-dd HH:mm:ss}");//MMM月份缩写

            double d = 3.1415926;
            WriteLine($"{d:###.###}");//保留三位小数，#代表有值即显示值，无值就不显示；
            WriteLine($"{d:000.000}");//也是保留三位小数，0代表有值就显示值，无值就显示0；




            //string pattern = @"\b(https?)(://)([.\w]+)([\s:]([\d]{2,4})?)\b";
            string pattern = @"\b(?<协议>https?)(://)(?<网址>[.\w]+)([\s:](?<端口>[\d]{2,4})?)\b";//?<groupname>
            /*
             (https?)    ==>  http   https
             (://)       ==> 如  ://
             ([.\w]+)    ==>.或者任意字母数字字符  可以重复1或多次  如 www.  www.2.com
             ([\s:]([\d]{2,4})?) 
             [\s:]     ==>任何空白字符  或 冒号：   如 ：
             ([\d]{2,4})? =>数字 至少出现2次但不超过4次 匹配0次或1次    如 80  8888
             */
            Regex r = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture);
            string str = @"Hey,I've just found this amazing URI at
                        http:// what was it -oh yes https://www.wrox.com or http://www.wrox.com:80";
            MatchCollection mc = r.Matches(str);
            foreach (Match item in mc)
            {
                WriteLine($"match:{item} in {item.Index}");
                foreach (var g in r.GetGroupNames())
                {
                    WriteLine($"match for {g}:{item.Groups[g].Value}");
                }

            }
            ReadKey();
        }
    }
}
