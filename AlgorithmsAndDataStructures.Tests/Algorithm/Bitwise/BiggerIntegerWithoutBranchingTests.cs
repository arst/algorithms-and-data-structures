using AlgorithmsAndDataStructures.Algorithm.Bitwise;
using System;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Bitwise
{
    public class BiggerIntegerWithoutBranchingTests
    {
        [Fact]
        public void Baseline()
        {
            var sut = new BiggerIntegerWithoutBranching();
            var r = new Random();

            for (var i = 0; i < 1000000; i++)
            {
                var x = r.Next();
                var y = r.Next();

                Assert.Equal(Math.Max(x,y), sut.GetBigger(x,y));
            }
        }
    }
}
