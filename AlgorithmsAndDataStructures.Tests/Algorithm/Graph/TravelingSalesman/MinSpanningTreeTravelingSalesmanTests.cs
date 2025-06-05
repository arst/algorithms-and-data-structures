using AlgorithmsAndDataStructures.Algorithms.Graph.TravelingSalesman;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Graph.TravelingSalesman;

public class MinSpanningTreeTravelingSalesmanTests
{
    [Fact]
    public void Baseline()
    {
        var sut = new MinSpanningTreeTravelingSalesman();
        var graph = new int[4][];

        graph[0] = new[] { 0, 10, 15, 20 };
        graph[1] = new[] { 10, 0, 35, 25 };
        graph[2] = new[] { 15, 35, 0, 30 };
        graph[3] = new[] { 20, 25, 30, 0 };

        Assert.Equal(95, sut.Travel(graph));
    }

    [Fact]
    public void Baseline1()
    {
        var sut = new MinSpanningTreeTravelingSalesman();
        var graph = new int[5][];

        graph[0] = new[] { 0, 30, 25, 10, 22 };
        graph[1] = new[] { 30, 0, 40, 25, 35 };
        graph[2] = new[] { 25, 40, 0, 20, 10 };
        graph[3] = new[] { 10, 25, 20, 0, 15 };
        graph[4] = new[] { 22, 35, 10, 15, 0 };

        Assert.Equal(105, sut.Travel(graph));
    }
}