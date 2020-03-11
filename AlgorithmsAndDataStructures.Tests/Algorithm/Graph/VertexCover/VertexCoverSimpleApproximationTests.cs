using AlgorithmsAndDataStructures.Algorithms.Graph.VertexCover;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Graph.VertexCover
{
    public class VertexCoverSimpleApproximationTests
    {
        [Fact]
        public void SingleVertexCover()
        {
            var sut = new VertexCoverSimpleApproximation();
            var graph = new int[4][];
            graph[0] = new int[] { 0, 0, 0, 1 };
            graph[1] = new int[] { 0, 0, 0, 1 };
            graph[2] = new int[] { 0, 0, 0, 1 };
            graph[3] = new int[] { 1, 1, 1, 0 };

            var vertexCover = sut.GetVertexCover(graph);

            Assert.Collection(vertexCover, arg => Assert.Equal(0, arg), arg => Assert.Equal(3, arg));
        }

        [Fact]
        public void SingleVertexCoverOptimized()
        {
            var sut = new VertexCoverSimpleApproximation();
            var graph = new int[4][];
            graph[0] = new int[] { 0, 0, 0, 1 };
            graph[1] = new int[] { 0, 0, 0, 1 };
            graph[2] = new int[] { 0, 0, 0, 1 };
            graph[3] = new int[] { 1, 1, 1, 0 };

            var vertexCover = sut.GetVertexCoverOptimized(graph);

            Assert.Collection(vertexCover, arg => Assert.Equal(3, arg));
        }

        [Fact]
        public void Baseline()
        {
            var sut = new VertexCoverSimpleApproximation();
            var graph = new int[7][];
            graph[0] = new int[] { 0, 1, 1, 0, 0, 0, 0 };
            graph[1] = new int[] { 1, 0, 0, 1, 0, 0, 0 };
            graph[2] = new int[] { 1, 0, 0, 0, 0, 0, 0 };
            graph[3] = new int[] { 0, 1, 0, 0, 1, 0, 0 };
            graph[4] = new int[] { 0, 0, 0, 1, 0, 1, 0 };
            graph[5] = new int[] { 0, 0, 0, 0, 1, 0, 1 };
            graph[6] = new int[] { 0, 0, 0, 0, 0, 1, 0 };

            var vertexCover = sut.GetVertexCover(graph);

            Assert.Collection(vertexCover,
                arg => Assert.Equal(0, arg),
                arg => Assert.Equal(1, arg),
                arg => Assert.Equal(3, arg),
                arg => Assert.Equal(4, arg),
                arg => Assert.Equal(5, arg),
                arg => Assert.Equal(6, arg));
        }

        [Fact]
        public void BaselineOptimized()
        {
            var sut = new VertexCoverSimpleApproximation();
            var graph = new int[7][];
            graph[0] = new int[] { 0, 1, 1, 0, 0, 0, 0 };
            graph[1] = new int[] { 1, 0, 0, 1, 0, 0, 0 };
            graph[2] = new int[] { 1, 0, 0, 0, 0, 0, 0 };
            graph[3] = new int[] { 0, 1, 0, 0, 1, 0, 0 };
            graph[4] = new int[] { 0, 0, 0, 1, 0, 1, 0 };
            graph[5] = new int[] { 0, 0, 0, 0, 1, 0, 1 };
            graph[6] = new int[] { 0, 0, 0, 0, 0, 1, 0 };

            var vertexCover = sut.GetVertexCoverOptimized(graph);

            Assert.Collection(vertexCover,
                arg => Assert.Equal(0, arg),
                arg => Assert.Equal(3, arg),
                arg => Assert.Equal(5, arg));
        }
    }
}
