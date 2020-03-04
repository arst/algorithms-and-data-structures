using AlgorithmsAndDataStructures.Algorithms.Graph.Coloring;
using System;
using System.Linq;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Graph.Coloring
{
    public class GreedyColoringTests
    {
        [Fact]
        public void Baseline1()
        {
            var sut = new GreedyColoring();
            var graph = new int[5][];

            graph[0] = new [] { 0, 1, 1, 0, 0 };
            graph[1] = new[] { 1, 0, 1, 1, 0 };
            graph[2] = new[] { 1, 1, 0, 1, 0 };
            graph[3] = new[] { 0, 1, 1, 0, 1 };
            graph[4] = new[] { 0, 0, 0, 1, 0 };

            Assert.Equal(2, sut.Color(graph));
        }

        [Fact]
        public void Baseline2()
        {
            var sut = new GreedyColoring();
            var graph = new int[5][];

            graph[0] = new[] { 0, 1, 1, 0, 0 };
            graph[1] = new[] { 1, 0, 1, 0, 1 };
            graph[2] = new[] { 1, 1, 0, 0, 1 };
            graph[3] = new[] { 0, 0, 0, 0, 1 };
            graph[4] = new[] { 0, 0, 0, 1, 0 };

            Assert.Equal(2, sut.Color(graph));
        }

        [Fact]
        public void PropertyBased()
        {
            var sut = new GreedyColoring();

            for (int z = 0; z < 1000; z++)
            {
                var r = new Random();
                var vertices = r.Next(1, 100);

                var graph = new int[vertices][];

                for (int i = 0; i < vertices; i++)
                {
                    graph[i] = new int[vertices];
                }


                for (int i = 0; i < vertices; i++)
                {
                    for (int j = 0; j < vertices; j++)
                    {
                        if (i != j)
                        {
                            var edge = r.Next(0, 2);

                            graph[i][j] = edge;
                            graph[j][i] = edge;
                        }
                    }
                }

                var max = int.MinValue;

                for (int i = 0; i < vertices; i++)
                {
                    var current = graph[i].Sum();

                    if (current > max)
                    {
                        max = current;
                    }
                }

                int colors = sut.Color(graph);
                Assert.True(max + 1 >= colors);
            }
        }
    }
}
