using System;
using System.Collections.Generic;
using System.Text;
using myLibrary;
namespace helloworld
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //Console.WriteLine("please input your names!");
            //string names = Console.ReadLine();
            //Console.WriteLine($"hello {names} ,now is {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}!");
            //Console.WriteLine("press any key to continue!");
            //Console.ReadKey(true);

            //int rows = Console.WindowHeight;
            //Console.Clear();
            //do
            //{
            //    if(Console.CursorTop>=rows||Console.CursorTop==0)
            //    {
            //        Console.Clear();
            //        Console.WriteLine("按 Enter键退出，或者输入一些字符+Enter键继续；");
            //    }
            //    string inputstr = Console.ReadLine();
            //    if(string.IsNullOrWhiteSpace(inputstr))
            //    {

            //        break;
            //    }
            //    Console.WriteLine($"Input: {inputstr} {"Begins with uppercase? ",30}: {(inputstr.StartsWithUpper() ? "Yes" : "No")}\n");
            //} while (true);

            //Dictionary<string, string> dic = new Dictionary<string, string>();
            //dic.Add("10001", "2");
            //dic.Add("10002", "4");
            //dic.Add("10003", "6");

            //List<string> keys = new List<string>(dic.Keys);

            //for (int i = 0; i < dic.Count; i++)
            //{

            //    Console.WriteLine($"key:{keys[i]},value:{dic[keys[i]]}");
            //    if (i == 2)
            //    {
            //        dic.Remove(keys[i]);
            //    }
            //}
            //Console.WriteLine("*******************************");
            //for (int i = 0; i < dic.Count; i++)
            //{
            //    Console.WriteLine($"key:{keys[i]},value:{dic[keys[i]]}");
            //}


            StringBuilder paramList = new StringBuilder();
            var relateIdList = new List<string> {"a","b","c" };
            foreach (var item in relateIdList)
            {
                if (string.IsNullOrEmpty(item))
                {
                    continue;
                }
                paramList.AppendFormat("'{0}',", item);
            }
            Console.WriteLine(paramList.ToString().TrimEnd(','));

            Console.Read();

        }
    }
}
