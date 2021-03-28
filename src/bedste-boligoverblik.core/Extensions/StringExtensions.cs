using System;

namespace bedste_boligoverblik.core.Extensions
{
    public static class StringExtensions
    {
        public static int ToInteger(this string s)
        {
            return s == null ? 0 : int.Parse(s.Replace(".", ","));
        }

        public static decimal ToDecimal(this string s, int noOfDecimals = 2)
        {
            var result = s == null ? 0 : decimal.Parse(s.Replace(".", ","));
            return Math.Round(result, noOfDecimals);
        }
    }
}