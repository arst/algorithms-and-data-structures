using AlgorithmsAndDataStructures.Algorithms.Graph.TravelingSalesman;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Graph.TravelingSalesman;

public class NaiveTravelingSalesmanTests
{
    [Fact]
    public void Baseline()
    {
        var sut = new NaiveTravelingSalesman();
        var graph = new int[4][];

        graph[0] = new[] { 0, 10, 15, 20 };
        graph[1] = new[] { 10, 0, 35, 25 };
        graph[2] = new[] { 15, 35, 0, 30 };
        graph[3] = new[] { 20, 25, 30, 0 };

        Assert.Equal(80, sut.GetPath(graph));
    }
}