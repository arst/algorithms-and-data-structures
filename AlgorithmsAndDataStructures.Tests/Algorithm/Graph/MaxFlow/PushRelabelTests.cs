using AlgorithmsAndDataStructures.Algorithms.Graph.MaximumFlow;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Graph.MaxFlow
{
    public class PushRelabelTests
    {
        [Fact]
        public void Baseline()
        {
            var sut = new PushRelabel();
            var graph = new int[6][];

            for (int i = 0; i < graph.Length; i++)
            {
                graph[i] = new int[graph.Length];
            }

            graph[0][1] = 16;
            graph[0][2] = 13;
            graph[1][2] = 10;
            graph[1][3] = 12;
            graph[2][1] = 4;
            graph[2][4] = 14;
            graph[3][2] = 9;
            graph[3][5] = 20;
            graph[4][3] = 7;
            graph[4][5] = 4;

            Assert.Equal(23, sut.GetMaxFlow(graph));
        }
    }
}
