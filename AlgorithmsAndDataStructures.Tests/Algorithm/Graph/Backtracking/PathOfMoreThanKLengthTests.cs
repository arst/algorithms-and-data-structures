using AlgorithmsAndDataStructures.Algorithms.Graph.Backtracking;
using AlgorithmsAndDataStructures.Algorithms.Graph.Common;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Graph.Backtracking
{
    public class PathOfMoreThanKLengthTests
    {
        [Fact]
        public void OneVerticeGraphHashZeroWeightPath()
        {
            var sut = new PathOfMoreThanKLength();

            var graph = new WeightedGraphNode[]
            {
                new WeightedGraphNode()
            };

            var result = sut.GetPathOfMoreThanKLength(graph, 0, 0);

            Assert.True(result.hasPath);
            Assert.Collection(result.path, arg => Assert.Equal(0, arg));
        }

        [Fact]
        public void TwoVerticesGraphHasSimplePath()
        {
            var sut = new PathOfMoreThanKLength();

            var graph = new WeightedGraphNode[]
            {
                new WeightedGraphNode()
                { 
                    Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>()
                    { 
                        new WeightedGraphNodeEdge()
                        { 
                            From = 0,
                            To = 1,
                            Weight = 10,
                        }
                    }
                },
                new WeightedGraphNode()
            };

            var result = sut.GetPathOfMoreThanKLength(graph, 0, 9);

            Assert.True(result.hasPath);
            Assert.Collection(result.path, arg => Assert.Equal(0, arg), arg => Assert.Equal(1, arg));
        }

        [Fact]
        public void TwoVerticesGraphHasNoSimplePath()
        {
            var sut = new PathOfMoreThanKLength();

            var graph = new WeightedGraphNode[]
            {
                new WeightedGraphNode()
                {
                    Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>()
                    {
                        new WeightedGraphNodeEdge()
                        {
                            From = 0,
                            To = 1,
                            Weight = 8,
                        }
                    }
                },
                new WeightedGraphNode()
            };

            var result = sut.GetPathOfMoreThanKLength(graph, 0, 9);

            Assert.False(result.hasPath);
            Assert.Empty(result.path);
        }

        [Fact]
        public void BaselineHasNoPath()
        {
            var sut = new PathOfMoreThanKLength();

            var graph = new WeightedGraphNode[]
            {
                new WeightedGraphNode()
                {
                    Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>()
                    {
                        new WeightedGraphNodeEdge()
                        {
                            From = 0,
                            To = 1,
                            Weight = 4,
                        },
                        new WeightedGraphNodeEdge()
                        {
                            From = 0,
                            To = 7,
                            Weight = 8,
                        },
                    }
                },
                new WeightedGraphNode()
                {
                    Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>()
                    {
                        new WeightedGraphNodeEdge()
                        {
                            From = 1,
                            To = 2,
                            Weight = 8,
                        },
                        new WeightedGraphNodeEdge()
                        {
                            From = 1,
                            To = 7,
                            Weight = 11,
                        },
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
                            Weight = 7,
                        },
                        new WeightedGraphNodeEdge()
                        {
                            From = 2,
                            To = 8,
                            Weight = 2,
                        },
                        new WeightedGraphNodeEdge()
                        {
                            From = 2,
                            To = 5,
                            Weight = 4,
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
                            To = 4,
                            Weight = 9,
                        },
                        new WeightedGraphNodeEdge()
                        {
                            From = 3,
                            To = 5,
                            Weight = 14,
                        },
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
                            Weight = 10,
                        }
                    }
                },
                new WeightedGraphNode()
                {
                    Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>()
                    {
                        new WeightedGraphNodeEdge()
                        {
                            From = 5,
                            To = 6,
                            Weight = 2,
                        }
                    }
                },
                new WeightedGraphNode()
                {
                    Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>()
                    {
                        new WeightedGraphNodeEdge()
                        {
                            From = 6,
                            To = 7,
                            Weight = 1,
                        },
                        new WeightedGraphNodeEdge()
                        {
                            From = 6,
                            To = 8,
                            Weight = 6,
                        },
                    }
                },
                new WeightedGraphNode()
                {
                    Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>()
                    {
                        new WeightedGraphNodeEdge()
                        {
                            From = 7,
                            To = 8,
                            Weight = 7,
                        }
                    }
                },
                new WeightedGraphNode()
            };

            var result = sut.GetPathOfMoreThanKLength(graph, 0, 50);

            Assert.False(result.hasPath);
            Assert.Empty(result.path); 
        }

        [Fact]
        public void BaselineHasPath()
        {
            var sut = new PathOfMoreThanKLength();

            var graph = new WeightedGraphNode[]
            {
                new WeightedGraphNode()
                {
                    Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>()
                    {
                        new WeightedGraphNodeEdge()
                        {
                            From = 0,
                            To = 1,
                            Weight = 4,
                        },
                        new WeightedGraphNodeEdge()
                        {
                            From = 0,
                            To = 7,
                            Weight = 8,
                        },
                    }
                },
                new WeightedGraphNode()
                {
                    Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>()
                    {
                        new WeightedGraphNodeEdge()
                        {
                            From = 1,
                            To = 2,
                            Weight = 8,
                        },
                        new WeightedGraphNodeEdge()
                        {
                            From = 1,
                            To = 7,
                            Weight = 11,
                        },
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
                            Weight = 7,
                        },
                        new WeightedGraphNodeEdge()
                        {
                            From = 2,
                            To = 8,
                            Weight = 2,
                        },
                        new WeightedGraphNodeEdge()
                        {
                            From = 2,
                            To = 5,
                            Weight = 4,
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
                            To = 4,
                            Weight = 9,
                        },
                        new WeightedGraphNodeEdge()
                        {
                            From = 3,
                            To = 5,
                            Weight = 14,
                        },
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
                            Weight = 10,
                        }
                    }
                },
                new WeightedGraphNode()
                {
                    Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>()
                    {
                        new WeightedGraphNodeEdge()
                        {
                            From = 5,
                            To = 6,
                            Weight = 2,
                        }
                    }
                },
                new WeightedGraphNode()
                {
                    Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>()
                    {
                        new WeightedGraphNodeEdge()
                        {
                            From = 6,
                            To = 7,
                            Weight = 1,
                        },
                        new WeightedGraphNodeEdge()
                        {
                            From = 6,
                            To = 8,
                            Weight = 6,
                        },
                    }
                },
                new WeightedGraphNode()
                {
                    Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>()
                    {
                        new WeightedGraphNodeEdge()
                        {
                            From = 7,
                            To = 8,
                            Weight = 7,
                        }
                    }
                },
                new WeightedGraphNode(),
            };

            var result = sut.GetPathOfMoreThanKLength(graph, 0, 48);

            Assert.True(result.hasPath);
        }
    }
}
