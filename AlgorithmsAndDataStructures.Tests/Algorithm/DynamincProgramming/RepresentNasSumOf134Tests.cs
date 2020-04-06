using AlgorithmsAndDataStructures.Algorithms.DynamicProgramming;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.DynamincProgramming
{
    public class RepresentNasSumOf134Tests
    {
        [Fact]
        public void BelowBaseCase()
        {
            var sut = new RepresentNasSumOf134();

            Assert.Equal(1, sut.Get(1));
        }

        [Fact]
        public void SimpleRepresentation()
        {
            var sut = new RepresentNasSumOf134();

            Assert.Equal(2, sut.Get(3));
        }

        [Fact]
        public void Baseline()
        {
            var sut = new RepresentNasSumOf134();

            Assert.Equal(4, sut.Get(4));
            Assert.Equal(6, sut.Get(5));
        }
    }
}
