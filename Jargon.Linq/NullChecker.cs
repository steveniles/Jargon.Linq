namespace Jargon.Linq
{
    public static class NullChecker
    {
        public static bool IsNull<T>(this T @object) where T : class => @object == null;

        public static bool IsNull<T>(this T? @object) where T : struct => @object == null;

        public static bool IsNotNull<T>(this T @object) where T : class => @object != null;

        public static bool IsNotNull<T>(this T? @object) where T : struct => @object != null;

        public static bool IsEmpty(this string input) => input.IsNotNull() && string.IsNullOrEmpty(input);
    }
}