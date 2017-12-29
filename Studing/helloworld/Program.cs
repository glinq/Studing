using System;
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

            int rows = Console.WindowHeight;
            Console.Clear();
            do
            {
                if (Console.CursorTop >= rows || Console.CursorTop == 0)
                {
                    Console.Clear();
                    Console.WriteLine("按 Enter键退出，或者输入一些字符+Enter键继续；");
                }
                string inputstr = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(inputstr))
                {
                    break;
                }
                Console.WriteLine($"Input: {inputstr} {"Begins with uppercase? ",30}: {(inputstr.StartsWithUpper() ? "Yes" : "No")}\n");
            } while (true);

        }
    }
}
