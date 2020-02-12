using AlgorithmsAndDataStructures.Algorithms.Graph;
using AlgorithmsAndDataStructures.Algorithms.Graph.Common;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Graph
{
    public class DijkstraNaiveTests
    {
        [Fact]
        public void DistanceToItselfIsZero()
        {
            var sut = new DijkstraNaive();

            var graph = 
                new WeightedGraphNode[]
                {
                    new WeightedGraphNode()
                    { 
                    }
                };
            var (minDistance, path) = sut.MinDistance(graph, 0, 0);

            Assert.Equal(0, minDistance);
            Assert.Equal(0, path[0]);
        }

        [Fact]
        public void DistanceToNeighborNodeIsEqualEdgeWeight()
        {
            var sut = new DijkstraNaive();

            var graph =
                new WeightedGraphNode[]
                {
                    new WeightedGraphNode()
                    {
                        Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>()
                        { 
                            new WeightedGraphNodeEdge()
                            { 
                                Weight = 1,
                                To = 1
                            }
                        }
                    },
                    new WeightedGraphNode()
                    {
                    }
                };
            var (minDistance, path) = sut.MinDistance(graph, 0, 1);

            Assert.Equal(1, minDistance);
            Assert.Equal(0, path[1]);
        }

        [Fact]
        public void DistanceToGrandNeighborNodeIsEqualSumOfEdgesWeight()
        {
            var sut = new DijkstraNaive();

            var graph =
                new WeightedGraphNode[]
                {
                    new WeightedGraphNode()
                    {
                        Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>()
                        {
                            new WeightedGraphNodeEdge()
                            {
                                Weight = 1,
                                To = 1
                            }
                        }
                    },
                    new WeightedGraphNode()
                    {
                        Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>()
                        {
                            new WeightedGraphNodeEdge()
                            {
                                Weight = 2,
                                To = 2
                            }
                        }
                    },
                    new WeightedGraphNode()
                    {
                    }
                };

            var (minDistance, path) = sut.MinDistance(graph, 0, 2);
            Assert.Equal(3, minDistance);
            Assert.Equal(0, path[1]);
            Assert.Equal(1, path[2]);
        }

        [Fact]
        public void DistanceIsRecalculatedWhenCheaperPathIsFound()
        {
            var sut = new DijkstraNaive();

            var graph =
                new WeightedGraphNode[]
                {
                    new WeightedGraphNode()
                    {
                        Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>()
                        {
                            new WeightedGraphNodeEdge()
                            {
                                Weight = 1,
                                To = 1
                            },
                            new WeightedGraphNodeEdge()
                            {
                                Weight = 5,
                                To = 2
                            }
                        }
                    },
                    new WeightedGraphNode()
                    {
                        Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>()
                        {
                            new WeightedGraphNodeEdge()
                            {
                                Weight = 2,
                                To = 2
                            }
                        }
                    },
                    new WeightedGraphNode()
                    {
                    }
                };
            var (minDistance, path) = sut.MinDistance(graph, 0, 2);

            Assert.Equal(3, minDistance);
            Assert.Equal(1, path[2]);
        }

        [Fact]
        public void DistanceIsCalculateForGraphWithCycles()
        {
            var sut = new DijkstraNaive();

            var graph =
                new WeightedGraphNode[]
                {
                    new WeightedGraphNode()
                    {
                        Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>()
                        {
                            new WeightedGraphNodeEdge()
                            {
                                Weight = 1,
                                To = 1
                            },
                            new WeightedGraphNodeEdge()
                            {
                                Weight = 5,
                                To = 2
                            }
                        }
                    },
                    new WeightedGraphNode()
                    {
                        Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>()
                        {
                            new WeightedGraphNodeEdge()
                            {
                                Weight = 2,
                                To = 2
                            }
                        }
                    },
                    new WeightedGraphNode()
                    {
                        Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>()
                        {
                            new WeightedGraphNodeEdge()
                            {
                                Weight = 2,
                                To = 0
                            }
                        }
                    }
                };
            var (minDistance, path) = sut.MinDistance(graph, 0, 2);

            Assert.Equal(3, minDistance);
            Assert.Equal(0, path[1]);
            Assert.Equal(1, path[2]);
        }
    }
}
