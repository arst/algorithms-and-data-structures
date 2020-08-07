using AlgorithmsAndDataStructures.Algorithms.Graph.MaximumFlow;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Graph.MaxFlow
{
    public class HopcroftKarpTests
    {
        [Fact]
        public void Trivial()
        {
            var sut = new HopcroftKarp();
            var graph = new int[4][];

            graph[0] = new[] { 0, 1, 0, 0 };
            graph[1] = new[] { 1, 0, 0, 0 };
            graph[2] = new[] { 0, 0, 0, 1 };
            graph[3] = new[] { 0, 0, 1, 0 };

            Assert.Equal(2, sut.GetMaxMathcing(graph));
        }

        [Fact]
        public void SimpleBaseline()
        {
            var sut = new HopcroftKarp();
            var graph = new int[4][];

            graph[0] = new[] { 0, 1, 0, 1 };
            graph[1] = new[] { 1, 0, 1, 0 };
            graph[2] = new[] { 0, 1, 0, 0 };
            graph[3] = new[] { 1, 0, 0, 0 };

            Assert.Equal(2, sut.GetMaxMathcing(graph));
        }

        [Fact]
        public void ComplexBaseline()
        {
            var sut = new HopcroftKarp();
            var graph = new int[8][];

            graph[0] = new[] { 0, 1, 0, 1, 0, 0, 0, 1 };
            graph[1] = new[] { 1, 0, 1, 0, 0, 0, 1, 0 };
            graph[2] = new[] { 0, 1, 0, 0, 0, 0, 0, 0 };
            graph[3] = new[] { 1, 0, 0, 0, 1, 0, 0, 0 };
            graph[4] = new[] { 0, 0, 0, 1, 0, 0, 0, 0 };
            graph[5] = new[] { 0, 0, 0, 0, 0, 0, 1, 0 };
            graph[6] = new[] { 0, 1, 0, 1, 0, 1, 0, 1 };
            graph[7] = new[] { 1, 0, 0, 0, 0, 0, 1, 0 };

            Assert.Equal(4, sut.GetMaxMathcing(graph));
        }
    }
}
