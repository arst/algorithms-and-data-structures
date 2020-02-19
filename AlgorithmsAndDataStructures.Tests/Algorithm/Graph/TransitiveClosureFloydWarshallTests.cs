using AlgorithmsAndDataStructures.Algorithms.Graph.Common;
using AlgorithmsAndDataStructures.Algorithms.Graph.Misc;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Graph
{
    public class TransitiveClosureFloydWarshallTests
    {
        [Fact]
        public void OneNodeGraphIsTransitive()
        {
            var sut = new TransitiveClosureFloydWarshall();
            var graph = new WeightedGraphNode[]
            {
                new WeightedGraphNode()
            };

            var reachabilityMatrix = sut.GetReachabilityMatrix(graph);

            Assert.Collection(reachabilityMatrix, arg => {
                Assert.True(arg[0]);
            });
        }

        [Fact]
        public void TwoNodeGraphIsTransitive()
        {
            var sut = new TransitiveClosureFloydWarshall();
            var graph = new WeightedGraphNode[]
            {
                new WeightedGraphNode()
                { 
                    Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>()
                    { 
                        new WeightedGraphNodeEdge()
                        { 
                            To = 1,
                        }
                    }
                },
                new WeightedGraphNode()
                {
                    Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>()
                    {
                        new WeightedGraphNodeEdge()
                        {
                            To = 0,
                        }
                    }
                }
            };

            var reachabilityMatrix = sut.GetReachabilityMatrix(graph);

            Assert.Collection(reachabilityMatrix, 
                arg => {
                    Assert.True(arg[0]);
                    Assert.True(arg[1]);
                },
                arg => {
                    Assert.True(arg[0]);
                    Assert.True(arg[1]);
                });
        }

        [Fact]
        public void TwoNodeGraphIsNonTransitive()
        {
            var sut = new TransitiveClosureFloydWarshall();
            var graph = new WeightedGraphNode[]
            {
                new WeightedGraphNode()
                {
                    Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>()
                    {
                        new WeightedGraphNodeEdge()
                        {
                            To = 1,
                        }
                    }
                },
                new WeightedGraphNode()
                {
                }
            };

            var reachabilityMatrix = sut.GetReachabilityMatrix(graph);

            Assert.Collection(reachabilityMatrix,
                arg => {
                    Assert.True(arg[0]);
                    Assert.True(arg[1]);
                },
                arg => {
                    Assert.False(arg[0]);
                    Assert.True(arg[1]);
                });
        }

        [Fact]
        public void Baseline()
        {
            var sut = new TransitiveClosureFloydWarshall();
            var graph = new WeightedGraphNode[]
            {
                new WeightedGraphNode()
                {
                    Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>()
                    {
                        new WeightedGraphNodeEdge()
                        {
                            To = 1,
                        },
                        new WeightedGraphNodeEdge()
                        {
                            To = 2,
                        }
                    }
                },
                new WeightedGraphNode()
                {
                    Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>()
                    {
                        new WeightedGraphNodeEdge()
                        {
                            To = 2,
                        }
                    }
                },
                new WeightedGraphNode()
                {
                    Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>()
                    {
                        new WeightedGraphNodeEdge()
                        {
                            To = 0,
                        },
                        new WeightedGraphNodeEdge()
                        {
                            To = 3,
                        }
                    }
                },
                new WeightedGraphNode()
            };

            var reachabilityMatrix = sut.GetReachabilityMatrix(graph);

            Assert.Collection(reachabilityMatrix,
                arg => {
                    Assert.True(arg[0]);
                    Assert.True(arg[1]);
                    Assert.True(arg[2]);
                    Assert.True(arg[3]);
                },
                 arg => {
                     Assert.True(arg[0]);
                     Assert.True(arg[1]);
                     Assert.True(arg[2]);
                     Assert.True(arg[3]);
                 },
                  arg => {
                      Assert.True(arg[0]);
                      Assert.True(arg[1]);
                      Assert.True(arg[2]);
                      Assert.True(arg[3]);
                  },
                   arg => {
                       Assert.False(arg[0]);
                       Assert.False(arg[1]);
                       Assert.False(arg[2]);
                       Assert.True(arg[3]);
                   });
        }
    }
}
