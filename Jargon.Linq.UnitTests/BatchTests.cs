using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Jargon.Linq.UnitTests
{
    public class BatchTests
    {
        [Fact]
        public void Batch_Handles_Empty()
        {
            IEnumerable<int> source = Enumerable.Empty<int>();

            IEnumerable<IReadOnlyList<int>> batched = source.Batch(5);

            Assert.NotNull(batched);
            Assert.Empty(batched);
        }

        [Fact]
        public void Batch_Handles_Partial()
        {
            IEnumerable<int> source = new List<int> { 1, 2, 3 };

            IEnumerable<IReadOnlyList<int>> batched = source.Batch(5);

            Assert.Equal(new[] { 1, 2, 3 }, batched.Single());
        }

        [Fact]
        public void Batch_Handles_Full()
        {
            IEnumerable<int> source = new List<int> { 1, 2, 3, 4, 5 };

            IEnumerable<IReadOnlyList<int>> batched = source.Batch(5);

            Assert.Equal(new[] { 1, 2, 3, 4, 5 }, batched.Single());
        }

        [Fact]
        public void Batch_Handles_Overflow()
        {
            IEnumerable<int> source = new List<int> { 1, 2, 3, 4, 5, 6, 7 };

            IEnumerable<IReadOnlyList<int>> batched = source.Batch(5);

            Assert.Equal(2, batched.Count());
            Assert.Equal(new int[] { 1, 2, 3, 4, 5 }, batched.First());//detects unneeded int[]?
            Assert.Equal(new int[] { 6, 7 }, batched.ElementAt(1));//check new[] spacing in file
        }

        [Fact]
        public void Batch_Handles_Infinity()
        {
            IEnumerable<int> getInfiniteSequence()
            {
                int number = 0;
                while (true) yield return ++number;
            }

            IEnumerable<int> source = getInfiniteSequence();

            IEnumerable<IReadOnlyList<int>> batched = source.Batch(5);

            Assert.Equal(new int[] { 1, 2, 3, 4, 5 }, batched.First());
            Assert.Equal(new int[] { 6, 7, 8, 9, 10 }, batched.ElementAt(1));
        }
    }
}