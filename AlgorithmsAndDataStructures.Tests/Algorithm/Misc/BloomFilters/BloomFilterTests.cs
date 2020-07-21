using AlgorithmsAndDataStructures.Algorithms.Misc.BloomFilters;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Misc.BloomFilters
{
    public class BloomFilterTests
    {
        private const int HashfunctionsSetSize = 10;

        [Fact]
        public void Positive()
        {
            var sut = new BloomFilter(HashfunctionsSetSize);
            const string input = "test";
            sut.Insert(input);
            Assert.True(sut.IsInBloomFilter(input));
        }

        [Fact]
        public void Negative()
        {
            var sut = new BloomFilter(HashfunctionsSetSize);
            const string input = "test";
            const string notinfilter = "nifi";
            sut.Insert(input);
            Assert.False(sut.IsInBloomFilter(notinfilter));
        }
    }
}
