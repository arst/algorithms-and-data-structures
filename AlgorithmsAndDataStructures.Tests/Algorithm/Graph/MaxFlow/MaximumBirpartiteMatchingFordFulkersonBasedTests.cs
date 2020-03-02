using AlgorithmsAndDataStructures.Algorithms.Graph.MaximumFlow;
using System;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Graph.MaxFlow
{
    public class MaximumBirpartiteMatchingFordFulkersonBasedTests
    {
        [Fact]
        public void FourVerticesBipartite()
        {
            var sut = new MaximumBirpartiteMatchingFordFulkersonBased();
            var graph = new int[4][];
            graph[0] = new int[] { 0, 1, 0, 1 };
            graph[1] = new int[] { 0, 0, 0, 0 };
            graph[2] = new int[] { 0, 1, 0, 0 };
            graph[3] = new int[] { 0, 0, 0, 0 };

            Assert.Equal(2, sut.MaxMatching(graph));
        }

        [Fact]
        public void CycleGraphWithEvenCycle()
        {
            var sut = new MaximumBirpartiteMatchingFordFulkersonBased();
            var graph = new int[4][];
            graph[0] = new[] { 0, 1, 0, 1 };
            graph[1] = new[] { 1, 0, 1, 0 };
            graph[2] = new[] { 0, 1, 0, 1 };
            graph[3] = new[] { 1, 0, 1, 0 };

            Assert.Equal(2, sut.MaxMatching(graph));
        }

        [Fact]
        public void CycleGraphWithOddCycle()
        {
            var sut = new MaximumBirpartiteMatchingFordFulkersonBased();
            var graph = new int[5][];
            graph[0] = new[] { 0, 1, 0, 1, 0 };
            graph[1] = new[] { 1, 0, 1, 0, 0 };
            graph[2] = new[] { 0, 1, 0, 0, 1 };
            graph[3] = new[] { 1, 0, 0, 0, 1 };
            graph[4] = new[] { 0, 0, 1, 1, 0 };

            Assert.Throws<Exception>(() => sut.MaxMatching(graph));
        }
    }
}
