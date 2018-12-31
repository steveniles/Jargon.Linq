using System.Collections.Generic;

namespace Jargon.Linq
{
    public static partial class EnumerableExtensions
    {
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
    }
}