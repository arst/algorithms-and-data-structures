using AlgorithmsAndDataStructures.Algorithms.Bitwise;
using System;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Bitwise
{
    public class RussianPeasantAlgorithmTests
    {
        [Fact]
        public void Baseline()
        {
            var sut = new RussianPeasantAlgorithm();

            var r = new Random();

            for (int i = 0; i < 1000000; i++)
            {
                var x = r.Next();
                var y = r.Next();

                Assert.Equal(x * y, sut.Multiply(x,y));
            }
        }
    }
}
