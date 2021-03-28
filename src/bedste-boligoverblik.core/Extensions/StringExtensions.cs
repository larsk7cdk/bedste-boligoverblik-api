using System;

namespace bedste_boligoverblik.core.Extensions
{
    public static class StringExtensions
    {
        public static int ToInteger(this string s) =>
            s == null ? 0 : int.Parse(s.Replace(".", ","));


        public static decimal ToDecimal(this string s, int noOfDecimals = 2)
        {
            var result = s == null ? 0 : decimal.Parse(s.Replace(".", ","));
            return Math.Round(result, noOfDecimals);
        }

        public static string CapitalizeFirstLetter(this string s) =>
            s.Length switch
            {
                0 => string.Empty,
                1 => char.ToUpper(s[0]).ToString(),
                _ => char.ToUpper(s[0]) + s.Substring(1)
            };
    }
}