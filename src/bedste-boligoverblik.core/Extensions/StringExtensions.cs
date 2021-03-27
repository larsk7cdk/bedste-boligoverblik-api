namespace bedste_boligoverblik.core.Extensions
{
    public static class StringExtensions
    {
        public static int ToInteger(this string s)
        {
            return s == null ? 0 : int.Parse(s.Replace(".", ","));
        }

        public static decimal ToDecimal(this string s)
        {
            return s == null ? 0 : decimal.Parse(s.Replace(".", ","));
        }
    }
}