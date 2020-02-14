using AlgorithmsAndDataStructures.Algorithms.Graph.Common;
using AlgorithmsAndDataStructures.Algorithms.Graph.Misc;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Graph
{
    public class BiconnectedGraphTests
    {
        [Fact]
        public void TriangularGraphIsBiconnected()
        {
            var sut = new BiconnectedGraph();
            var graph = new UndirectedGraph(3);
            graph.Connect(0, 1);
            graph.Connect(1, 2);
            graph.Connect(2, 0);

            Assert.True(sut.IsBiconnected(graph));
        }

        [Fact]
        public void LinedUpGraphIsNotBiconnected()
        {
            var sut = new BiconnectedGraph();
            var graph = new UndirectedGraph(3);
            graph.Connect(0, 1);
            graph.Connect(1, 2);

            Assert.False(sut.IsBiconnected(graph));
        }

        [Fact]
        public void TwoVerticesGraphIsBiconnected()
        {
            var sut = new BiconnectedGraph();
            var graph = new UndirectedGraph(2);
            graph.Connect(0, 1);

            Assert.True(sut.IsBiconnected(graph));
        }

        [Fact]
        public void DenseGraphIsBiconnected()
        {
            var sut = new BiconnectedGraph();
            var graph = new UndirectedGraph(5);
            graph.Connect(1, 0);
            graph.Connect(0, 2);
            graph.Connect(2, 1);
            graph.Connect(0, 3);
            graph.Connect(3, 4);
            graph.Connect(2, 4);

            Assert.True(sut.IsBiconnected(graph));
        }

        [Fact]
        public void DenseGraphWithoutBackedgeIsNotBiconnected()
        {
            var sut = new BiconnectedGraph();
            var graph = new UndirectedGraph(5);
            graph.Connect(1, 0);
            graph.Connect(0, 2);
            graph.Connect(2, 1);
            graph.Connect(0, 3);
            graph.Connect(3, 4);

            Assert.False(sut.IsBiconnected(graph));
        }
    }
}
