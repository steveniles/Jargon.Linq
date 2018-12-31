using System;
using System.Collections.Generic;
using System.Linq;

namespace Jargon.Linq
{
    public static partial class EnumerableExtensions
    {
        public static IEnumerable<T> SkipNulls<T>(this IEnumerable<T> source) => source.Where(element => element != null);

        public static IEnumerable<T> Evaluate<T>(this IEnumerable<T> source) => Array.AsReadOnly(source.ToArray());

        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T> action) => source.Select(element =>
        {
            action(element);
            return element;
        });

        public static IEnumerable<T> Mutate<T>(this IEnumerable<T> source, Action<T> action) => source.Select(element =>
        {
            action(element);
            return element;
        });
    }
}