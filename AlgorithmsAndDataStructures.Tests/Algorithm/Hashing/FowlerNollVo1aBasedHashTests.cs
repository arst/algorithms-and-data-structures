using AlgorithmsAndDataStructures.Algorithms.Hashing;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Hashing
{
    public class FowlerNollVo1ABasedHashTests
    {
        [Fact]
        public void DifferentHashForDifferentSeedValue()
        {
            var sut = new FowlerNollVo1aBasedHash();
            const string input = "test";

            Assert.NotEqual(sut.GetHash(input, 1), sut.GetHash(input, 2));
        }
    }
}
