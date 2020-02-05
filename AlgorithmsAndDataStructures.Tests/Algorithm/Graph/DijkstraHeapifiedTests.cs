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

            var (minDistance, path) = sut.MinDistance(graph, 0, 0);

            Assert.Equal(0, minDistance);
            Assert.Equal(0, path[0]);
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

            var (minDistance, path) = sut.MinDistance(graph, 0, 1);

            Assert.Equal(1, minDistance);
            Assert.Equal(0, path[1]);
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

            var (minDistance, path) = sut.MinDistance(graph, 0, 2);
            Assert.Equal(3, minDistance);
            Assert.Equal(0, path[1]);
            Assert.Equal(1, path[2]);
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

            var (minDistance, path) = sut.MinDistance(graph, 0, 2);

            Assert.Equal(3, minDistance);
            Assert.Equal(1, path[2]);
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

            var (minDistance, path) = sut.MinDistance(graph, 0, 2);

            Assert.Equal(3, minDistance);
            Assert.Equal(0, path[1]);
            Assert.Equal(1, path[2]);
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

            var (minDistance, path) = sut.MinDistance(graph, 0, 1);

            Assert.Equal(11, minDistance);
            Assert.Equal(0, path[2]);
            Assert.Equal(2, path[1]);
        }
    }
}
