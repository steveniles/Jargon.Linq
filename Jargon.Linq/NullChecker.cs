namespace Jargon.Linq
{
    public static class NullChecker
    {
        public static bool IsNull<T>(this T input) => input == null;

        public static bool IsNotNull<T>(this T input) => input != null;
    }
}