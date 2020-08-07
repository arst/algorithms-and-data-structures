using AlgorithmsAndDataStructures.Algorithms.Graph.MaximumFlow;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Graph.MaxFlow
{
    public class EdgeDisjointPathTests
    {
        [Fact]
        public void NoPaths()
        {
            var sut = new EdgeDisjointPath();
            var graph = new int[4][];

            for (var i = 0; i < graph.Length; i++)
            {
                graph[i] = new int[4];
            }

            graph[1][2] = 1;
            graph[1][3] = 1;
            graph[2][3] = 1;

            Assert.Equal(0, sut.GetEdgeDisjointPathCount(graph));
        }

        [Fact]
        public void SinlgePath()
        {
            var sut = new EdgeDisjointPath();
            var graph = new int[4][];

            for (var i = 0; i < graph.Length; i++)
            {
                graph[i] = new int[4];
            }

            graph[0][1] = 1;
            graph[1][2] = 1;
            graph[1][3] = 1;
            graph[2][3] = 1;

            Assert.Equal(1, sut.GetEdgeDisjointPathCount(graph));
        }

        [Fact]
        public void BaselineWithZigZagPath()
        {
            var sut = new EdgeDisjointPath();
            var graph = new int[4][];

            for (var i = 0; i < graph.Length; i++)
            {
                graph[i] = new int[4];
            }

            graph[0][1] = 1;
            graph[0][2] = 1;
            graph[1][2] = 1;
            graph[1][3] = 1;
            graph[2][3] = 1;

            Assert.Equal(2, sut.GetEdgeDisjointPathCount(graph));
        }

        [Fact]
        public void BaselinWithStraightLines()
        {
            var sut = new EdgeDisjointPath();
            var graph = new int[4][];

            for (var i = 0; i < graph.Length; i++)
            {
                graph[i] = new int[4];
            }

            graph[0][1] = 1;
            graph[0][2] = 1;
            graph[1][3] = 1;
            graph[2][3] = 1;

            Assert.Equal(2, sut.GetEdgeDisjointPathCount(graph));
        }

        [Fact]
        public void BaselineSmall()
        {
            var sut = new EdgeDisjointPath();
            var graph = new int[6][];

            graph[0] = new[] { 0, 1, 1, 0, 0, 0 };
            graph[1] = new[] { 0, 0, 1, 1, 0, 0 };
            graph[2] = new[] { 0, 1, 0, 0, 1, 0 };
            graph[3] = new[] { 0, 0, 1, 0, 0, 1 };
            graph[4] = new[] { 0, 0, 0, 1, 0, 1 };
            graph[5] = new[] { 0, 0, 0, 0, 0, 0 };

            Assert.Equal(2, sut.GetEdgeDisjointPathCount(graph));
        }

        [Fact]
        public void Baseline()
        {
            var sut = new EdgeDisjointPath();
            var graph = new int[8][];
            graph[0]= new [] { 0, 1, 1, 1, 0, 0, 0, 0};
            graph[1] = new[] { 0, 0, 1, 0, 0, 0, 0, 0 };
            graph[2] = new[] { 0, 0, 0, 1, 0, 0, 1, 0 };
            graph[3] = new[] { 0, 0, 0, 0, 0, 0, 1, 0 };
            graph[4] = new[] { 0, 0, 1, 0, 0, 0, 0, 1 };
            graph[5] = new[] { 0, 1, 0, 0, 0, 0, 0, 1 };
            graph[6] = new[] { 0, 0, 0, 0, 0, 1, 0, 1 };
            graph[7] = new[] { 0, 0, 0, 0, 0, 0, 0, 0 };

            Assert.Equal(2, sut.GetEdgeDisjointPathCount(graph));
        }
    }
}
