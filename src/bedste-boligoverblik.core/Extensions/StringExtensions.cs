using System;

namespace bedste_boligoverblik.core.Extensions
{
    public static class StringExtensions
    {
        public static int ToInteger(this string s) =>
            s == null ? 0 : int.Parse(s.Replace(".", ","));


        public static decimal ToDecimal(this string s, int noOfDecimals = 2)
        {
            var sDecimal = s == null ? "0.0" : s.Replace(".", ",");
            var parseResult = decimal.TryParse(sDecimal, out var result);

            if (parseResult)
            {
                return Math.Round(result, noOfDecimals);
            }

            throw new Exception($"Fejl ved parse af {s}");
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