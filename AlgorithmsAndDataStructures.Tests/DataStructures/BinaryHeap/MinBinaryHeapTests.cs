using System;
using AlgorithmsAndDataStructures.DataStructures.BinaryHeaps;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.DataStructures.BinaryHeap;

public class MinBinaryHeapTests
{
    [Fact]
    public void TopElementIsInsertedWhenHeapIsEmpty()
    {
        var sut = new MinBinaryHeap<int>();
        sut.Insert(10);
        Assert.Equal(10, sut.GetTop());
    }

    [Fact]
    public void MinValueElementIsOnTheTop()
    {
        var sut = new MinBinaryHeap<int>();
        sut.Insert(20);
        sut.Insert(10);

        Assert.Equal(10, sut.GetTop());
        Assert.Equal(20, sut.GetTop());
    }

    // TODO: Replace with property based testing.

    [Fact]
    public void MinValueElementIsAlwaysOnTheTop()
    {
        var sut = new MinBinaryHeap<int>(1001);
        var randomValues = new int[1000];
        var random = new Random();

        for (var i = 0; i < 1000; i++)
        {
            randomValues[i] = random.Next(10000);
            sut.Insert(randomValues[i]);
        }

        Array.Sort(randomValues);

        for (var i = 0; i < 1000; i++) Assert.Equal(randomValues[i], sut.GetTop());
    }
}