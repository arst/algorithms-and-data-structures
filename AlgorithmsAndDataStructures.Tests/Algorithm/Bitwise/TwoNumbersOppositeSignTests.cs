using AlgorithmsAndDataStructures.Algorithms.Bitwise;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Bitwise
{
    public class TwoNumbersOppositeSignTests
    {
        [Fact]
        public void TheSamePositiveSign()
        {
            var sut = new TwoNumbersOppositeSign();

            Assert.False(sut.IsOppositeSign(1,2));
        }

        [Fact]
        public void TheSameNegativeSign()
        {
            var sut = new TwoNumbersOppositeSign();

            Assert.False(sut.IsOppositeSign(-1, -2));
        }

        [Fact]
        public void DifferentSigns()
        {
            var sut = new TwoNumbersOppositeSign();

            Assert.True(sut.IsOppositeSign(1, -2));
        }

        [Fact]
        public void TwoZeroes()
        {
            var sut = new TwoNumbersOppositeSign();

            Assert.False(sut.IsOppositeSign(0, 0));
        }
    }
}
