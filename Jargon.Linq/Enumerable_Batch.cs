using System.Collections.Generic;

namespace Jargon.Linq
{
    public static partial class EnumerableExtensions
    {
        public static IEnumerable<IEnumerable<T>> Batch<T>(this IEnumerable<T> source, int size)
        {
            using (IEnumerator<T> enumerator = source.GetEnumerator())
            {
                while (true)
                {
                    var batch = new List<T>(size);
                    for (int i = 0; i < size; i++)
                    {
                        if (enumerator.MoveNext()) batch.Add(enumerator.Current);
                        else if (batch.Count == 0) yield break;
                    }
                    yield return batch.ToArray();
                }
            }
        }
    }
}