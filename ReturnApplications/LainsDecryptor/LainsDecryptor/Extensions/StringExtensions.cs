using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LainsDecryptor.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string s)
        {
            return s == null || s == "";
        }

        public static int ToInt32(this string s)
        {
            return Convert.ToInt32(s);
        }
    }
}
