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

            Assert.Equal(3, batched.Single().Count());
        }

        [Fact]
        public void Batch_Handles_Full()
        {
            IEnumerable<int> source = new List<int> { 1, 2, 3, 4, 5 };

            IEnumerable<IEnumerable<int>> batched = source.Batch(5);

            Assert.Equal(5, batched.Single().Count());
        }

        [Fact]
        public void Batch_Handles_Overflow()
        {
            IEnumerable<int> source = new List<int> { 1, 2, 3, 4, 5, 6, 7 };

            IEnumerable<IEnumerable<int>> batched = source.Batch(5);

            Assert.Equal(2, batched.Count());
            Assert.Equal(5, batched.First().Count());
            Assert.Equal(2, batched.ElementAt(1).Count());
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

            Assert.Equal(1, batched.First().First());
            Assert.Equal(6, batched.ElementAt(1).First());
        }
    }
}