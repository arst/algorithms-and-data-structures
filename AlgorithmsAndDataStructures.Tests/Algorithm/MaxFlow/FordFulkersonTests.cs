using AlgorithmsAndDataStructures.Algorithms.Graph.MaximumFlow;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.MaxFlow
{
    public class FordFulkersonTests
    {
        [Fact]
        public void Baseline()
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
    }
}
