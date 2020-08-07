using AlgorithmsAndDataStructures.Algorithms.Bitwise;
using System;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Bitwise
{
    public class ExclusiveOrWithoutXorOperatorTests
    {
        [Fact]
        public void Baseline()
        {
            var sut = new ExclusiveOrWithoutXorOperator();

            var r = new Random();

            for (var i = 0; i < 1000000; i++)
            {
                var x = r.Next();
                var y = r.Next();

                Assert.Equal(x ^ y, sut.Xor(x,y));
            }
            
        }
    }
}
