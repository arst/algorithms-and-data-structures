using System;
using AlgorithmsAndDataStructures.DataStructures.Stack;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.DataStructures.Stack;

public class QueueStackTests
{
    [Fact]
    public void PopFromEmptyStackThrowsAnException()
    {
        var sut = new QueueStack<int>();
        Assert.Throws<ArgumentException>(() => sut.Pop());
    }

    [Fact]
    public void QueueStackCorrectlyReportsItsEmptiness()
    {
        var sut = new QueueStack<int>();
        Assert.True(sut.IsEmpty);
    }

    [Fact]
    public void QueueStackWorksInLifoOrder()
    {
        var sut = new QueueStack<int>();
        for (var i = 0; i < 100; i++) sut.Push(i);
        for (var i = 99; i >= 0; i--) Assert.Equal(i, sut.Pop());
    }

    [Fact]
    public void QueueStackIsEnptyWhenAllElementsAreRemoved()
    {
        var sut = new QueueStack<int>();
        sut.Push(1);
        sut.Push(2);
        Assert.Equal(2, sut.Pop());
        Assert.Equal(1, sut.Pop());
        Assert.True(sut.IsEmpty);
    }

    [Fact]
    public void QueueStackIncreasesCapacityOnDemand()
    {
        var sut = new QueueStack<int>();
        sut.Push(1);
        sut.Push(2);
        Assert.Equal(2, sut.Pop());
        Assert.Equal(1, sut.Pop());
        Assert.True(sut.IsEmpty);
    }

    [Fact]
    public void QueueStackWorksInLifoOrderWhenIntermittentPushesAccures()
    {
        var sut = new QueueStack<int>();
        sut.Push(1);
        sut.Push(2);
        sut.Push(3);
        Assert.Equal(3, sut.Pop());
        sut.Push(4);
        sut.Push(5);
        Assert.Equal(5, sut.Pop());
        Assert.Equal(4, sut.Pop());
        Assert.Equal(2, sut.Pop());
        Assert.Equal(1, sut.Pop());
    }
}