using AlgorithmsAndDataStructures.Algorithms.Graph.Misc;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Graph
{
    public class TarjansAlgorithmTests
    {
        [Fact]
        public void EmptyGraphHashNoArticulationPoints()
        {
            var sut = new TarjansAlgorithm();
            Assert.Empty(sut.GetArticulationPoints(new Algorithms.Graph.Common.UndirectedGraph(0)));
        }

        [Fact]
        public void OneVerticeGraphHashNoArticulationPoints()
        {
            var sut = new TarjansAlgorithm();
            Assert.Empty(sut.GetArticulationPoints(new Algorithms.Graph.Common.UndirectedGraph(1)));
        }

        [Fact]
        public void TwoVerticeGraphHashNoArticulationPoints()
        {
            var sut = new TarjansAlgorithm();
            var graph = new Algorithms.Graph.Common.UndirectedGraph(2);
            graph.Connect(0,1);
            Assert.Empty(sut.GetArticulationPoints(graph));
        }

        [Fact]
        public void ThreeVerticeGraphHashOneArticulationPoint()
        {
            var sut = new TarjansAlgorithm();
            var graph = new Algorithms.Graph.Common.UndirectedGraph(3);
            graph.Connect(0, 1);
            graph.Connect(1, 2);
            Assert.Collection<int>(sut.GetArticulationPoints(graph), arg => Assert.Equal(1, arg));
        }

        [Fact]
        public void NonDenseGraph()
        {
            var sut = new TarjansAlgorithm();
            var graph = new Algorithms.Graph.Common.UndirectedGraph(5);
            graph.Connect(1, 0);
            graph.Connect(0, 2);
            graph.Connect(2, 1);
            graph.Connect(0, 3);
            graph.Connect(3, 4);
            Assert.Collection<int>(sut.GetArticulationPoints(graph), arg => Assert.Equal(0, arg), arg => Assert.Equal(3, arg));
        }

        [Fact]
        public void DenseGraph()
        {
            var sut = new TarjansAlgorithm();
            var graph = new Algorithms.Graph.Common.UndirectedGraph(7);
            graph.Connect(0, 1);
            graph.Connect(1, 2);
            graph.Connect(2, 0);
            graph.Connect(1, 3);
            graph.Connect(1, 4);
            graph.Connect(1, 6);
            graph.Connect(3, 5);
            graph.Connect(4, 5);
            Assert.Collection<int>(sut.GetArticulationPoints(graph), arg => Assert.Equal(1, arg));
        }

        [Fact]
        public void LinedUpGraph()
        {
            var sut = new TarjansAlgorithm();
            var graph = new Algorithms.Graph.Common.UndirectedGraph(4);
            graph.Connect(0, 1);
            graph.Connect(1, 2);
            graph.Connect(2, 3);
            Assert.Collection<int>(sut.GetArticulationPoints(graph), arg => Assert.Equal(1, arg), arg => Assert.Equal(2, arg));
        }
    }
}
