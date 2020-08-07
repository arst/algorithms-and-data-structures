using AlgorithmsAndDataStructures.Algorithms.Graph.MaximumFlow;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Graph.MaxFlow
{
    public class DinicsMaximumFlowTests
    {
        [Fact]
        public void BaselineWithZigZagPath()
        {
            var sut = new DinicsMaximumFlow();
            var graph = new int[4][];

            for (var i = 0; i < graph.Length; i++)
            {
                graph[i] = new int[4];
            }

            graph[0][1] = 3;
            graph[0][2] = 2;
            graph[1][2] = 5;
            graph[1][3] = 2;
            graph[2][3] = 3;

            Assert.Equal(5, sut.MaxFlow(graph, 0, graph.Length - 1));
        }

        [Fact]
        public void BaselineWithStraightLines()
        {
            var sut = new DinicsMaximumFlow();
            var graph = new int[4][];

            for (var i = 0; i < graph.Length; i++)
            {
                graph[i] = new int[4];
            }

            graph[0][1] = 3;
            graph[0][2] = 2;
            graph[1][3] = 2;
            graph[2][3] = 3;

            Assert.Equal(4, sut.MaxFlow(graph, 0, graph.Length - 1));
        }

        [Fact]
        public void Baseline()
        {
            var sut = new DinicsMaximumFlow();
            var graph = new int[6][];

            graph[0] = new[] { 0, 16, 13, 0, 0, 0 };
            graph[1] = new[] { 0, 0, 10, 12, 0, 0 };
            graph[2] = new[] { 0, 4, 0, 0, 14, 0 };
            graph[3] = new[] { 0, 0, 9, 0, 0, 20 };
            graph[4] = new[] { 0, 0, 0, 7, 0, 4 };
            graph[5] = new[] { 0, 0, 0, 0, 0, 0 };

            Assert.Equal(23, sut.MaxFlow(graph, 0, graph.Length - 1));
        }

        [Fact]
        public void BaselineExtended()
        {
            var sut = new DinicsMaximumFlow();
            var graph = new int[11][];

            graph[0] = new[] { 0, 5, 10, 15, 0, 0, 0, 0, 0, 0, 0 };
            graph[1] = new[] { 0, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0 };
            graph[2] = new[] { 0, 15, 0, 0, 0, 20, 0, 0, 0, 0, 0 };
            graph[3] = new[] { 0, 0, 0, 0, 0, 0, 25, 0, 0, 0, 0 };
            graph[4] = new[] { 0, 0, 0, 0, 0, 25, 0, 10, 0, 0, 0 };
            graph[5] = new[] { 0, 0, 0, 5, 0, 0, 0, 0, 30, 0, 0 };
            graph[6] = new[] { 0, 0, 0, 0, 0, 0, 0, 0, 20, 10, 0 };
            graph[7] = new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5 };
            graph[8] = new[] { 0, 0, 0, 0, 15, 0, 0, 0, 0, 15, 15 };
            graph[9] = new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10 };
            graph[10] = new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            Assert.Equal(30, sut.MaxFlow(graph, 0, graph.Length - 1));
        }
    }
}
