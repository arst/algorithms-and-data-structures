using AlgorithmsAndDataStructures.Algorithms.Graph.MaximumFlow;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.MaxFlow
{
    public class FordFulkersonTests
    {
        [Fact]
        public void BaselineWithZigZagPath()
        {
            var sut = new FordFulkerson();
            var graph = new int[4][];

            for (int i = 0; i < graph.Length; i++)
            {
                graph[i] = new int[4];
            }

            graph[0][1] = 3;
            graph[0][2] = 2;
            graph[1][2] = 5;
            graph[1][3] = 2;
            graph[2][3] = 3;

            Assert.Equal(5,sut.MaxFlow(graph));
        }

        [Fact]
        public void BaselinWithStraightLines()
        {
            var sut = new FordFulkerson();
            var graph = new int[4][];

            for (int i = 0; i < graph.Length; i++)
            {
                graph[i] = new int[4];
            }

            graph[0][1] = 3;
            graph[0][2] = 2;
            graph[1][3] = 2;
            graph[2][3] = 3;

            Assert.Equal(4, sut.MaxFlow(graph));
        }

        [Fact]
        public void Baseline()
        {
            var sut = new FordFulkerson();
            var graph = new int[6][];

            graph[0] = new [] { 0, 16, 13, 0, 0, 0 };
            graph[1] = new [] { 0, 0, 10, 12, 0, 0};
            graph[2] = new [] { 0, 4, 0, 0, 14, 0 };
            graph[3] = new [] { 0, 0, 9, 0, 0, 20 };
            graph[4] = new[] { 0, 0, 0, 7, 0, 4 };
            graph[5] = new[] { 0, 0, 0, 0, 0, 0 };

            Assert.Equal(23, sut.MaxFlow(graph));
        }
    }
}
