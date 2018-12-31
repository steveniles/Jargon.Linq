using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Jargon.Linq.UnitTests
{
    public class LinqTests
    {
        [Fact]
        public void Batch_Test_Empty()
        {
            IEnumerable<int> source = Enumerable.Empty<int>();
            IEnumerable<IEnumerable<int>> batched = source.Batch(5);

            Assert.NotNull(batched);
            Assert.Empty(batched);
        }

        [Fact]
        public void Batch_Test_Part()
        {
            IEnumerable<int> source = new List<int> { 1, 2, 3, 4 };
            IEnumerable<IEnumerable<int>> batched = source.Batch(5);

            Assert.NotNull(batched);
            Assert.Single(batched);
            IEnumerable<int> first = batched.First();
            Assert.NotNull(first);
            Assert.Equal(4, first.Count());
        }

        [Fact]
        public void Batch_Test_Full()
        {
            IEnumerable<int> source = new List<int> { 1, 2, 3, 4, 5 };
            IEnumerable<IEnumerable<int>> batched = source.Batch(5);

            Assert.NotNull(batched);
            Assert.Single(batched);
            IEnumerable<int> first = batched.First();
            Assert.NotNull(first);
            Assert.Equal(5, first.Count());
        }

        [Fact]
        public void Batch_Test_Overflow()
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
        public void Batch_Test_Infinity()
        {
            IEnumerable<int> getInfiniteSequence()
            {
                int number = 1;
                while (true) yield return number++;
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