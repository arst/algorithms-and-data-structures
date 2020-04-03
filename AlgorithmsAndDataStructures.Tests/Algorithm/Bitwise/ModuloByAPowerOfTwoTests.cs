using AlgorithmsAndDataStructures.Algorithms.Bitwise;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Bitwise
{
    public class ModuloByAPowerOfTwoTests
    {
        [Fact]
        public void Baseline()
        {
            var sut = new ModuloByAPowerOfTwo();

            for (int i = 0; i < 100; i++)
            {
                for (int j = 2; j < 256; j *= 2)
                {
                    Assert.Equal(i % j, sut.Modulo(i,j));
                }
            }
        }
    }
}
