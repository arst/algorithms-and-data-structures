using System.Linq;
using AlgorithmsAndDataStructures.DataStructures.SuffixArray;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.DataStructures.SuffixArray;

public class NLognSuffixArrayTests
{
    [Fact]
    public void CanConstructSuffixTree()
    {
        var sut = new EfficientSuffixArray("banana");
        var suffixes = sut.Suffixes.ToArray();

        Assert.Equal(5, suffixes[0]);
        Assert.Equal(3, suffixes[1]);
        Assert.Equal(1, suffixes[2]);
        Assert.Equal(0, suffixes[3]);
        Assert.Equal(4, suffixes[4]);
        Assert.Equal(2, suffixes[5]);
    }

    [Fact]
    public void CanFindPattern()
    {
        var sut = new EfficientSuffixArray("banana");

        Assert.True(sut.Contains("nan"));
    }

    [Fact]
    public void CantFindNonExistentPattern()
    {
        var sut = new EfficientSuffixArray("banana");

        Assert.False(sut.Contains("nanan"));
    }
}