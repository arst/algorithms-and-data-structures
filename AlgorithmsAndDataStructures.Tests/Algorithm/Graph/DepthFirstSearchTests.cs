using AlgorithmsAndDataStructures.Algorithms.Graph;
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
            var graph = new GraphNode<int>[]
                {
                    new GraphNode<int>()
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
            var graph = new GraphNode<int>[]
                {
                    new GraphNode<int>()
                    {
                        Value = 1,
                        AdjacentNodes = new System.Collections.Generic.List<int>()
                        { 
                            1
                        }
                    },
                    new GraphNode<int>()
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
            var graph = new GraphNode<int>[]
                {
                    new GraphNode<int>()
                    {
                        Value = 1,
                        AdjacentNodes = new System.Collections.Generic.List<int>()
                        {
                            1
                        }
                    },
                    new GraphNode<int>()
                    {
                        Value = 2,
                        AdjacentNodes = new System.Collections.Generic.List<int>()
                        {
                            0
                        }
                    },
                };
            Assert.Collection(sut.Traverse(graph), arg => Assert.Equal(1, arg), arg => Assert.Equal(2, arg));
        }
    }
}
