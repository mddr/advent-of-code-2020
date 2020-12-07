namespace day_7
{
    public static class StringExtensions
    {
        public static string Cleanup(this string str)
            => str
                .Replace("bags", string.Empty)
                .Replace("bag", string.Empty)
                .Trim();
    }
}