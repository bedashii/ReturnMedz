using System.Text.RegularExpressions;

namespace BooruHelper.Extensions
{
    public static class StringExtensions
    {
        public static string SplitByCamelCase(this string s)
        {
            var returnValue = string.Empty;

            foreach (var split in Regex.Split(s, @"(?<!^)(?=[A-Z])"))
            {
                returnValue = $"{returnValue} {split}";
            }

            return returnValue;
        }
    }
}