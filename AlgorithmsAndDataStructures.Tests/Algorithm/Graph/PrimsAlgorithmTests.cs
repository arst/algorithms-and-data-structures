using AlgorithmsAndDataStructures.Algorithms.Graph;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Graph
{
    public class PrimsAlgorithmTests
    {

        [Fact]
        public void MinimumSpanningTreeWeightForOneNodeGraphIsZero()
        {
            var sut = new PrimsAlgorithm();

            var graph =
               new WeightedGraphNode[]
               {
                    new WeightedGraphNode()
                    {
                    }
               };

            Assert.Equal(0, sut.GetMinimumSpanningTreeWeight(graph));
        }

        [Fact]
        public void MinimumSpanningTreeWeightForNeighborNodeIsEqualEdgeWeight()
        {
            var sut = new PrimsAlgorithm();

            var graph =
                 new WeightedGraphNode[]
                 {
                    new WeightedGraphNode()
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
                    new WeightedGraphNode()
                    {
                    }
                 };

            Assert.Equal(1, sut.GetMinimumSpanningTreeWeight(graph));
        }

        [Fact]
        public void MinimumSpanningTreeWeightForGrandNeighborNodeIsEqualSumOfEdgesWeight()
        {
            var sut = new PrimsAlgorithm();

            var graph =
                new WeightedGraphNode[]
                {
                    new WeightedGraphNode()
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
                    new WeightedGraphNode()
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
                    new WeightedGraphNode()
                    {
                    }
                };

            Assert.Equal(3, sut.GetMinimumSpanningTreeWeight(graph));
        }

        [Fact]
        public void NodeDiscardedWhenCycleIsFound()
        {
            var sut = new PrimsAlgorithm();

            var graph =
                new WeightedGraphNode[]
                {
                    new WeightedGraphNode()
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
                    new WeightedGraphNode()
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
                    new WeightedGraphNode()
                    {
                    }
                };

            Assert.Equal(3, sut.GetMinimumSpanningTreeWeight(graph));
        }

        [Fact]
        public void MinimumSpanningTreeWeightIsClculatedForGraphWithCycle()
        {
            var sut = new PrimsAlgorithm();

            var graph =
                new WeightedGraphNode[]
                {
                    new WeightedGraphNode()
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
                    new WeightedGraphNode()
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
                    new WeightedGraphNode()
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
            var sut = new PrimsAlgorithm();

            var graph =
                new WeightedGraphNode[]
                {
                    new WeightedGraphNode()
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
                    new WeightedGraphNode()
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
                    new WeightedGraphNode()
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
                    new WeightedGraphNode()
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
                    new WeightedGraphNode()
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
                    new WeightedGraphNode()
                    {
                    }
                };

            Assert.Equal(33, sut.GetMinimumSpanningTreeWeight(graph));
        }
    }
}
