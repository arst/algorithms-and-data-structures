using AlgorithmsAndDataStructures.Algorithms.Graph.KCenters;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Graph.KCenters;

public class KCentersGreedyApproximationTests
{
    [Fact]
    public void BaselineForTwoCenters()
    {
        var sut = new KCentersGreedyApproximation();
        var graph = new int[4][];
        graph[0] = new[] { 0, 10, 6, 7 };
        graph[1] = new[] { 10, 0, 8, 5 };
        graph[2] = new[] { 6, 8, 0, 12 };
        graph[3] = new[] { 7, 5, 12, 0 };

#pragma warning disable HAA0101 // Array allocation for params parameter
        Assert.Collection(sut.GetKCenters(graph, 2),
            arg => Assert.Equal(0, arg),
            arg => Assert.Equal(1, arg));
#pragma warning restore HAA0101 // Array allocation for params parameter
    }

    [Fact]
    public void BaselineForThreeCenters()
    {
        var sut = new KCentersGreedyApproximation();
        var graph = new int[4][];
        graph[0] = new[] { 0, 10, 6, 7 };
        graph[1] = new[] { 10, 0, 8, 5 };
        graph[2] = new[] { 6, 8, 0, 12 };
        graph[3] = new[] { 7, 5, 12, 0 };

#pragma warning disable HAA0101 // Array allocation for params parameter
        Assert.Collection(sut.GetKCenters(graph, 3),
            arg => Assert.Equal(0, arg),
            arg => Assert.Equal(1, arg),
            arg => Assert.Equal(2, arg));
#pragma warning restore HAA0101 // Array allocation for params parameter
    }
}