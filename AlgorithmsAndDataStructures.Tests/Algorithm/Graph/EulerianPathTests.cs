using AlgorithmsAndDataStructures.Algorithms.Graph.Common;
using AlgorithmsAndDataStructures.Algorithms.Graph.Misc;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Graph
{
    public class EulerianPathTests
    {
        [Fact]
        public void EmptyGraphIsEulerian() 
        {
            var sut = new EulerianPath();
            var graph = new UndirectedGraph(0);
            var result = sut.IsEulerian(graph);

            Assert.True(result.hasEulerianCycle);
        }

        [Fact]
        public void OneVerticeGraphIsEulerian()
        {
            var sut = new EulerianPath();
            var graph = new UndirectedGraph(1);
            var result = sut.IsEulerian(graph);

            Assert.True(result.hasEulerianCycle);
        }

        [Fact]
        public void TwoVerticeGraphIsSemiEulerian()
        {
            var sut = new EulerianPath();
            var graph = new UndirectedGraph(2);
            graph.Connect(0,1);
            var result = sut.IsEulerian(graph);

            Assert.False(result.hasEulerianCycle);
            Assert.True(result.hasEulerianPath);
        }

        [Fact]
        public void ThreeVerticeGraphIsEulerian()
        {
            var sut = new EulerianPath();
            var graph = new UndirectedGraph(3);
            graph.Connect(0, 1);
            graph.Connect(1, 2);
            graph.Connect(2, 0);
            var result = sut.IsEulerian(graph);

            Assert.True(result.hasEulerianCycle);
        }

        [Fact]
        public void SemiEulerianGraph()
        {
            var sut = new EulerianPath();
            var graph = new UndirectedGraph(5);
            graph.Connect(1, 0);
            graph.Connect(0, 2);
            graph.Connect(2, 1);
            graph.Connect(0, 3);
            graph.Connect(3, 4);
            var result = sut.IsEulerian(graph);

            Assert.False(result.hasEulerianCycle);
            Assert.True(result.hasEulerianPath);
        }

        [Fact]
        public void FullEulerianGraph()
        {
            var sut = new EulerianPath();
            var graph = new UndirectedGraph(5);
            graph.Connect(1, 0);
            graph.Connect(0, 2);
            graph.Connect(2, 1);
            graph.Connect(0, 3);
            graph.Connect(3, 4);
            graph.Connect(4, 0);
            var result = sut.IsEulerian(graph);

            Assert.True(result.hasEulerianCycle);
        }

        [Fact]
        public void NonEulerianGraph()
        {
            var sut = new EulerianPath();
            var graph = new UndirectedGraph(5);
            graph.Connect(1, 0);
            graph.Connect(0, 2);
            graph.Connect(2, 1);
            graph.Connect(0, 3);
            graph.Connect(3, 4);
            graph.Connect(1, 3);
            var result = sut.IsEulerian(graph);

            Assert.False(result.hasEulerianCycle);
            Assert.False(result.hasEulerianPath);
        }

        [Fact]
        public void NonConnectedGraphIsNonEulerian()
        {
            var sut = new EulerianPath();
            var graph = new UndirectedGraph(5);
            var result = sut.IsEulerian(graph);

            Assert.False(result.hasEulerianCycle);
            Assert.False(result.hasEulerianPath);
        }
    }
}
