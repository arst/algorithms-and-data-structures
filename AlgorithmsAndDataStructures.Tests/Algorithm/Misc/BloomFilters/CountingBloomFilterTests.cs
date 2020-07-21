using AlgorithmsAndDataStructures.Algorithms.Misc.BloomFilters;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Misc.BloomFilters
{
    public class CountingBloomFilterTests
    {
        private const int HashfunctionsSetSize = 10;
        private const int FilterSize = 100000;

        [Fact]
        public void Positive()
        {
            var sut = new CountingBloomFilter(FilterSize, HashfunctionsSetSize);
            const string input = "test";
            sut.Insert(input);
            Assert.True(sut.IsInBloomFilter(input));
        }

        [Fact]
        public void Negative()
        {
            var sut = new CountingBloomFilter(FilterSize, HashfunctionsSetSize);
            const string input = "test";
            const string notinfilter = "nifi";
            sut.Insert(input);
            Assert.False(sut.IsInBloomFilter(notinfilter));
        }

        [Fact]
        public void CanDeleteFromFilter()
        {
            var sut = new CountingBloomFilter(FilterSize, HashfunctionsSetSize);
            const string input = "test";

            sut.Insert(input);
            Assert.True(sut.IsInBloomFilter(input));

            sut.RemoveFromFilter(input);
            Assert.False(sut.IsInBloomFilter(input));
        }
    }
}
