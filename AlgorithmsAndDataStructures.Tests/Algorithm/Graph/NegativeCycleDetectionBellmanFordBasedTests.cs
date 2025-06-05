using System.Collections.Generic;
using AlgorithmsAndDataStructures.Algorithms.Graph.Common;
using AlgorithmsAndDataStructures.Algorithms.Graph.Misc;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Graph;

public class NegativeCycleDetectionBellmanFordBasedTests
{
    [Fact]
    public void OneVertexGraphHasNoNegativeCycles()
    {
        var sut = new NegativeCycleDetectionBellmanFordBased();

        var graph =
            new[]
            {
                new WeightedGraphVertex()
            };

        Assert.False(sut.HasNegativeCycle(graph));
    }

    [Fact]
    public void GraphOfTwoVerticesHasNoNegativeCycles()
    {
        var sut = new NegativeCycleDetectionBellmanFordBased();

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

        Assert.False(sut.HasNegativeCycle(graph));
    }

    [Fact]
    public void DistanceToGrandNeighborNodeIsEqualSumOfEdgesWeight()
    {
        var sut = new NegativeCycleDetectionBellmanFordBased();

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

        Assert.False(sut.HasNegativeCycle(graph));
    }

    [Fact]
    public void DistanceIsRecalculatedWhenCheaperPathIsFound()
    {
        var sut = new NegativeCycleDetectionBellmanFordBased();

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

        Assert.False(sut.HasNegativeCycle(graph));
    }

    [Fact]
    public void DistanceIsCalculateForGraphWithCycles()
    {
        var sut = new NegativeCycleDetectionBellmanFordBased();

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

        Assert.False(sut.HasNegativeCycle(graph));
    }

    [Fact]
    public void BaseLine()
    {
        var sut = new NegativeCycleDetectionBellmanFordBased();

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
                            Weight = 1
                        }
                    }
                },
                new WeightedGraphVertex
                {
                    Edges = new List<WeightedGraphNodeEdge>
                    {
                        new()
                        {
                            To = 2,
                            Weight = 3
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
                            To = 1,
                            Weight = -6
                        }
                    }
                }
            };

        Assert.True(sut.HasNegativeCycle(graph));
    }
}