using System.Collections.Generic;
using AlgorithmsAndDataStructures.Algorithms.Graph.Common;
using AlgorithmsAndDataStructures.Algorithms.Graph.ShortestPath;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Graph;

public class BellmanFordTests
{
    [Fact]
    public void DistanceToItselfIsZero()
    {
        var sut = new BellmanFord();

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
        var sut = new BellmanFord();

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
                            To = 1,
                            From = 0
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
        var sut = new BellmanFord();

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
                            To = 1,
                            From = 0
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
                            To = 2,
                            From = 1
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
        var sut = new BellmanFord();

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
                            To = 1,
                            From = 0
                        },
                        new()
                        {
                            Weight = 5,
                            To = 2,
                            From = 0
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
                            To = 2,
                            From = 1
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
        var sut = new BellmanFord();

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
                            To = 1,
                            From = 0
                        },
                        new()
                        {
                            Weight = 5,
                            To = 2,
                            From = 0
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
                            To = 2,
                            From = 1
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
                            To = 0,
                            From = 2
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
        var sut = new BellmanFord();

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
                            Weight = 14,
                            From = 0
                        },
                        new()
                        {
                            To = 2,
                            Weight = 9,
                            From = 0
                        },
                        new()
                        {
                            To = 3,
                            Weight = 7,
                            From = 0
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
                            Weight = 9,
                            From = 1
                        },
                        new()
                        {
                            To = 2,
                            Weight = 2,
                            From = 1
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
                            Weight = 10,
                            From = 2
                        },
                        new()
                        {
                            To = 5,
                            Weight = 11,
                            From = 2
                        },
                        new()
                        {
                            To = 1,
                            Weight = 2,
                            From = 2
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
                            Weight = 15,
                            From = 3
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
                            Weight = 6,
                            From = 4
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