using System.Collections.Generic;
using AlgorithmsAndDataStructures.Algorithms.Graph.Common;
using AlgorithmsAndDataStructures.Algorithms.Graph.ShortestPath;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Graph;

public class DijkstraHeapifiedTests
{
    [Fact]
    public void DistanceToItselfIsZero()
    {
        var sut = new DijkstraHeapified();

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
        var sut = new DijkstraHeapified();

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
        var sut = new DijkstraHeapified();

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
        var sut = new DijkstraHeapified();

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
        var sut = new DijkstraHeapified();

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

    [Fact]
    public void BaseLine()
    {
        var sut = new DijkstraHeapified();

        var graph =
            new[]
            {
                new WeightedGraphVertex
                {
                    Edges = new List<WeightedGraphNodeEdge>
                    {
                        new()
                        {
                            To = 1,
                            Weight = 14
                        },
                        new()
                        {
                            To = 2,
                            Weight = 9
                        },
                        new()
                        {
                            To = 3,
                            Weight = 7
                        }
                    }
                },
                new WeightedGraphVertex
                {
                    Edges = new List<WeightedGraphNodeEdge>
                    {
                        new()
                        {
                            To = 4,
                            Weight = 9
                        },
                        new()
                        {
                            To = 2,
                            Weight = 2
                        }
                    }
                },
                new WeightedGraphVertex
                {
                    Edges = new List<WeightedGraphNodeEdge>
                    {
                        new()
                        {
                            To = 3,
                            Weight = 10
                        },
                        new()
                        {
                            To = 5,
                            Weight = 11
                        },
                        new()
                        {
                            To = 1,
                            Weight = 2
                        }
                    }
                },
                new WeightedGraphVertex
                {
                    Edges = new List<WeightedGraphNodeEdge>
                    {
                        new()
                        {
                            To = 5,
                            Weight = 15
                        }
                    }
                },
                new WeightedGraphVertex
                {
                    Edges = new List<WeightedGraphNodeEdge>
                    {
                        new()
                        {
                            To = 5,
                            Weight = 6
                        }
                    }
                },
                new WeightedGraphVertex()
            };

        var (minDistance, path) = sut.MinDistance(graph, 0, 1);

        Assert.Equal(11, minDistance);
        Assert.Equal(0, path[2]);
        Assert.Equal(2, path[1]);
    }
}