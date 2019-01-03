using System.Collections.Generic;
using System.Linq;

namespace Jargon.Linq
{
    public static partial class EnumerableExtensions
    {
        public static T Self<T>(this T self) => self;
        public static IEnumerable<T> Flatten<T>(this IEnumerable<IEnumerable<T>> source) => source.SelectMany(Self);
    }
}