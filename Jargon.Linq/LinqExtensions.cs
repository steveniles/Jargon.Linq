﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Jargon.Linq
{
    public static class LinqExtensions
    {
        public static bool IsNull<T>(this T input) => input == null;

        public static bool IsNotNull<T>(this T input) => input != null;

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
        {//Probably wrong, returns nested empty output on empty input
            using (IEnumerator<T> enumerator = source.GetEnumerator())
            {
                var finished = false;
                while (!finished)
                {
                    var bucket = new T[bucketSize];
                    for (var i = 0; i < bucketSize; i++)
                    {
                        if (enumerator.MoveNext())
                        {
                            bucket[i] = enumerator.Current;
                        }
                        else
                        {
                            finished = true;
                        }
                    }
                    yield return bucket;
                }
            }
        }
    }
}