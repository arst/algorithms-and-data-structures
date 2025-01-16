using AlgorithmsAndDataStructures.DataStructures.BloomFilter;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.DataStructures.BloomFilters;

public class CountingBloomFilterTests
{
    [Fact]
    public void AddIncrementsCountersInFilter()
    {
        var sut = new CountingBloomFilter(100, 3);
        var element = "test";

        sut.Add(element);

        Assert.True(sut.Contains(element));
    }

    [Fact]
    public void RemoveDecrementsCountersInFilter()
    {
        var sut = new CountingBloomFilter(100, 3);
        var element = "test";

        sut.Add(element);
        sut.Remove(element);

        Assert.False(sut.Contains(element));
    }

    [Fact]
    public void ContainsReturnsFalseForNonAddedElement()
    {
        var sut = new CountingBloomFilter(100, 3);
        var element = "test";

        Assert.False(sut.Contains(element));
    }

    [Fact]
    public void AddAndRemoveForMultipleElementsBehaveCorrectly()
    {
        var sut = new CountingBloomFilter(100, 3);
        var elements = new[] { "test1", "test2", "test3" };

        foreach (var element in elements)
        {
            sut.Add(element);
        }

        foreach (var element in elements)
        {
            Assert.True(sut.Contains(element));
        }

        foreach (var element in elements)
        {
            sut.Remove(element);
            Assert.False(sut.Contains(element));
        }
    }

    [Fact]
    public void RemovingNonExistingElementDoesNotCauseErrors()
    {
        var sut = new CountingBloomFilter(100, 3);
        var element = "test";

        sut.Remove(element); // Removing a non-existing element

        Assert.False(sut.Contains(element));
    }
}