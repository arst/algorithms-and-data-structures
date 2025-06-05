﻿using System.Collections.Generic;
using AlgorithmsAndDataStructures.Algorithms.Graph.Common;
using AlgorithmsAndDataStructures.Algorithms.Graph.Misc;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Graph;

public class TransitiveClosureFloydWarshallTests
{
    [Fact]
    public void OneNodeGraphIsTransitive()
    {
        var sut = new TransitiveClosureFloydWarshall();
        var graph = new[]
        {
            new WeightedGraphVertex()
        };

        var reachabilityMatrix = sut.GetReachabilityMatrix(graph);

        Assert.Collection(reachabilityMatrix, arg => { Assert.True(arg[0]); });
    }

    [Fact]
    public void TwoNodeGraphIsTransitive()
    {
        var sut = new TransitiveClosureFloydWarshall();
        var graph = new[]
        {
            new WeightedGraphVertex
            {
                Edges = new List<WeightedGraphNodeEdge>
                {
                    new()
                    {
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
                        To = 0
                    }
                }
            }
        };

        var reachabilityMatrix = sut.GetReachabilityMatrix(graph);

        Assert.Collection(reachabilityMatrix,
            arg =>
            {
                Assert.True(arg[0]);
                Assert.True(arg[1]);
            },
            arg =>
            {
                Assert.True(arg[0]);
                Assert.True(arg[1]);
            });
    }

    [Fact]
    public void TwoNodeGraphIsNonTransitive()
    {
        var sut = new TransitiveClosureFloydWarshall();
        var graph = new[]
        {
            new WeightedGraphVertex
            {
                Edges = new List<WeightedGraphNodeEdge>
                {
                    new()
                    {
                        To = 1
                    }
                }
            },
            new WeightedGraphVertex()
        };

        var reachabilityMatrix = sut.GetReachabilityMatrix(graph);

        Assert.Collection(reachabilityMatrix,
            arg =>
            {
                Assert.True(arg[0]);
                Assert.True(arg[1]);
            },
            arg =>
            {
                Assert.False(arg[0]);
                Assert.True(arg[1]);
            });
    }

    [Fact]
    public void Baseline()
    {
        var sut = new TransitiveClosureFloydWarshall();
        var graph = new[]
        {
            new WeightedGraphVertex
            {
                Edges = new List<WeightedGraphNodeEdge>
                {
                    new()
                    {
                        To = 1
                    },
                    new()
                    {
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
                        To = 0
                    },
                    new()
                    {
                        To = 3
                    }
                }
            },
            new WeightedGraphVertex()
        };

        var reachabilityMatrix = sut.GetReachabilityMatrix(graph);

        Assert.Collection(reachabilityMatrix,
            arg =>
            {
                Assert.True(arg[0]);
                Assert.True(arg[1]);
                Assert.True(arg[2]);
                Assert.True(arg[3]);
            },
            arg =>
            {
                Assert.True(arg[0]);
                Assert.True(arg[1]);
                Assert.True(arg[2]);
                Assert.True(arg[3]);
            },
            arg =>
            {
                Assert.True(arg[0]);
                Assert.True(arg[1]);
                Assert.True(arg[2]);
                Assert.True(arg[3]);
            },
            arg =>
            {
                Assert.False(arg[0]);
                Assert.False(arg[1]);
                Assert.False(arg[2]);
                Assert.True(arg[3]);
            });
    }
}