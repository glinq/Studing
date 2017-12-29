using System;

namespace myLibrary
{
    public static class MyLibrary
    {
        /// <summary>
        /// 字符串以大写字母开头
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool StartsWithUpper(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return false;
            }
            char ch = str[0];
            return char.IsUpper(ch);
        }
    }
}
