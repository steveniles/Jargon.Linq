using System;
using System.Collections;

namespace Jargon.Linq
{
    public static class Check
    {
        public static bool IsNull<T>(this T @object) where T : class => @object == null;

        public static bool IsNull<T>(this T? @object) where T : struct => @object == null;

        public static bool IsNotNull<T>(this T @object) where T : class => @object != null;

        public static bool IsNotNull<T>(this T? @object) where T : struct => @object != null;

        public static bool IsDBNull(this object @object) => @object == DBNull.Value;

        public static bool IsNullOrDBNull(this object @object) => @object == null || @object == DBNull.Value;

        public static T UnDBNull<T>(this T @object) where T : class => @object == DBNull.Value ? null : @object;

        public static bool IsEmpty(this string @string) => @string == string.Empty;

        public static bool IsNotEmpty(this string @string) => @string != string.Empty;

        public static bool IsBlank(this string input) => input.IsNotNull() && !string.IsNullOrEmpty(input) && string.IsNullOrWhiteSpace(input);

        public static bool IsNotBlank(this string input) => string.IsNullOrEmpty(input) || !string.IsNullOrWhiteSpace(input);

        public static bool IsEmpty(this Guid input) => input == Guid.Empty;

        public static bool IsNotEmpty(this Guid input) => input != Guid.Empty;

        public static bool IsEmpty(this IEnumerable collection) => collection?.GetEnumerator().MoveNext() == false;

        public static bool IsNotEmpty(this IEnumerable collection) => collection?.GetEnumerator().MoveNext() == true;
    }
}