using System.Collections.Generic;
using System.Linq;

namespace Jargon.Linq
{
    public static class LinqExtensions
    {
        public static bool IsNull<T>(this T input) => input == null;

        public static bool IsNotNull<T>(this T input) => input != null;

        public static IEnumerable<T> SkipNulls<T>(this IEnumerable<T> source) => source.Where(arg => arg != null);
    }
}