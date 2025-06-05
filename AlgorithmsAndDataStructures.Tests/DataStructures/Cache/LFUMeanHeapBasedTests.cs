using System.Globalization;
using AlgorithmsAndDataStructures.DataStructures.Cache;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.DataStructures.Cache;

public class LfuMeanHeapBasedTests
{
    [Fact]
    public void CanInsertEntry()
    {
        var sut = new LfuMeanHeapBased(1);
        sut.Add(1, "Test");
    }

    [Fact]
    public void CanGetEntry()
    {
        var sut = new LfuMeanHeapBased(1);
        sut.Add(1, "Test");

        Assert.Equal("Test", sut.Get(1));
    }

    [Fact]
    public void CanUpdateEntry()
    {
        var sut = new LfuMeanHeapBased(1);
        sut.Add(1, "Test");
        sut.Add(1, "Test1");

        Assert.Equal("Test1", sut.Get(1));
    }

    [Fact]
    public void LeastFrequentlyUsedEntryRemoved()
    {
        var sut = new LfuMeanHeapBased(2);
        sut.Add(1, "Test");
        sut.Add(2, "Test1");
        sut.Get(2);
        sut.Add(3, "Test2");

        Assert.Null(sut.Get(1));
        Assert.Equal("Test1", sut.Get(2));
        Assert.Equal("Test2", sut.Get(3));
    }

    [Fact]
    public void Fuzzy()
    {
        var testCaseSize = 10;
        var sut = new LfuMeanHeapBased(testCaseSize);

        for (var i = 0; i < testCaseSize - 1; i++) sut.Add(i, i.ToString(CultureInfo.InvariantCulture));

        sut.Add(testCaseSize, testCaseSize.ToString(CultureInfo.InvariantCulture));

        for (var i = testCaseSize + 1; i < testCaseSize * 2; i++)
        {
            for (var j = 0; j < testCaseSize; j++) sut.Get(j);

            sut.Add(i, i.ToString(CultureInfo.InvariantCulture));

            Assert.Null(sut.Get(i - 1));
        }
    }
}