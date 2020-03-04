using AlgorithmsAndDataStructures.Algorithms.Graph.Coloring;
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

        // Randomized tests is needed
    }
}
