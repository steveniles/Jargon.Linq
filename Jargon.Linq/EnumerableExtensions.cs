using System;
using System.Collections.Generic;
using System.Linq;

namespace Jargon.Linq
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Evaluate<T>(this IEnumerable<T> source) => source.ToArray();

        public static IEnumerable<T> SkipNulls<T>(this IEnumerable<T> source) => source.Where(arg => arg != null);

        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T> action) => source.Select(arg =>
        {
            action(arg);
            return arg;
        });

        public static IEnumerable<T> Mutate<T>(this IEnumerable<T> source, Action<T> action) => source.Select(arg =>
        {
            action(arg);
            return arg;
        });

        public static IEnumerable<IEnumerable<T>> Batch<T>(this IEnumerable<T> source, int bucketSize)
        {
            using (IEnumerator<T> enumerator = source.GetEnumerator())
            {
                while (true)
                {
                    var bucket = new List<T>(bucketSize);
                    for (int i = 0; i < bucketSize; i++)
                    {
                        if (enumerator.MoveNext()) bucket.Add(enumerator.Current);
                        else if (bucket.Count == 0) yield break;
                    }
                    yield return bucket.ToArray();
                }
            }
        }

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        {
            var random = new Random();
            T[] array = source.ToArray();
            for (int i = 0; i < array.Length; i++)
            {
                int randomPick = random.Next(array.Length - i) + i;
                T temp = array[i];
                array[i] = array[randomPick];
                array[randomPick] = temp;
            }
            return array;
        }
    }
}