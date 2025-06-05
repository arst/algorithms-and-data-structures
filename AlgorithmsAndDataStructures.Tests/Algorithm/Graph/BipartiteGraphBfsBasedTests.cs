using AlgorithmsAndDataStructures.Algorithms.Graph.Misc;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Graph;

public class BipartiteGraphBfsBasedTests
{
    [Fact]
    public void CycleGraphWithEvenCycle()
    {
        var sut = new BipartiteGraphBfsBased();
        var graph = new int[4][];
        graph[0] = new[] { 0, 1, 0, 1 };
        graph[1] = new[] { 1, 0, 1, 0 };
        graph[2] = new[] { 0, 1, 0, 1 };
        graph[3] = new[] { 1, 0, 1, 0 };

        Assert.True(sut.IsBipartite(graph));
    }

    [Fact]
    public void CycleGraphWithOddCycle()
    {
        var sut = new BipartiteGraphBfsBased();
        var graph = new int[5][];
        graph[0] = new[] { 0, 1, 0, 1, 0 };
        graph[1] = new[] { 1, 0, 1, 0, 0 };
        graph[2] = new[] { 0, 1, 0, 0, 1 };
        graph[3] = new[] { 1, 0, 0, 0, 1 };
        graph[4] = new[] { 0, 0, 1, 1, 0 };

        Assert.False(sut.IsBipartite(graph));
    }
}