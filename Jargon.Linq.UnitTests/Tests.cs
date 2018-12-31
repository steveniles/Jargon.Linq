using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Jargon.Linq.UnitTests
{
    public class Tests
    {
        [Fact]
        public void Test()
        {
            var source = new List<int> { 1, 2, 3, 4, 5 };

            List<int> shuffled = source.Shuffle().ToList();

            Assert.Equal(1, source[0]);
            Assert.Equal(2, source[1]);
            Assert.Equal(3, source[2]);
            Assert.Equal(4, source[3]);
            Assert.Equal(5, source[4]);

            Assert.NotEqual(1, shuffled[0]);
            Assert.NotEqual(2, shuffled[1]);
            Assert.NotEqual(3, shuffled[2]);
            Assert.NotEqual(4, shuffled[3]);
            Assert.NotEqual(5, shuffled[4]);
        }
    }
}