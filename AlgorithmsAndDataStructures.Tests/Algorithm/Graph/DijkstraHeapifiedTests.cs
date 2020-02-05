using AlgorithmsAndDataStructures.Algorithms.Graph;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Graph
{
    public class DijkstraHeapifiedTests
    {
        [Fact]
        public void DistanceToItselfIsZero()
        {
            var sut = new DijkstraHeapified();

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
            var sut = new DijkstraHeapified();

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
            var sut = new DijkstraHeapified();

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
            var sut = new DijkstraHeapified();

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
            var sut = new DijkstraHeapified();

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

        [Fact]
        public void BaseLine()
        {
            var sut = new DijkstraHeapified();

            var graph =
                new WeightedGraphNode[]
                {
                    new WeightedGraphNode()
                    {
                        Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>()
                        {
                            new WeightedGraphNodeEdge()
                            { 
                                To = 1,
                                Weight = 14
                            },
                            new WeightedGraphNodeEdge()
                            {
                                To = 2,
                                Weight = 9
                            },
                            new WeightedGraphNodeEdge()
                            {
                                To = 3,
                                Weight = 7
                            }
                        }
                    },
                    new WeightedGraphNode()
                    {
                        Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>()
                        {
                            new WeightedGraphNodeEdge()
                            {
                                To = 4,
                                Weight = 9
                            },
                            new WeightedGraphNodeEdge()
                            {
                                To = 2,
                                Weight = 2
                            }
                        }
                    },
                    new WeightedGraphNode()
                    {
                        Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>()
                        {
                           new WeightedGraphNodeEdge()
                            {
                                To = 3,
                                Weight = 10
                            },
                            new WeightedGraphNodeEdge()
                            {
                                To = 5,
                                Weight = 11
                            },
                            new WeightedGraphNodeEdge()
                            {
                                To = 1,
                                Weight = 2
                            },
                        }
                    },
                    new WeightedGraphNode()
                    {
                        Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>()
                        {
                           new WeightedGraphNodeEdge()
                            {
                                To = 5,
                                Weight = 15
                            }
                        }
                    },
                    new WeightedGraphNode()
                    {
                        Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>()
                        {
                           new WeightedGraphNodeEdge()
                            {
                                To = 5,
                                Weight = 6
                            }
                        }
                    },
                    new WeightedGraphNode()
                    {
                    }
                };

            Assert.Equal(11, sut.MinDistance(graph, 0, 1));
        }
    }
}
