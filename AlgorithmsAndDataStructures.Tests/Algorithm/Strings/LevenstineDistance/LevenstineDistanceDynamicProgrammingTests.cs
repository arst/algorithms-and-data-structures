using AlgorithmsAndDataStructures.Algorithms.Strings.LevenstineDistance;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Strings.LevenstineDistance;

public class LevenstineDistanceDynamicProgrammingTests
{
    [Fact]
    public void EmptyStrings()
    {
        var sut = new LevenstineDistanceDynamicProgramming();

        Assert.Equal(0, sut.GetLevenstineDistance("", ""));
    }

    [Fact]
    public void OneCharacterString()
    {
        var sut = new LevenstineDistanceDynamicProgramming();

        Assert.Equal(1, sut.GetLevenstineDistance("b", "a"));
    }

    [Fact]
    public void OneCharacterStringEquals()
    {
        var sut = new LevenstineDistanceDynamicProgramming();

        Assert.Equal(0, sut.GetLevenstineDistance("a", "a"));
    }

    [Fact]
    public void DifferentLengthStrings()
    {
        var sut = new LevenstineDistanceDynamicProgramming();

        Assert.Equal(2, sut.GetLevenstineDistance("big", "gigo"));
    }

    [Fact]
    public void DifferentLengthStringsInversed()
    {
        var sut = new LevenstineDistanceDynamicProgramming();

        Assert.Equal(2, sut.GetLevenstineDistance("gigo", "big"));
    }

    [Fact]
    public void EqualsStrings()
    {
        var sut = new LevenstineDistanceDynamicProgramming();

        Assert.Equal(0, sut.GetLevenstineDistance("gigo", "gigo"));
    }

    [Fact]
    public void Baseline()
    {
        var sut = new LevenstineDistanceDynamicProgramming();

        Assert.Equal(5, sut.GetLevenstineDistance("benyam", "ephrem"));
        Assert.Equal(3, sut.GetLevenstineDistance("kitten", "sitting"));
    }
}