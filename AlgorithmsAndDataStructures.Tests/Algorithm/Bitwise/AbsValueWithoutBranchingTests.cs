using AlgorithmsAndDataStructures.Algorithms.Bitwise;
using System;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Bitwise
{
    public class AbsValueWithoutBranchingTests
    {
        [Fact]
        public void Baseline()
        {
            var sut = new AbsValueWithoutBranching();

            var r = new Random();

            for (var i = 0; i < 1000000; i++)
            {
                var x = r.Next(-100000, 1000000);

                Assert.Equal(Math.Abs(x), sut.Abs(x));
            }
        }
    }
}
