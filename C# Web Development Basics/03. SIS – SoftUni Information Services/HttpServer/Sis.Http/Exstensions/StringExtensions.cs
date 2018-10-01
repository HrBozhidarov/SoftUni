namespace Sis.Http.Exstensions
{
    public static class StringExtensions
    {
        public static string Capitalize(this string line)
        {
            return line[0].ToString().ToUpper() + line.Substring(1).ToLower();
        }
    }
}
