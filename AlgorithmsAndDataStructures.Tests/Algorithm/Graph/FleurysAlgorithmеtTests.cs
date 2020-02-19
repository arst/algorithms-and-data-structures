using AlgorithmsAndDataStructures.Algorithms.Graph.Common;
using AlgorithmsAndDataStructures.Algorithms.Graph.Misc;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Graph
{
    public class FleurysAlgorithmеtTests
    {
        [Fact]
        public void EmptyGraphHasEmptyEulerianTrail()
        {
            var sut = new FleurysAlgorithm();
            var graph = new UndirectedGraph(0);

            Assert.Empty(sut.GetEulerianTrail(graph));
        }

        [Fact]
        public void OneVerticeGraphHasEmptyEulerianTrail()
        {
            var sut = new FleurysAlgorithm();
            var graph = new UndirectedGraph(1);

            Assert.Empty(sut.GetEulerianTrail(graph));
        }

        [Fact]
        public void TwoVerticeGraphHasOneEdgeEulerianTrail()
        {
            var sut = new FleurysAlgorithm();
            var graph = new UndirectedGraph(2);
            graph.Connect(0, 1);

            Assert.Collection(sut.GetEulerianTrail(graph), arg =>
            {
                Assert.Equal(1, arg.Item1);
                Assert.Equal(0, arg.Item2);
            });
        }

        [Fact]
        public void ThreeVerticeGraphHasOneEdgeEulerianTrail()
        {
            var sut = new FleurysAlgorithm();
            var graph = new UndirectedGraph(3);
            graph.Connect(0, 1);
            graph.Connect(1, 2);

            Assert.Collection(sut.GetEulerianTrail(graph), arg =>
            {
                Assert.Equal(2, arg.Item1);
                Assert.Equal(1, arg.Item2);
            },
            arg =>
            {
                Assert.Equal(1, arg.Item1);
                Assert.Equal(0, arg.Item2);
            });
        }

        [Fact]
        public void BaseLine()
        {
            var sut = new FleurysAlgorithm();
            var graph = new UndirectedGraph(4);
            graph.Connect(0, 1);
            graph.Connect(0, 2);
            graph.Connect(1, 2);
            graph.Connect(2, 3);

            Assert.Collection(sut.GetEulerianTrail(graph), arg =>
            {
                Assert.Equal(3, arg.Item1);
                Assert.Equal(2, arg.Item2);
            },
            arg =>
            {
                Assert.Equal(2, arg.Item1);
                Assert.Equal(1, arg.Item2);
            },
            arg =>
            {
                Assert.Equal(1, arg.Item1);
                Assert.Equal(0, arg.Item2);
            },
            arg =>
            {
                Assert.Equal(0, arg.Item1);
                Assert.Equal(2, arg.Item2);
            });
        }
    }
}
