using AlgorithmsAndDataStructures.Algorithms.Graph.Common;
using AlgorithmsAndDataStructures.Algorithms.Graph.Misc;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Graph
{
    public class KosarajusAlgorithmTests
    {
        [Fact]
        public void OneNodeGraphIsConnected()
        {
            var sut = new KosarajusAlgorithm();
            var graph = new[]
            {
                new WeightedGraphVertex()
            };

            Assert.True(sut.IsConnected(graph));
        }

        [Fact]
        public void TwoNodeConnectedGraphIsConnected()
        {
            var sut = new KosarajusAlgorithm();
            var graph = new[]
            {
                new WeightedGraphVertex
                { 
                    Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>
                    { 
                        new WeightedGraphNodeEdge { From = 0, To = 1 }
                    }
                },
                new WeightedGraphVertex
                {
                    Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>
                    {
                        new WeightedGraphNodeEdge { From = 1, To = 0 }
                    }
                }
            };

            Assert.True(sut.IsConnected(graph));
        }

        [Fact]
        public void TwoNodeDisconnectedGraphIsNotConnected()
        {
            var sut = new KosarajusAlgorithm();
            var graph = new[]
            {
                new WeightedGraphVertex(),
                new WeightedGraphVertex()
            };

            Assert.False(sut.IsConnected(graph));
        }

        [Fact]
        public void OneWayConnectedGraphIsNotConnected()
        {
            var sut = new KosarajusAlgorithm();
            var graph = new[]
            {
                 new WeightedGraphVertex
                 {
                    Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>
                    {
                        new WeightedGraphNodeEdge { From = 0, To = 1 }
                    }
                },
                new WeightedGraphVertex
                {
                    Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>
                    {
                        new WeightedGraphNodeEdge { From = 1, To = 2 }
                    }
                },
                new WeightedGraphVertex()
            };

            Assert.False(sut.IsConnected(graph));
        }

        [Fact]
        public void Baseline()
        {
            var sut = new KosarajusAlgorithm();
            var graph = new[]
            {
                 new WeightedGraphVertex
                 {
                    Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>
                    {
                        new WeightedGraphNodeEdge { From = 0, To = 1 }
                    }
                },
                new WeightedGraphVertex
                {
                    Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>
                    {
                        new WeightedGraphNodeEdge { From = 1, To = 2 }
                    }
                },
                new WeightedGraphVertex
                {
                    Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>
                    {
                        new WeightedGraphNodeEdge { From = 2, To = 3 },
                        new WeightedGraphNodeEdge { From = 2, To = 4 }
                    }
                },
                new WeightedGraphVertex
                {
                    Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>
                    {
                        new WeightedGraphNodeEdge { From = 3, To = 0 }
                    }
                },
                new WeightedGraphVertex
                {
                    Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>
                    {
                        new WeightedGraphNodeEdge { From = 4, To = 2 }
                    }
                },
            };

            Assert.True(sut.IsConnected(graph));
        }
    }
}
