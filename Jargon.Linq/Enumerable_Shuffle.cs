using System;
using System.Collections.Generic;
using System.Linq;

namespace Jargon.Linq
{
    public static partial class EnumerableExtensions
    {
        private static readonly Random random = new Random();

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