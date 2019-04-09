using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLq;

namespace CommonTestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream fs = new FileStream("d:\\22.jpg", FileMode.Open))
            {
                ImageCodecInfo iamgecode = fs.GetImageEncoder();
                Console.WriteLine($"MimeType:{iamgecode.MimeType},格式：{iamgecode.FormatDescription}，文件扩展名：{iamgecode.FilenameExtension}");
                Console.ReadKey();
            }
        }
    }
}
