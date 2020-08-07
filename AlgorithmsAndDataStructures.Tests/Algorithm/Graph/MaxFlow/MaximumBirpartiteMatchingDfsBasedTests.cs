using AlgorithmsAndDataStructures.Algorithms.Graph.MaximumFlow;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Graph.MaxFlow
{
    public class MaximumBirpartiteMatchingDfsBasedTests
    {
        [Fact]
        public void FourVerticesBipartite()
        {
            var sut = new MaximumBirpartiteMatchingDfsBased();
            var graph = new int[4][];
            graph[0] = new[] { 0, 1, 0, 1 };
            graph[1] = new[] { 0, 0, 0, 0 };
            graph[2] = new[] { 0, 1, 0, 0 };
            graph[3] = new[] { 0, 0, 0, 0 };

            Assert.Equal(2, sut.GetMaxMatching(graph));
        }

        [Fact]
        public void SixVerticesBipartite()
        {
            var sut = new MaximumBirpartiteMatchingDfsBased();
            var graph = new int[6][];

            graph[0] = new[] { 0, 1, 1, 0, 0, 0 };
            graph[1] = new[] { 1, 0, 0, 1, 0, 0 };
            graph[2] = new[] { 0, 0, 1, 0, 0, 0 };
            graph[3] = new[] { 0, 0, 1, 1, 0, 0 };
            graph[4] = new[] { 0, 0, 0, 0, 0, 0 };
            graph[5] = new[] { 0, 0, 0, 0, 0, 1 };

            Assert.Equal(5, sut.GetMaxMatching(graph));
        }
    }
}
