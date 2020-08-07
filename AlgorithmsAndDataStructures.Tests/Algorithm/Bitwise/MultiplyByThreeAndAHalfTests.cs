using AlgorithmsAndDataStructures.Algorithms.Bitwise;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Bitwise
{
    public class MultiplyByThreeAndAHalfTests
    {
        [Fact]
        public void BaseLine()
        {
            var sut = new MultiplyByThreeAndAHalf();

            for (var i = 0; i <= 1_000_000; i++)
            {
                Assert.Equal((int)(i * 3.5), sut.Multiply(i));
            }
        }
    }
}
