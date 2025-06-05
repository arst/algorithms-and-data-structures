using System.Collections.Generic;
using System.Linq;
using AlgorithmsAndDataStructures.Algorithms.Graph.MinimumSpanningTree.BoruvkasAlgorithm;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Graph;

public class BoruvkasMinimumSpanningTreeTests
{
    [Fact]
    public void MinimumSpanningTreeWeightForOneNodeGraphIsZero()
    {
        var sut = new BoruvkasAlgorithm();


        Assert.Equal(0, sut.GetMinimumSpanningTreeWeight(0, new List<Edge>()));
    }

    [Fact]
    public void MinimumSpanningTreeWeightForNeighborNodeIsEqualEdgeWeight()
    {
        var sut = new BoruvkasAlgorithm();

        var graph =
            new[]
            {
                new Edge
                {
                    Source = 0,
                    Destination = 1,
                    Weight = 1
                }
            };

        Assert.Equal(1, sut.GetMinimumSpanningTreeWeight(2, graph.ToList()));
    }

    [Fact]
    public void MinimumSpanningTreeWeightForGrandNeighborNodeIsEqualSumOfEdgesWeight()
    {
        var sut = new BoruvkasAlgorithm();

        var graph =
            new[]
            {
                new Edge
                {
                    Source = 0,
                    Destination = 1,
                    Weight = 1
                },
                new Edge
                {
                    Source = 1,
                    Destination = 2,
                    Weight = 2
                }
            };

        Assert.Equal(3, sut.GetMinimumSpanningTreeWeight(3, graph.ToList()));
    }

    [Fact]
    public void NodeDiscardedWhenCycleIsFound()
    {
        var sut = new BoruvkasAlgorithm();

        var graph =
            new[]
            {
                new Edge
                {
                    Source = 0,
                    Destination = 1,
                    Weight = 1
                },
                new Edge
                {
                    Source = 0,
                    Destination = 2,
                    Weight = 5
                },
                new Edge
                {
                    Source = 1,
                    Destination = 2,
                    Weight = 2
                }
            };

        Assert.Equal(3, sut.GetMinimumSpanningTreeWeight(3, graph.ToList()));
    }

    [Fact]
    public void MinimumSpanningTreeWeightIsCalculatedForGraphWithCycle()
    {
        var sut = new BoruvkasAlgorithm();

        var graph =
            new[]
            {
                new Edge
                {
                    Destination = 1,
                    Source = 0,
                    Weight = 1
                },
                new Edge
                {
                    Destination = 2,
                    Source = 0,
                    Weight = 5
                },
                new Edge
                {
                    Source = 1,
                    Destination = 2,
                    Weight = 2
                },
                new Edge
                {
                    Source = 2,
                    Destination = 0,
                    Weight = 2
                }
            };


        Assert.Equal(3, sut.GetMinimumSpanningTreeWeight(3, graph.ToList()));
    }

    [Fact]
    public void BaseLine()
    {
        var sut = new BoruvkasAlgorithm();


        var graph = new List<Edge>
        {
            new() { Source = 0, Destination = 1, Weight = 14 },
            new() { Source = 0, Destination = 2, Weight = 9 },
            new() { Source = 0, Destination = 3, Weight = 7 },
            new() { Source = 1, Destination = 4, Weight = 9 },
            new() { Source = 1, Destination = 2, Weight = 2 },
            new() { Source = 2, Destination = 3, Weight = 10 },
            new() { Source = 2, Destination = 5, Weight = 11 },
            new() { Source = 3, Destination = 5, Weight = 15 },
            new() { Source = 4, Destination = 5, Weight = 6 }
        };

        Assert.Equal(33, sut.GetMinimumSpanningTreeWeight(6, graph));
    }
}