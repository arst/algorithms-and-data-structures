using AlgorithmsAndDataStructures.Algorithms.Graph;
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

            Assert.Equal(0, sut.MinDistance(graph, 0, 0));
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

            Assert.Equal(1, sut.MinDistance(graph, 0, 1));
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

            Assert.Equal(3, sut.MinDistance(graph, 0, 2));
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

            Assert.Equal(3, sut.MinDistance(graph, 0, 2));
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

            Assert.Equal(3, sut.MinDistance(graph, 0, 2));
        }
    }
}
