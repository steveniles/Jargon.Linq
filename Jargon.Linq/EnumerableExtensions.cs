﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Jargon.Linq
{
    public static partial class EnumerableExtensions
    {
        public static IEnumerable<T> SkipNulls<T>(this IEnumerable<T> source) => source.Where(element => element != null);

        public static IEnumerable<T> Evaluate<T>(this IEnumerable<T> source) => source.ToArray();

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

        public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T> source) => source ?? new List<T>();

        public static IEnumerable<T> With<T, TNullable>(this IEnumerable<T> source, Func<T, TNullable> projection) where TNullable : class => source.Where(arg => projection(arg) != null);

        public static IEnumerable<T> With<T, TNullable>(this IEnumerable<T> source, Func<T, TNullable?> projection) where TNullable : struct => source.Where(arg => projection(arg) != null);
    }
}