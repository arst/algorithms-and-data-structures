using AlgorithmsAndDataStructures.Algorithms.Graph;
using AlgorithmsAndDataStructures.Algorithms.Graph.Search;
using AlgorithmsAndDataStructures.DataStructures.Graph;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Graph
{
    public class DepthFirstSearchTests
    {
        [Fact]
        public void OneNodeGraph()
        {
            var sut = new DepthFirstSearch();
            var graph = new[]
                {
                    new GraphNode<int>
                    {
                        Value = 1
                    },
                };
            Assert.Collection(sut.Traverse(graph), arg => Assert.Equal(1, arg));
        }

        [Fact]
        public void TwoNodesGraph()
        {
            var sut = new DepthFirstSearch();
            var graph = new[]
                {
                    new GraphNode<int>
                    {
                        Value = 1,
                        AdjacentNodes = new System.Collections.Generic.List<int>
                        { 
                            1
                        }
                    },
                    new GraphNode<int>
                    {
                        Value = 2
                    },
                };
            Assert.Collection(sut.Traverse(graph), arg => Assert.Equal(1, arg), arg => Assert.Equal(2, arg));
        }

        [Fact]
        public void TwoNodesGraphWithCircularDependency()
        {
            var sut = new DepthFirstSearch();
            var graph = new[]
                {
                    new GraphNode<int>
                    {
                        Value = 1,
                        AdjacentNodes = new System.Collections.Generic.List<int>
                        {
                            1
                        }
                    },
                    new GraphNode<int>
                    {
                        Value = 2,
                        AdjacentNodes = new System.Collections.Generic.List<int>
                        {
                            0
                        }
                    },
                };
            Assert.Collection(sut.Traverse(graph), arg => Assert.Equal(1, arg), arg => Assert.Equal(2, arg));
        }

        [Fact]
        public void OneNodeGraphNonRecursive()
        {
            var sut = new DepthFirstSearch();
            var graph = new[]
                {
                    new GraphNode<int>
                    {
                        Value = 1
                    },
                };
            Assert.Collection(sut.TraverseNonRecursive(graph), arg => Assert.Equal(1, arg));
        }

        [Fact]
        public void TwoNodesGraphNonRecursive()
        {
            var sut = new DepthFirstSearch();
            var graph = new[]
                {
                    new GraphNode<int>
                    {
                        Value = 1,
                        AdjacentNodes = new System.Collections.Generic.List<int>
                        {
                            1
                        }
                    },
                    new GraphNode<int>
                    {
                        Value = 2
                    },
                };
            Assert.Collection(sut.TraverseNonRecursive(graph), arg => Assert.Equal(1, arg), arg => Assert.Equal(2, arg));
        }

        [Fact]
        public void TwoNodesGraphWithCircularDependencyNonRecursive()
        {
            var sut = new DepthFirstSearch();
            var graph = new[]
                {
                    new GraphNode<int>
                    {
                        Value = 1,
                        AdjacentNodes = new System.Collections.Generic.List<int>
                        {
                            1
                        }
                    },
                    new GraphNode<int>
                    {
                        Value = 2,
                        AdjacentNodes = new System.Collections.Generic.List<int>
                        {
                            0
                        }
                    },
                };
            Assert.Collection(sut.TraverseNonRecursive(graph), arg => Assert.Equal(1, arg), arg => Assert.Equal(2, arg));
        }

        [Fact]
        public void DepthFirstSearchTraversal()
        {
            var sut = new DepthFirstSearch();
            var graph = new[]
                {
                    new GraphNode<int>
                    {
                        Value = 1,
                        AdjacentNodes = new System.Collections.Generic.List<int>
                        {
                            1,2
                        }
                    },
                    new GraphNode<int>
                    {
                        Value = 2,
                        AdjacentNodes = new System.Collections.Generic.List<int>
                        {
                            3
                        }
                    },
                    new GraphNode<int>
                    {
                        Value = 3,
                        AdjacentNodes = new System.Collections.Generic.List<int>()
                    },
                    new GraphNode<int>
                    {
                        Value = 4,
                        AdjacentNodes = new System.Collections.Generic.List<int>()
                    },
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
                    new GraphNode<int>
                    {
                        Value = 1,
                        AdjacentNodes = new System.Collections.Generic.List<int>
                        {
                            1,2
                        }
                    },
                    new GraphNode<int>
                    {
                        Value = 2,
                        AdjacentNodes = new System.Collections.Generic.List<int>
                        {
                            3
                        }
                    },
                    new GraphNode<int>
                    {
                        Value = 3,
                        AdjacentNodes = new System.Collections.Generic.List<int>()
                    },
                    new GraphNode<int>
                    {
                        Value = 4,
                        AdjacentNodes = new System.Collections.Generic.List<int>()
                    },
                };
            Assert.Collection(sut.TraverseNonRecursive(graph),
                arg => Assert.Equal(1, arg),
                arg => Assert.Equal(2, arg),
                arg => Assert.Equal(4, arg),
                arg => Assert.Equal(3, arg));
        }
    }
}
