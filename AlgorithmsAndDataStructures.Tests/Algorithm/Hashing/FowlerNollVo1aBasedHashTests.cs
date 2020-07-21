using AlgorithmsAndDataStructures.Algorithms.Hashing;
using Microsoft.VisualBasic;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Hashing
{
    public class FowlerNollVo1aBasedHashTests
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
