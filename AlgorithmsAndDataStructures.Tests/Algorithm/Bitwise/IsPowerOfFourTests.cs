using AlgorithmsAndDataStructures.Algorithms.Bitwise;
using System;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Bitwise
{
    public class IsPowerOfFourTests
    {
        [Fact]
        public void PowersOf4()
        {
            var sut = new IsPowerOfFour();

            for (var i = 4; i < 1048576; i *= 4)
            {
                Assert.True(sut.IsPower(i));
            }
        }

        [Fact]
        public void Baseline()
        {
            var sut = new IsPowerOfFour();

            for (var i = 0; i < 1048576; i++)
            {
                Assert.Equal(Math.Abs(Math.Log(i, 4) % 1) < 0.001, sut.IsPower(i));
            }
        }
    }
}
