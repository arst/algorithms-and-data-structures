using AlgorithmsAndDataStructures.Algorithms.Bitwise;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Bitwise;

public class ModuloByAPowerOfTwoTests
{
    [Fact]
    public void Baseline()
    {
        var sut = new ModuloByAPowerOfTwo();

        for (var i = 0; i < 100; i++)
        for (var j = 2; j < 256; j *= 2)
            Assert.Equal(i % j, sut.Modulo(i, j));
    }
}