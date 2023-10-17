namespace Nackademin23.Business.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNotNullOrWhiteSpace(this string value) 
        { 
            return !string.IsNullOrWhiteSpace(value);
        }
    }
}
