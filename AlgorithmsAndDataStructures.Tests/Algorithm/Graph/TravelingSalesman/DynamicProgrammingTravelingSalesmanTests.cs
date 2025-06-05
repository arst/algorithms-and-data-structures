using AlgorithmsAndDataStructures.Algorithms.Graph.TravelingSalesman;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Graph.TravelingSalesman;

public class DynamicProgrammingTravelingSalesmanTests
{
    [Fact]
    public void Baseline()
    {
        var sut = new DynamicProgrammingTravelingSalesman();
        var graph = new int[4][];

        graph[0] = new[] { 0, 10, 15, 20 };
        graph[1] = new[] { 10, 0, 35, 25 };
        graph[2] = new[] { 15, 35, 0, 30 };
        graph[3] = new[] { 20, 25, 30, 0 };

        Assert.Equal(80, sut.GetPath(graph));
    }

    [Fact]
    public void Baseline2()
    {
        var sut = new DynamicProgrammingTravelingSalesman();
        var graph = new int[4][];

        graph[0] = new[] { 0, 20, 42, 25 };
        graph[1] = new[] { 20, 0, 30, 34 };
        graph[2] = new[] { 42, 30, 0, 10 };
        graph[3] = new[] { 25, 34, 10, 0 };

        Assert.Equal(85, sut.GetPath(graph));
    }
}