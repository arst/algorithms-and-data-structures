using AlgorithmsAndDataStructures.Algorithms.DynamicProgramming;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.DynamincProgramming
{
    public class DigitDynamicProgtammingTests
    {
        [Fact]
        public void OneDigitNumbers()
        {
            var sut = new DigitDynamicProgtamming();

            Assert.Equal(1, sut.GetCount(1, 9, 5));
        }

        [Fact]
        public void OneDigitLimitedRange()
        {
            var sut = new DigitDynamicProgtamming();

            Assert.Equal(0, sut.GetCount(6, 9, 5));
        }

        [Fact]
        public void TwoDigitNumbers()
        {
            var sut = new DigitDynamicProgtamming();

            Assert.Equal(5, sut.GetCount(10, 99, 5));
        }

        [Fact]
        public void TwoAndIneDigitNumbersCombined()
        {
            var sut = new DigitDynamicProgtamming();

            Assert.Equal(6, sut.GetCount(1, 99, 5));
        }

        [Fact]
        public void TwoDigitsLimitedRange()
        {
            var sut = new DigitDynamicProgtamming();

            Assert.Equal(4, sut.GetCount(15, 99, 5));
        }

        [Fact]
        public void ThreeDigitsRange()
        {
            var sut = new DigitDynamicProgtamming();

            Assert.Equal(15, sut.GetCount(100, 999, 5));
        }

        [Fact]
        public void ThreeDigitsLimitedRange()
        {
            var sut = new DigitDynamicProgtamming();

            Assert.Equal(10, sut.GetCount(141, 999, 5));
        }
    }
}
