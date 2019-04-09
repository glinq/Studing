using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Drawing;

namespace CommonLq
{
    public static class ImageUnity
    {
        /// <summary>
        /// 转换图片格式
        /// </summary>
        /// <param name="originStream"></param>
        /// <param name="imageFormat"></param>
        /// <returns></returns>
        public static Stream ConvertImageFormat(this Stream originStream, ImageFormat imageFormat)
        {
            Image image = Image.FromStream(originStream);
            var newstram = new MemoryStream();
            image.Save(newstram, imageFormat);
            newstram.Position = 0;
            return newstram;
        }
        /// <summary>
        /// 判断此图片格式是想要的图片格式
        /// </summary>
        /// <param name="originStream"></param>
        /// <param name="needformat"></param>
        /// <returns></returns>
        public static bool IsSameImageFormat(this Stream originStream, ImageFormat needformat)
        {
            Image image = Image.FromStream(originStream);
            return needformat.Equals(image.RawFormat);
        }
    }
}
