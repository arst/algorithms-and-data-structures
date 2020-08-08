using AlgorithmsAndDataStructures.Algorithms.Graph.Search;
using AlgorithmsAndDataStructures.DataStructures.Graph;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Graph
{
    public class BreadthFirstSearchTests
    {
        [Fact]
        public void OneNodeGraph()
        {
            var sut = new BreadthFirstSearch();
            var graph = new[]
                {
                    new GraphVertex<int>
                    {
                        Value = 1
                    },
                };
            Assert.Collection(sut.Traverse(graph), arg => Assert.Equal(1, arg));
        }

        [Fact]
        public void TwoNodesGraph()
        {
            var sut = new BreadthFirstSearch();
            var graph = new[]
                {
                    new GraphVertex<int>
                    {
                        Value = 1,
                        AdjacentVertices = new System.Collections.Generic.List<int>
                        {
                            1
                        }
                    },
                    new GraphVertex<int>
                    {
                        Value = 2
                    },
                };
            Assert.Collection(sut.Traverse(graph), arg => Assert.Equal(1, arg), arg => Assert.Equal(2, arg));
        }

        [Fact]
        public void TwoNodesGraphWithCircularDependency()
        {
            var sut = new BreadthFirstSearch();
            var graph = new[]
                {
                    new GraphVertex<int>
                    {
                        Value = 1,
                        AdjacentVertices = new System.Collections.Generic.List<int>
                        {
                            1
                        }
                    },
                    new GraphVertex<int>
                    {
                        Value = 2,
                        AdjacentVertices = new System.Collections.Generic.List<int>
                        {
                            0
                        }
                    },
                };
            Assert.Collection(sut.Traverse(graph), arg => Assert.Equal(1, arg), arg => Assert.Equal(2, arg));
        }

        [Fact]
        public void BreadthFirstSearchTraversal()
        {
            var sut = new BreadthFirstSearch();
            var graph = new[]
                {
                    new GraphVertex<int>
                    {
                        Value = 1,
                        AdjacentVertices = new System.Collections.Generic.List<int>
                        {
                            1,2
                        }
                    },
                    new GraphVertex<int>
                    {
                        Value = 2,
                        AdjacentVertices = new System.Collections.Generic.List<int>
                        {
                            3
                        }
                    },
                    new GraphVertex<int>
                    {
                        Value = 3,
                        AdjacentVertices = new System.Collections.Generic.List<int>()
                    },
                    new GraphVertex<int>
                    {
                        Value = 4,
                        AdjacentVertices = new System.Collections.Generic.List<int>()
                    },
                };
            Assert.Collection(sut.Traverse(graph), 
                arg => Assert.Equal(1, arg), 
                arg => Assert.Equal(2, arg),
                arg => Assert.Equal(3, arg),
                arg => Assert.Equal(4, arg));
        }
    }
}
