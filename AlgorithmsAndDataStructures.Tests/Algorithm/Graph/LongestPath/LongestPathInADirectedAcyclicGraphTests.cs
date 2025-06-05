using System.Collections.Generic;
using AlgorithmsAndDataStructures.Algorithms.Graph.Common;
using AlgorithmsAndDataStructures.Algorithms.Graph.LongestPath;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Graph.LongestPath;

public class LongestPathInADirectedAcyclicGraphTests
{
    [Fact]
    public void LongestDistanceInOneVerticeGraphIsZero()
    {
        var sut = new LongestPathInADirectedAcyclicGraph();

        var graph = new[]
        {
            new WeightedGraphVertex()
        };

        Assert.Collection(sut.GetLongestPath(graph), arg => Assert.Equal(0, arg));
    }

    [Fact]
    public void LongestDistanceTwoVerticesGraph()
    {
        var sut = new LongestPathInADirectedAcyclicGraph();

        var graph = new[]
        {
            new WeightedGraphVertex
            {
                Edges = new List<WeightedGraphNodeEdge>
                {
                    new()
                    {
                        From = 0,
                        To = 1,
                        Weight = 10
                    }
                }
            },
            new WeightedGraphVertex()
        };

#pragma warning disable HAA0101 // Array allocation for params parameter
        Assert.Collection(sut.GetLongestPath(graph), arg => Assert.Equal(0, arg), arg => Assert.Equal(10, arg));
#pragma warning restore HAA0101 // Array allocation for params parameter
    }

    [Fact]
    public void Baseline()
    {
        var sut = new LongestPathInADirectedAcyclicGraph();

        var graph = new[]
        {
            new WeightedGraphVertex
            {
                Edges = new List<WeightedGraphNodeEdge>
                {
                    new()
                    {
                        From = 0,
                        To = 1,
                        Weight = 5
                    },
                    new()
                    {
                        From = 0,
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
                        From = 1,
                        To = 3,
                        Weight = 6
                    },
                    new()
                    {
                        From = 1,
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
                        From = 2,
                        To = 4,
                        Weight = 4
                    },
                    new()
                    {
                        From = 2,
                        To = 5,
                        Weight = 2
                    },
                    new()
                    {
                        From = 2,
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
                        From = 3,
                        To = 5,
                        Weight = 1
                    },
                    new()
                    {
                        From = 3,
                        To = 4,
                        Weight = -1
                    }
                }
            },
            new WeightedGraphVertex
            {
                Edges = new List<WeightedGraphNodeEdge>
                {
                    new()
                    {
                        From = 4,
                        To = 5,
                        Weight = 2
                    }
                }
            },
            new WeightedGraphVertex()
        };

        var collection = sut.GetLongestPath(graph);

#pragma warning disable HAA0101 // Array allocation for params parameter
        Assert.Collection(collection,
            arg => Assert.Equal(0, arg),
            arg => Assert.Equal(5, arg),
            arg => Assert.Equal(7, arg),
            arg => Assert.Equal(14, arg),
            arg => Assert.Equal(13, arg),
            arg => Assert.Equal(15, arg));
#pragma warning restore HAA0101 // Array allocation for params parameter
    }
}