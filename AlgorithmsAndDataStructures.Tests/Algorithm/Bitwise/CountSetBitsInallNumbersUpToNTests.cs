using AlgorithmsAndDataStructures.Algorithms.Bitwise;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Bitwise;

public class CountSetBitsInAllNumbersUpToNTests
{
    [Fact]
    public void OneBitSet()
    {
        var sut = new CountSetBitsInAllNumbersUpToN();
        Assert.Equal(1, sut.Count(2));
    }

    [Fact]
    public void TwoBitsSet()
    {
        var sut = new CountSetBitsInAllNumbersUpToN();
        Assert.Equal(2, sut.Count(3));
    }

    [Fact]
    public void FourBitsSet()
    {
        var sut = new CountSetBitsInAllNumbersUpToN();
        Assert.Equal(4, sut.Count(4));
    }
}