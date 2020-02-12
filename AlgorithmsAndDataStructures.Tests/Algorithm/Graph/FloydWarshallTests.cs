using AlgorithmsAndDataStructures.Algorithms.Graph;
using AlgorithmsAndDataStructures.Algorithms.Graph.Common;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Graph
{
    public class FloydWarshallTests
    {
        [Fact]
        public void CanCalculateMinDistancesForGraphWithCycles()
        {
            var sut = new FloydWarshall();

            var graph = new WeightedGraphNode[4];

            var node1 = new WeightedGraphNode()
            {
                Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>()
                {
                    new WeightedGraphNodeEdge() { To = 2, Weight = 3 },
                    new WeightedGraphNodeEdge() { To = 3, Weight = 0 },
                }
            };
            var node2 = new WeightedGraphNode()
            {
                Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>()
                {
                    new WeightedGraphNodeEdge() { To = 0, Weight = -2 },
                    new WeightedGraphNodeEdge() { To = 3, Weight = 1 },
                }
            };
            var node3 = new WeightedGraphNode()
            {
                Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>()
                {
                    new WeightedGraphNodeEdge() { To = 3, Weight = 5 },
                }
            };
            var node4 = new WeightedGraphNode() 
            {
                Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>()
                {
                    new WeightedGraphNodeEdge() { To = 1, Weight = 4 },
                }
            };

            graph[0] = node1;
            graph[1] = node2;
            graph[2] = node3;
            graph[3] = node4;

            var (distances, path) = sut.MinDistances(graph);
            
            Assert.Collection(distances[0],
                arg => Assert.Equal(0, arg),
                arg => Assert.Equal(4, arg),
                arg => Assert.Equal(3, arg),
                arg => Assert.Equal(0, arg));
            Assert.Collection(distances[1],
                arg => Assert.Equal(-2, arg),
                arg => Assert.Equal(0, arg),
                arg => Assert.Equal(1, arg),
                arg => Assert.Equal(-2, arg));
            Assert.Collection(distances[2],
                arg => Assert.Equal(7, arg),
                arg => Assert.Equal(9, arg),
                arg => Assert.Equal(0, arg),
                arg => Assert.Equal(5, arg));
            Assert.Collection(distances[3],
                arg => Assert.Equal(2, arg),
                arg => Assert.Equal(4, arg),
                arg => Assert.Equal(5, arg),
                arg => Assert.Equal(0, arg));
        }

        [Fact]
        public void CanCalculateMinDistancesForGraphWithoutCycles()
        {
            var sut = new FloydWarshall();

            var graph = new WeightedGraphNode[4];

            var node1 = new WeightedGraphNode()
            {
                Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>()
                {
                    new WeightedGraphNodeEdge() { To = 1, Weight = 5 },
                    new WeightedGraphNodeEdge() { To = 3, Weight = 30 },
                }
            };
            var node2 = new WeightedGraphNode()
            {
                Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>()
                {
                    new WeightedGraphNodeEdge() { To = 2, Weight = 5 },
                    new WeightedGraphNodeEdge() { To = 3, Weight = 20 },
                }
            };
            var node3 = new WeightedGraphNode()
            {
                Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>()
                {
                    new WeightedGraphNodeEdge() { To = 3, Weight = 5 },
                }
            };
            var node4 = new WeightedGraphNode() {};

            graph[0] = node1;
            graph[1] = node2;
            graph[2] = node3;
            graph[3] = node4;

            var (distances, path) = sut.MinDistances(graph);

            Assert.Collection(distances[0],
                arg => Assert.Equal(0, arg),
                arg => Assert.Equal(5, arg),
                arg => Assert.Equal(10, arg),
                arg => Assert.Equal(15, arg));
            Assert.Collection(distances[1],
                arg => Assert.Equal(int.MaxValue / 2, arg),
                arg => Assert.Equal(0, arg),
                arg => Assert.Equal(5, arg),
                arg => Assert.Equal(10, arg));
            Assert.Collection(distances[2],
                arg => Assert.Equal(int.MaxValue / 2, arg),
                arg => Assert.Equal(int.MaxValue / 2, arg),
                arg => Assert.Equal(0, arg),
                arg => Assert.Equal(5, arg));
            Assert.Collection(distances[3],
                arg => Assert.Equal(int.MaxValue / 2, arg),
                arg => Assert.Equal(int.MaxValue / 2, arg),
                arg => Assert.Equal(int.MaxValue / 2, arg),
                arg => Assert.Equal(0, arg));
        }
    }
}
