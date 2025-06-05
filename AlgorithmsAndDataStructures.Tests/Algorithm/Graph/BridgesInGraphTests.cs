using System;
using AlgorithmsAndDataStructures.Algorithms.Graph.Common;
using AlgorithmsAndDataStructures.Algorithms.Graph.Misc;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Graph;

public class BridgesInGraphTests
{
    [Fact]
    public void EmptyGraphHasNoBridges()
    {
        var sut = new BridgesInGraph();
        var graph = new UndirectedGraph(0);

        Assert.Empty(sut.GetBridges(graph));
    }

    [Fact]
    public void OneVerticeGraphHasNoBridges()
    {
        var sut = new BridgesInGraph();
        var graph = new UndirectedGraph(1);

        Assert.Empty(sut.GetBridges(graph));
    }

    [Fact]
    public void TwoVerticeGraphHasOneBridges()
    {
        var sut = new BridgesInGraph();
        var graph = new UndirectedGraph(2);
        graph.Connect(0, 1);

        Assert.Collection(sut.GetBridges(graph), arg => Assert.Equal(new Tuple<int, int>(0, 1), arg));
    }

    [Fact]
    public void ThreeVerticeGraphHasNoBridges()
    {
        var sut = new BridgesInGraph();
        var graph = new UndirectedGraph(3);
        graph.Connect(0, 1);
        graph.Connect(1, 2);
        graph.Connect(2, 0);

        Assert.Empty(sut.GetBridges(graph));
    }

    [Fact]
    public void ThreeVerticeGraphHasTwoBridges()
    {
        var sut = new BridgesInGraph();
        var graph = new UndirectedGraph(3);
        graph.Connect(0, 1);
        graph.Connect(0, 2);

        Assert.Collection(sut.GetBridges(graph), arg => Assert.Equal(new Tuple<int, int>(0, 1), arg),
            arg => Assert.Equal(new Tuple<int, int>(0, 2), arg));
    }
}