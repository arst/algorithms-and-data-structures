using AlgorithmsAndDataStructures.Algorithms.Graph.Common;
using AlgorithmsAndDataStructures.Algorithms.Graph.MinimumSpanningTree;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Graph
{
    public class KruskalMinimumSpanningTreeTests
    {
        [Fact]
        public void MinimumSpanningTreeWeightForOneNodeGraphIsZero()
        {
            var sut = new KruskalMinimumSpanningTree();

            var graph =
               new WeightedGraphVertex[]
               {
                    new WeightedGraphVertex()
                    {
                    }
               };

            Assert.Equal(0, sut.GetMinimumSpanningTreeWeight(graph));
        }

        [Fact]
        public void MinimumSpanningTreeWeightForNeighborNodeIsEqualEdgeWeight()
        {
            var sut = new KruskalMinimumSpanningTree();

            var graph =
                 new WeightedGraphVertex[]
                 {
                    new WeightedGraphVertex()
                    {
                        Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>()
                        {
                            new WeightedGraphNodeEdge()
                            {
                                From = 0,
                                Weight = 1,
                                To = 1
                            }
                        }
                    },
                    new WeightedGraphVertex()
                    {
                    }
                 };

            Assert.Equal(1, sut.GetMinimumSpanningTreeWeight(graph));
        }

        [Fact]
        public void MinimumSpanningTreeWeightForGrandNeighborNodeIsEqualSumOfEdgesWeight()
        {
            var sut = new KruskalMinimumSpanningTree();

            var graph =
                new WeightedGraphVertex[]
                {
                    new WeightedGraphVertex()
                    {
                        Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>()
                        {
                            new WeightedGraphNodeEdge()
                            {
                                From = 0,
                                Weight = 1,
                                To = 1
                            }
                        }
                    },
                    new WeightedGraphVertex()
                    {
                        Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>()
                        {
                            new WeightedGraphNodeEdge()
                            {
                                From = 1,
                                Weight = 2,
                                To = 2
                            }
                        }
                    },
                    new WeightedGraphVertex()
                    {
                    }
                };

            Assert.Equal(3, sut.GetMinimumSpanningTreeWeight(graph));
        }

        [Fact]
        public void NodeDiscardedWhenCycleIsFound()
        {
            var sut = new KruskalMinimumSpanningTree();

            var graph =
                new WeightedGraphVertex[]
                {
                    new WeightedGraphVertex()
                    {
                        Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>()
                        {
                            new WeightedGraphNodeEdge()
                            {
                                From = 0,
                                Weight = 1,
                                To = 1
                            },
                            new WeightedGraphNodeEdge()
                            {
                                From = 0,
                                Weight = 5,
                                To = 2
                            }
                        }
                    },
                    new WeightedGraphVertex()
                    {
                        Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>()
                        {
                            new WeightedGraphNodeEdge()
                            {
                                From = 1,
                                Weight = 2,
                                To = 2
                            }
                        }
                    },
                    new WeightedGraphVertex()
                    {
                    }
                };

            Assert.Equal(3, sut.GetMinimumSpanningTreeWeight(graph));
        }

        [Fact]
        public void MinimumSpanningTreeWeightIsClculatedForGraphWithCycle()
        {
            var sut = new KruskalMinimumSpanningTree();

            var graph =
                new WeightedGraphVertex[]
                {
                    new WeightedGraphVertex()
                    {
                        Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>()
                        {
                            new WeightedGraphNodeEdge()
                            {
                                From = 0,
                                Weight = 1,
                                To = 1
                            },
                            new WeightedGraphNodeEdge()
                            {
                                From = 0,
                                Weight = 5,
                                To = 2
                            }
                        }
                    },
                    new WeightedGraphVertex()
                    {
                        Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>()
                        {
                            new WeightedGraphNodeEdge()
                            {
                                From = 1,
                                Weight = 2,
                                To = 2
                            }
                        }
                    },
                    new WeightedGraphVertex()
                    {
                        Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>()
                        {
                            new WeightedGraphNodeEdge()
                            {
                                From = 2,
                                Weight = 2,
                                To = 0
                            }
                        }
                    }
                };


            Assert.Equal(3, sut.GetMinimumSpanningTreeWeight(graph));
        }

        [Fact]
        public void BaseLine()
        {
            var sut = new KruskalMinimumSpanningTree();

            var graph =
                new WeightedGraphVertex[]
                {
                    new WeightedGraphVertex()
                    {
                        Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>()
                        {
                            new WeightedGraphNodeEdge()
                            {
                                From = 0,
                                To = 1,
                                Weight = 14
                            },
                            new WeightedGraphNodeEdge()
                            {
                                From = 0,
                                To = 2,
                                Weight = 9
                            },
                            new WeightedGraphNodeEdge()
                            {
                                From = 0,
                                To = 3,
                                Weight = 7
                            }
                        }
                    },
                    new WeightedGraphVertex()
                    {
                        Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>()
                        {
                            new WeightedGraphNodeEdge()
                            {
                                From = 1,
                                To = 4,
                                Weight = 9
                            },
                            new WeightedGraphNodeEdge()
                            {
                                From = 1,
                                To = 2,
                                Weight = 2
                            }
                        }
                    },
                    new WeightedGraphVertex()
                    {
                        Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>()
                        {
                           new WeightedGraphNodeEdge()
                            {
                                From = 2,
                                To = 3,
                                Weight = 10
                            },
                            new WeightedGraphNodeEdge()
                            {
                                From = 2,
                                To = 5,
                                Weight = 11
                            },
                            new WeightedGraphNodeEdge()
                            {
                                From = 2,
                                To = 1,
                                Weight = 2
                            },
                        }
                    },
                    new WeightedGraphVertex()
                    {
                        Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>()
                        {
                           new WeightedGraphNodeEdge()
                            {
                                From = 3,
                                To = 5,
                                Weight = 15
                            }
                        }
                    },
                    new WeightedGraphVertex()
                    {
                        Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>()
                        {
                           new WeightedGraphNodeEdge()
                            {
                                From = 4,
                                To = 5,
                                Weight = 6
                            }
                        }
                    },
                    new WeightedGraphVertex()
                    {
                    }
                };

            Assert.Equal(33, sut.GetMinimumSpanningTreeWeight(graph));
        }
    }
}
