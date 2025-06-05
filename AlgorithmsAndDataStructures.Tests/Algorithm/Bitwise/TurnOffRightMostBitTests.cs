using AlgorithmsAndDataStructures.Algorithms.Bitwise;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Bitwise;

public class TurnOffRightMostBitTests
{
    [Fact]
    public void Baseline()
    {
        var sut = new TurnOffRightMostBit();

        for (var i = 1; i <= 256; i *= 2) Assert.Equal(0, sut.TurnOff(i));
    }

    [Fact]
    public void OddNumbers()
    {
        var sut = new TurnOffRightMostBit();

        for (var i = 1; i <= 19; i += 2) Assert.Equal(i - 1, sut.TurnOff(i));
    }
}