using AlgorithmsAndDataStructures.Algorithms.Graph.Common;
using AlgorithmsAndDataStructures.Algorithms.Graph.LongestPath;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Graph.LongestPath
{
    public class CriticalPathTests
    {
        [Fact]
        public void Base()
        {
            var sut = new CriticalPath();

            var vertex1 = new WeightedGraphVertex
            {
                Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>
                {
                    new WeightedGraphNodeEdge
                    {
                        To = 1,
                        Weight = 5
                    },
                    new WeightedGraphNodeEdge
                    {
                        To = 3,
                        Weight = 9
                    },
                    new WeightedGraphNodeEdge
                    {
                        To = 4,
                        Weight = 14
                    }
                }
            };

            var vertex2 = new WeightedGraphVertex
            {
                Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>
                {
                    new WeightedGraphNodeEdge
                    {
                        To = 2,
                        Weight = 7
                    }
                }
            };

            var vertex3 = new WeightedGraphVertex
            {
                Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>
                {
                    new WeightedGraphNodeEdge
                    {
                        To = 4,
                        Weight = 4
                    }
                }
            };

            var vertex4 = new WeightedGraphVertex
            {
                Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>
                {
                    new WeightedGraphNodeEdge
                    {
                        To = 4,
                        Weight = 11
                    }
                }
            };

            var vertex5 = new WeightedGraphVertex
            {
                Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>()
            };

            var graph = new [] { vertex1, vertex2, vertex3, vertex4, vertex5 };

            Assert.Equal(20, sut.GetCriticalPath(graph));
        }

        [Fact]
        public void BiggerGraph()
        {
            var sut = new CriticalPath();

            var vertex1 = new WeightedGraphVertex
            {
                Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>
                {
                    new WeightedGraphNodeEdge
                    {
                        To = 1,
                        Weight = 17
                    }
                }
            };

            var vertex2 = new WeightedGraphVertex
            {
                Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>
                {
                    new WeightedGraphNodeEdge
                    {
                        To = 2,
                        Weight = 13
                    }
                }
            };

            var vertex3 = new WeightedGraphVertex
            {
                Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>
                {
                    new WeightedGraphNodeEdge
                    {
                        To = 3,
                        Weight = 9
                    }
                }
            };

            var vertex4 = new WeightedGraphVertex
            {
                Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>
                {
                    new WeightedGraphNodeEdge
                    {
                        To = 4,
                        Weight = 11
                    },
                    new WeightedGraphNodeEdge
                    {
                        To = 8,
                        Weight = 10
                    }
                }
            };

            var vertex5 = new WeightedGraphVertex
            {
                Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>
                {
                }
            };

            var vertex6 = new WeightedGraphVertex
            {
                Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>
                {
                    new WeightedGraphNodeEdge
                    {
                        To = 6,
                        Weight = 11
                    },
                    new WeightedGraphNodeEdge
                    {
                        To = 9,
                        Weight = 15
                    }
                }
            };

            var vertex7 = new WeightedGraphVertex
            {
                Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>
                {
                    new WeightedGraphNodeEdge
                    {
                        To = 7,
                        Weight = 18
                    }
                }
            };

            var vertex8 = new WeightedGraphVertex
            {
                Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>
                {
                    new WeightedGraphNodeEdge
                    {
                        To = 3,
                        Weight = 16
                    },
                    new WeightedGraphNodeEdge
                    {
                        To = 8,
                        Weight = 13
                    },
                    new WeightedGraphNodeEdge
                    {
                        To = 11,
                        Weight = 19
                    }
                }
            };

            var vertex9 = new WeightedGraphVertex
            {
                Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>
                {
                }
            };

            var vertex10 = new WeightedGraphVertex
            {
                Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>
                {
                    new WeightedGraphNodeEdge
                    {
                        To = 10,
                        Weight = 14
                    },
                }
            };

            var vertex11 = new WeightedGraphVertex
            {
                Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>
                {
                    new WeightedGraphNodeEdge
                    {
                        To = 11,
                        Weight = 17
                    },
                }
            };

            var vertex12 = new WeightedGraphVertex
            {
                Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>
                {
                }
            };

            var graph = new [] 
            { 
                vertex1, vertex2, vertex3, vertex4, vertex5,
                vertex6, vertex7, vertex8, vertex9,
                vertex10, vertex11, vertex12
            };

            Assert.Equal(56, sut.GetCriticalPath(graph));
        }
    }
}
