using AlgorithmsAndDataStructures.Algorithms.Graph.Common;
using AlgorithmsAndDataStructures.Algorithms.Graph.Misc;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Graph;

public class TarjansAlgorithmForBiconnectedComponentsTests
{
    [Fact]
    public void EmptyGraphHashNoBiconnectedComponents()
    {
        var sut = new TarjansAlgorithmForBiconnectedComponents();
        var biconnectedComponents = sut.GetBiconnectedComponents(new UndirectedGraph(0));
        Assert.Empty(biconnectedComponents);
    }

    [Fact]
    public void OneVerticeGraphHashOneBiconnectedComponent()
    {
        var sut = new TarjansAlgorithmForBiconnectedComponents();
        var biconnectedComponents = sut.GetBiconnectedComponents(new UndirectedGraph(1));
        Assert.Collection(biconnectedComponents, arg => { Assert.Collection(arg, arg => Assert.Equal(0, arg)); });
    }

    [Fact]
    public void TwoVerticeGraphHashHashOneBiconnectedComponent()
    {
        var sut = new TarjansAlgorithmForBiconnectedComponents();
        var graph = new UndirectedGraph(2);
        graph.Connect(0, 1);
        var biconnectedComponents = sut.GetBiconnectedComponents(graph);
        Assert.Collection(biconnectedComponents,
            arg => { Assert.Collection(arg, arg => Assert.Equal(1, arg), arg => Assert.Equal(0, arg)); });
    }

    [Fact]
    public void ThreeVerticeGraphHashHashTwoBiconnectedComponent()
    {
        var sut = new TarjansAlgorithmForBiconnectedComponents();
        var graph = new UndirectedGraph(3);
        graph.Connect(0, 1);
        graph.Connect(1, 2);
        var biconnectedComponents = sut.GetBiconnectedComponents(graph);
        Assert.Collection(biconnectedComponents,
            arg => { Assert.Collection(arg, arg => Assert.Equal(1, arg), arg => Assert.Equal(2, arg)); },
            arg => { Assert.Collection(arg, arg => Assert.Equal(1, arg), arg => Assert.Equal(0, arg)); });
    }

    [Fact]
    public void LinedUpGraph()
    {
        var sut = new TarjansAlgorithmForBiconnectedComponents();
        var graph = new UndirectedGraph(4);
        graph.Connect(0, 1);
        graph.Connect(1, 2);
        graph.Connect(2, 3);
        var biconnectedComponents = sut.GetBiconnectedComponents(graph);
        Assert.Collection(biconnectedComponents,
            arg => { Assert.Collection(arg, arg => Assert.Equal(2, arg), arg => Assert.Equal(3, arg)); },
            arg => { Assert.Collection(arg, arg => Assert.Equal(1, arg), arg => Assert.Equal(2, arg)); },
            arg => { Assert.Collection(arg, arg => Assert.Equal(1, arg), arg => Assert.Equal(0, arg)); });
    }
}