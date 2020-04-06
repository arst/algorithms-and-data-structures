using AlgorithmsAndDataStructures.Algorithms.DynamicProgramming;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.DynamincProgramming
{
    public class LongestCommonSubsequenceTests
    {

        [Fact]
        public void OneCharSubsequence()
        {
            var sut = new LongestCommonSubsequence();

            Assert.Equal(1, sut.GetLongestSunsequence("azy", "uzt"));
        }

        [Fact]
        public void TwoCharSubsequence()
        {
            var sut = new LongestCommonSubsequence();

            Assert.Equal(2, sut.GetLongestSunsequence("aab", "azb"));
        }

        [Fact]
        public void Baseline()
        {
            var sut = new LongestCommonSubsequence();

            Assert.Equal(3, sut.GetLongestSunsequence("ABCDGH", "AEDFHR"));
            Assert.Equal(4, sut.GetLongestSunsequence("AGGTAB", "GXTXAYB"));
        }
    }
}
