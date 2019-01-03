using System;

namespace Jargon.Linq
{
    public static class NullChecker
    {
        public static bool IsNull<T>(this T @object) where T : class => @object == null;

        public static bool IsNull<T>(this T? @object) where T : struct => @object == null;

        public static bool IsNotNull<T>(this T @object) where T : class => @object != null;

        public static bool IsNotNull<T>(this T? @object) where T : struct => @object != null;

        public static bool IsEmpty(this string input) => input.IsNotNull() && string.IsNullOrEmpty(input);
        public static bool IsNotEmpty(this string input) => input.IsNull() || !string.IsNullOrEmpty(input);

        public static bool IsBlank(this string input) => input.IsNotNull() && !string.IsNullOrEmpty(input) && string.IsNullOrWhiteSpace(input);
        public static bool IsNotBlank(this string input) => string.IsNullOrEmpty(input) || !string.IsNullOrWhiteSpace(input);

        public static bool IsEmpty(this Guid input) => input == Guid.Empty;
        public static bool IsNotEmpty(this Guid input) => input != Guid.Empty;
    }
}