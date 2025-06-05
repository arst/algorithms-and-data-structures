using AlgorithmsAndDataStructures.DataStructures.SelfOrganizingList;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.DataStructures.SelfOrginizingList;

public class TransposeSelfOrginizingListTests
{
    [Fact]
    public void RecentAccessedNodeIsMovedToHead()
    {
        var sut = new TransposeSelfOrginizingList<int>();

        for (var i = 0; i < 3; i++) sut.Add(i);

        sut.Get(1);

        Assert.Equal(1, sut.Head.Value);
    }

    [Fact]
    public void LastAccessNodesAreMovedTop()
    {
        var sut = new TransposeSelfOrginizingList<int>();

        for (var i = 0; i < 3; i++) sut.Add(i);

        for (var i = 0; i < 3; i++) sut.Get(i);

        var current = sut.Head;

        for (var i = 1; i < 3; i++)
        {
            Assert.Equal(i, current.Value);
            current = current.Next;
        }

        Assert.Equal(0, current.Value);
    }

    [Fact]
    public void TopAccessedNodeIsAtTheHead()
    {
        var sut = new TransposeSelfOrginizingList<int>();

        for (var i = 0; i < 6; i++) sut.Add(i);

        sut.Get(2);
        sut.Get(3);
        sut.Get(3);
        sut.Get(3);
        sut.Get(2);

        Assert.Equal(3, sut.Head.Value);
        Assert.Equal(2, sut.Head.Next.Value);
    }
}