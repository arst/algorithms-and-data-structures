using System.Collections.Generic;
using AlgorithmsAndDataStructures.Algorithms.Graph.Common;
using AlgorithmsAndDataStructures.Algorithms.Graph.ShortestPath;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Graph;

public class DijkstraNaiveTests
{
    [Fact]
    public void DistanceToItselfIsZero()
    {
        var sut = new DijkstraNaive();

        var graph =
            new[]
            {
                new WeightedGraphVertex()
            };
        var (minDistance, path) = sut.MinDistance(graph, 0, 0);

        Assert.Equal(0, minDistance);
        Assert.Equal(0, path[0]);
    }

    [Fact]
    public void DistanceToNeighborNodeIsEqualEdgeWeight()
    {
        var sut = new DijkstraNaive();

        var graph =
            new[]
            {
                new WeightedGraphVertex
                {
                    Edges = new List<WeightedGraphNodeEdge>
                    {
                        new()
                        {
                            Weight = 1,
                            To = 1
                        }
                    }
                },
                new WeightedGraphVertex()
            };
        var (minDistance, path) = sut.MinDistance(graph, 0, 1);

        Assert.Equal(1, minDistance);
        Assert.Equal(0, path[1]);
    }

    [Fact]
    public void DistanceToGrandNeighborNodeIsEqualSumOfEdgesWeight()
    {
        var sut = new DijkstraNaive();

        var graph =
            new[]
            {
                new WeightedGraphVertex
                {
                    Edges = new List<WeightedGraphNodeEdge>
                    {
                        new()
                        {
                            Weight = 1,
                            To = 1
                        }
                    }
                },
                new WeightedGraphVertex
                {
                    Edges = new List<WeightedGraphNodeEdge>
                    {
                        new()
                        {
                            Weight = 2,
                            To = 2
                        }
                    }
                },
                new WeightedGraphVertex()
            };

        var (minDistance, path) = sut.MinDistance(graph, 0, 2);
        Assert.Equal(3, minDistance);
        Assert.Equal(0, path[1]);
        Assert.Equal(1, path[2]);
    }

    [Fact]
    public void DistanceIsRecalculatedWhenCheaperPathIsFound()
    {
        var sut = new DijkstraNaive();

        var graph =
            new[]
            {
                new WeightedGraphVertex
                {
                    Edges = new List<WeightedGraphNodeEdge>
                    {
                        new()
                        {
                            Weight = 1,
                            To = 1
                        },
                        new()
                        {
                            Weight = 5,
                            To = 2
                        }
                    }
                },
                new WeightedGraphVertex
                {
                    Edges = new List<WeightedGraphNodeEdge>
                    {
                        new()
                        {
                            Weight = 2,
                            To = 2
                        }
                    }
                },
                new WeightedGraphVertex()
            };
        var (minDistance, path) = sut.MinDistance(graph, 0, 2);

        Assert.Equal(3, minDistance);
        Assert.Equal(1, path[2]);
    }

    [Fact]
    public void DistanceIsCalculateForGraphWithCycles()
    {
        var sut = new DijkstraNaive();

        var graph =
            new[]
            {
                new WeightedGraphVertex
                {
                    Edges = new List<WeightedGraphNodeEdge>
                    {
                        new()
                        {
                            Weight = 1,
                            To = 1
                        },
                        new()
                        {
                            Weight = 5,
                            To = 2
                        }
                    }
                },
                new WeightedGraphVertex
                {
                    Edges = new List<WeightedGraphNodeEdge>
                    {
                        new()
                        {
                            Weight = 2,
                            To = 2
                        }
                    }
                },
                new WeightedGraphVertex
                {
                    Edges = new List<WeightedGraphNodeEdge>
                    {
                        new()
                        {
                            Weight = 2,
                            To = 0
                        }
                    }
                }
            };
        var (minDistance, path) = sut.MinDistance(graph, 0, 2);

        Assert.Equal(3, minDistance);
        Assert.Equal(0, path[1]);
        Assert.Equal(1, path[2]);
    }
}