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

            var vertice1 = new WeightedGraphVertex()
            {
                Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>()
                {
                    new WeightedGraphNodeEdge()
                    {
                        To = 1,
                        Weight = 5
                    },
                    new WeightedGraphNodeEdge()
                    {
                        To = 3,
                        Weight = 9
                    },
                    new WeightedGraphNodeEdge()
                    {
                        To = 4,
                        Weight = 14
                    }
                }
            };

            var vertice2 = new WeightedGraphVertex()
            {
                Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>()
                {
                    new WeightedGraphNodeEdge()
                    {
                        To = 2,
                        Weight = 7
                    }
                }
            };

            var vertice3 = new WeightedGraphVertex()
            {
                Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>()
                {
                    new WeightedGraphNodeEdge()
                    {
                        To = 4,
                        Weight = 4
                    }
                }
            };

            var vertice4 = new WeightedGraphVertex()
            {
                Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>() 
                {
                    new WeightedGraphNodeEdge()
                    {
                        To = 4,
                        Weight = 11
                    }
                }
            };

            var vertice5 = new WeightedGraphVertex()
            {
                Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>() {}
            };

            var graph = new WeightedGraphVertex[] { vertice1, vertice2, vertice3, vertice4, vertice5 };

            Assert.Equal(20, sut.GetCriticalPath(graph));
        }

        [Fact]
        public void BiggerGraph()
        {
            var sut = new CriticalPath();

            var vertice1 = new WeightedGraphVertex()
            {
                Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>()
                {
                    new WeightedGraphNodeEdge()
                    {
                        To = 1,
                        Weight = 17
                    }
                }
            };

            var vertice2 = new WeightedGraphVertex()
            {
                Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>()
                {
                    new WeightedGraphNodeEdge()
                    {
                        To = 2,
                        Weight = 13
                    }
                }
            };

            var vertice3 = new WeightedGraphVertex()
            {
                Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>()
                {
                    new WeightedGraphNodeEdge()
                    {
                        To = 3,
                        Weight = 9
                    }
                }
            };

            var vertice4 = new WeightedGraphVertex()
            {
                Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>()
                {
                    new WeightedGraphNodeEdge()
                    {
                        To = 4,
                        Weight = 11
                    },
                    new WeightedGraphNodeEdge()
                    {
                        To = 8,
                        Weight = 10
                    }
                }
            };

            var vertice5 = new WeightedGraphVertex()
            {
                Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>()
                {
                }
            };

            var vertice6 = new WeightedGraphVertex()
            {
                Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>()
                {
                    new WeightedGraphNodeEdge()
                    {
                        To = 6,
                        Weight = 11
                    },
                    new WeightedGraphNodeEdge()
                    {
                        To = 9,
                        Weight = 15
                    }
                }
            };

            var vertice7 = new WeightedGraphVertex()
            {
                Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>()
                {
                    new WeightedGraphNodeEdge()
                    {
                        To = 7,
                        Weight = 18
                    }
                }
            };

            var vertice8 = new WeightedGraphVertex()
            {
                Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>()
                {
                    new WeightedGraphNodeEdge()
                    {
                        To = 3,
                        Weight = 16
                    },
                    new WeightedGraphNodeEdge()
                    {
                        To = 8,
                        Weight = 13
                    },
                    new WeightedGraphNodeEdge()
                    {
                        To = 11,
                        Weight = 19
                    }
                }
            };

            var vertice9 = new WeightedGraphVertex()
            {
                Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>()
                {
                }
            };

            var vertice10 = new WeightedGraphVertex()
            {
                Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>()
                {
                    new WeightedGraphNodeEdge()
                    {
                        To = 10,
                        Weight = 14
                    },
                }
            };

            var vertice11 = new WeightedGraphVertex()
            {
                Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>()
                {
                    new WeightedGraphNodeEdge()
                    {
                        To = 11,
                        Weight = 17
                    },
                }
            };

            var vertice12 = new WeightedGraphVertex()
            {
                Edges = new System.Collections.Generic.List<WeightedGraphNodeEdge>()
                {
                }
            };

            var graph = new WeightedGraphVertex[] 
            { 
                vertice1, vertice2, vertice3, vertice4, vertice5,
                vertice6, vertice7, vertice8, vertice9,
                vertice10, vertice11, vertice12
            };

            Assert.Equal(56, sut.GetCriticalPath(graph));
        }
    }
}
