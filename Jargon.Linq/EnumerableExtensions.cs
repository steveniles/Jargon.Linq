﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Jargon.Linq
{
    public static partial class EnumerableExtensions
    {
        private static readonly Random random = new Random();

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

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        {
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