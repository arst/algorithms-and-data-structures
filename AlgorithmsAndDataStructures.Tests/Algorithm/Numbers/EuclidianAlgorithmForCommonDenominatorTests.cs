using AlgorithmsAndDataStructures.Algorithms;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Numbers
{
    public class EuclidianAlgorithmForCommonDenominatorTests
    {
        [Fact]
        public void Base()
        {
            var sut = new EuclidianAlgorithmForCommonDenominator();

            Assert.Equal(16, sut.CommnDenominator(32, 48));
            Assert.Equal(16, sut.CommnDenominator(160, 144));
        }

        [Fact]
        public void NoCommonDenomintatorExcept1()
        {
            var sut = new EuclidianAlgorithmForCommonDenominator();

            Assert.Equal(1, sut.CommnDenominator(137, 54));
        }
    }
}
