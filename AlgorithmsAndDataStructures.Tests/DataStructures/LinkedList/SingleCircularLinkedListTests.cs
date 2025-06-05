using System.Linq;
using AlgorithmsAndDataStructures.DataStructures.LinkedList;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.DataStructures.LinkedList;

public class SingleCircularLinkedListTests
{
    [Fact]
    public void OneNodeListHasTheSameRearAndFront()
    {
        var sut = new SinglyCircularLinkedList<int>();

        sut.Enqueue(1);

        Assert.Same(sut.GetFront(), sut.GetRear());
    }

    [Fact]
    public void EmptyListHasNoRearAndFront()
    {
        var sut = new SinglyCircularLinkedList<int>();

        Assert.Null(sut.GetFront());
        Assert.Null(sut.GetRear());
    }

    [Fact]
    public void DequeFromEmptyListDoesntThrowAnError()
    {
        var sut = new SinglyCircularLinkedList<int>();

        Assert.Null(sut.Dequeue());
    }

    [Fact]
    public void Dequeue()
    {
        var sut = new SinglyCircularLinkedList<int>();
        sut.Enqueue(1);
        sut.Enqueue(2);
        sut.Enqueue(3);

        Assert.Equal(1, sut.Dequeue().Value);
    }

    [Fact]
    public void Traverse()
    {
        var sut = new SinglyCircularLinkedList<int>();
        sut.Enqueue(1);
        sut.Enqueue(2);
        sut.Enqueue(3);

        Assert.Equal(3, sut.Traverse().Count);
        Assert.Equal(1, sut.Traverse().First());
        Assert.Equal(2, sut.Traverse().Skip(1).First());
        Assert.Equal(3, sut.Traverse().Skip(2).First());
    }

    [Fact]
    public void DequeueEmptiesSingleNodeList()
    {
        var sut = new SinglyCircularLinkedList<int>();
        sut.Enqueue(1);
        sut.Dequeue();

        Assert.Empty(sut.Traverse());
    }

    [Fact]
    public void DequeueEmptiesList()
    {
        var sut = new SinglyCircularLinkedList<int>();
        sut.Enqueue(1);
        sut.Enqueue(2);
        sut.Enqueue(3);
        sut.Dequeue();
        sut.Dequeue();
        sut.Dequeue();

        Assert.Empty(sut.Traverse());
    }

    [Fact]
    public void DequeueReturnsElementsInOrderReversedToEnqueue()
    {
        var sut = new SinglyCircularLinkedList<int>();
        sut.Enqueue(1);
        sut.Enqueue(2);
        sut.Enqueue(3);
        var first = sut.Dequeue();
        var second = sut.Dequeue();
        var third = sut.Dequeue();

        Assert.Empty(sut.Traverse());
        Assert.Equal(1, first.Value);
        Assert.Equal(2, second.Value);
        Assert.Equal(3, third.Value);
    }
}