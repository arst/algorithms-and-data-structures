using System;
using AlgorithmsAndDataStructures.DataStructures.Queue;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.DataStructures.Queue;

public class ArrayQueueTests
{
    [Fact]
    public void PopFromEmptyQueueThrowsAnException()
    {
        var sut = new ArrayQueue<int>();
        Assert.Throws<ArgumentException>(() => sut.Dequeue());
    }

    [Fact]
    public void QueueStackCorrectlyReportsItsEmptiness()
    {
        var sut = new ArrayQueue<int>();
        Assert.True(sut.IsEmpty);
    }

    [Fact]
    public void QueueStackWorksInFifoOrder()
    {
        var sut = new ArrayQueue<int>(100);
        for (var i = 0; i < 100; i++) sut.Enqueue(i);
        for (var i = 0; i < 100; i++) Assert.Equal(i, sut.Dequeue());
    }

    [Fact]
    public void QueueIsEnptyWhenAllElementsAreRemoved()
    {
        var sut = new ArrayQueue<int>();
        sut.Enqueue(1);
        sut.Enqueue(2);
        Assert.Equal(1, sut.Dequeue());
        Assert.Equal(2, sut.Dequeue());
        Assert.True(sut.IsEmpty);
    }

    [Fact]
    public void QueueWorksInFifoOrderWhenIntermittentEnqueuesAccure()
    {
        var sut = new ArrayQueue<int>();
        sut.Enqueue(1);
        sut.Enqueue(2);
        sut.Enqueue(3);
        Assert.Equal(1, sut.Dequeue());
        sut.Enqueue(4);
        sut.Enqueue(5);
        Assert.Equal(2, sut.Dequeue());
        Assert.Equal(3, sut.Dequeue());
        Assert.Equal(4, sut.Dequeue());
        Assert.Equal(5, sut.Dequeue());
    }
}