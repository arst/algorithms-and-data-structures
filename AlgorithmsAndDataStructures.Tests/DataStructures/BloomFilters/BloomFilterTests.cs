using AlgorithmsAndDataStructures.DataStructures.BloomFilter;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.DataStructures.BloomFilters;

public class BloomFilterTests
{
    [Fact]
    public void AddAddsElementToFilter()
    {
        var sut = new BloomFilter(100, 3);
        var element = "test";

        sut.Add(element);

        Assert.True(sut.Contains(element));
    }

    [Fact]
    public void ContainsReturnsFalseForNonAddedElement()
    {
        var sut = new BloomFilter(100, 3);
        var element = "test";

        Assert.False(sut.Contains(element));
    }

    [Fact]
    public void ContainsReturnsTrueForMultipleAddedElements()
    {
        var sut = new BloomFilter(100, 3);
        var elements = new[] { "test1", "test2", "test3" };

        foreach (var element in elements) sut.Add(element);

        foreach (var element in elements) Assert.True(sut.Contains(element));
    }
}