using System.Collections.Generic;
using AlgorithmsAndDataStructures.Algorithms.Graph.Search;
using AlgorithmsAndDataStructures.DataStructures.Graph;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Graph;

public class DepthFirstSearchTests
{
    [Fact]
    public void OneNodeGraph()
    {
        var sut = new DepthFirstSearch();
        var graph = new[]
        {
            new GraphVertex<int>
            {
                Value = 1
            }
        };
        Assert.Collection(sut.Traverse(graph), arg => Assert.Equal(1, arg));
    }

    [Fact]
    public void TwoNodesGraph()
    {
        var sut = new DepthFirstSearch();
        var graph = new[]
        {
            new GraphVertex<int>
            {
                Value = 1,
                AdjacentVertices = new List<int>
                {
                    1
                }
            },
            new GraphVertex<int>
            {
                Value = 2
            }
        };
        Assert.Collection(sut.Traverse(graph), arg => Assert.Equal(1, arg), arg => Assert.Equal(2, arg));
    }

    [Fact]
    public void TwoNodesGraphWithCircularDependency()
    {
        var sut = new DepthFirstSearch();
        var graph = new[]
        {
            new GraphVertex<int>
            {
                Value = 1,
                AdjacentVertices = new List<int>
                {
                    1
                }
            },
            new GraphVertex<int>
            {
                Value = 2,
                AdjacentVertices = new List<int>
                {
                    0
                }
            }
        };
        Assert.Collection(sut.Traverse(graph), arg => Assert.Equal(1, arg), arg => Assert.Equal(2, arg));
    }

    [Fact]
    public void OneNodeGraphNonRecursive()
    {
        var sut = new DepthFirstSearch();
        var graph = new[]
        {
            new GraphVertex<int>
            {
                Value = 1
            }
        };
        Assert.Collection(sut.TraverseNonRecursive(graph), arg => Assert.Equal(1, arg));
    }

    [Fact]
    public void TwoNodesGraphNonRecursive()
    {
        var sut = new DepthFirstSearch();
        var graph = new[]
        {
            new GraphVertex<int>
            {
                Value = 1,
                AdjacentVertices = new List<int>
                {
                    1
                }
            },
            new GraphVertex<int>
            {
                Value = 2
            }
        };
        Assert.Collection(sut.TraverseNonRecursive(graph), arg => Assert.Equal(1, arg), arg => Assert.Equal(2, arg));
    }

    [Fact]
    public void TwoNodesGraphWithCircularDependencyNonRecursive()
    {
        var sut = new DepthFirstSearch();
        var graph = new[]
        {
            new GraphVertex<int>
            {
                Value = 1,
                AdjacentVertices = new List<int>
                {
                    1
                }
            },
            new GraphVertex<int>
            {
                Value = 2,
                AdjacentVertices = new List<int>
                {
                    0
                }
            }
        };
        Assert.Collection(sut.TraverseNonRecursive(graph), arg => Assert.Equal(1, arg), arg => Assert.Equal(2, arg));
    }

    [Fact]
    public void DepthFirstSearchTraversal()
    {
        var sut = new DepthFirstSearch();
        var graph = new[]
        {
            new GraphVertex<int>
            {
                Value = 1,
                AdjacentVertices = new List<int>
                {
                    1, 2
                }
            },
            new GraphVertex<int>
            {
                Value = 2,
                AdjacentVertices = new List<int>
                {
                    3
                }
            },
            new GraphVertex<int>
            {
                Value = 3,
                AdjacentVertices = new List<int>()
            },
            new GraphVertex<int>
            {
                Value = 4,
                AdjacentVertices = new List<int>()
            }
        };
        Assert.Collection(sut.Traverse(graph),
            arg => Assert.Equal(1, arg),
            arg => Assert.Equal(2, arg),
            arg => Assert.Equal(4, arg),
            arg => Assert.Equal(3, arg));
    }

    [Fact]
    public void DepthFirstSearchTraversalNonRecursive()
    {
        var sut = new DepthFirstSearch();
        var graph = new[]
        {
            new GraphVertex<int>
            {
                Value = 1,
                AdjacentVertices = new List<int>
                {
                    1, 2
                }
            },
            new GraphVertex<int>
            {
                Value = 2,
                AdjacentVertices = new List<int>
                {
                    3
                }
            },
            new GraphVertex<int>
            {
                Value = 3,
                AdjacentVertices = new List<int>()
            },
            new GraphVertex<int>
            {
                Value = 4,
                AdjacentVertices = new List<int>()
            }
        };
        Assert.Collection(sut.TraverseNonRecursive(graph),
            arg => Assert.Equal(1, arg),
            arg => Assert.Equal(2, arg),
            arg => Assert.Equal(4, arg),
            arg => Assert.Equal(3, arg));
    }
}