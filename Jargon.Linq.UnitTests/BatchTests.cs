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

            IEnumerable<IEnumerable<int>> batched = source.Batch(5);

            Assert.NotNull(batched);
            Assert.Empty(batched);
        }

        [Fact]
        public void Batch_Handles_Partial()
        {
            IEnumerable<int> source = new List<int> { 1, 2, 3 };

            IEnumerable<IEnumerable<int>> batched = source.Batch(5);

            Assert.NotNull(batched);
            Assert.Single(batched);
            IEnumerable<int> batch = batched.Single();
            Assert.NotNull(batch);
            Assert.Equal(3, batch.Count());
        }

        [Fact]
        public void Batch_Handles_Full()
        {
            IEnumerable<int> source = new List<int> { 1, 2, 3, 4, 5 };

            IEnumerable<IEnumerable<int>> batched = source.Batch(5);

            Assert.NotNull(batched);
            Assert.Single(batched);
            IEnumerable<int> batch = batched.Single();
            Assert.NotNull(batch);
            Assert.Equal(5, batch.Count());
        }

        [Fact]
        public void Batch_Handles_Remainder()
        {
            IEnumerable<int> source = new List<int> { 1, 2, 3, 4, 5, 6, 7 };

            IEnumerable<IEnumerable<int>> batched = source.Batch(5);

            Assert.NotNull(batched);
            Assert.Equal(2, batched.Count());
            IEnumerable<int> first = batched.First();
            Assert.NotNull(first);
            Assert.Equal(5, first.Count());
            IEnumerable<int> second = batched.ElementAt(1);
            Assert.NotNull(second);
            Assert.Equal(2, second.Count());
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
            
            IEnumerable<IEnumerable<int>> batched = source.Batch(5);

            Assert.NotNull(batched);
            IEnumerable<int> first = batched.First();
            Assert.NotNull(first);
            Assert.Equal(5, first.Count());
            Assert.Equal(1, first.First());
            IEnumerable<int> second = batched.ElementAt(1);
            Assert.NotNull(second);
            Assert.Equal(5, second.Count());
            Assert.Equal(6, second.First());
        }
    }
}