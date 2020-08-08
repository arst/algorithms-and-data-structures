using AlgorithmsAndDataStructures.Algorithms.Numbers;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Numbers
{
    public class EuclidianAlgorithmForCommonDenominatorTests
    {
        [Fact]
        public void Base()
        {
            var sut = new EuclidianAlgorithmForCommonDenominator();

            Assert.Equal(16, sut.CommonDenominator(32, 48));
            Assert.Equal(16, sut.CommonDenominator(160, 144));
        }

        [Fact]
        public void NoCommonDenomintatorExcept1()
        {
            var sut = new EuclidianAlgorithmForCommonDenominator();

            Assert.Equal(1, sut.CommonDenominator(137, 54));
        }
    }
}
