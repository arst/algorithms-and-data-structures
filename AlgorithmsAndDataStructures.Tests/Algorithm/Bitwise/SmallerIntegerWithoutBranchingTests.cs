using AlgorithmsAndDataStructures.Algorithm.Bitwise;
using System;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Bitwise
{
    public class SmallerIntegerWithoutBranchingTests
    {
        [Fact]
        public void Baseline()
        {
            var sut = new SmallerIntegerWithoutBranching();
            var r = new Random();

            for (var i = 0; i < 1000000; i++)
            {
                var x = r.Next();
                var y = r.Next();

                Assert.Equal(Math.Min(x,y), sut.GetSmaller(x,y));
            }
        }
    }
}
