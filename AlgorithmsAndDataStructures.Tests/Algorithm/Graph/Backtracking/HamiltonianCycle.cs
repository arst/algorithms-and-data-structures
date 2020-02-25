using AlgorithmsAndDataStructures.Algorithms.Graph.Backtracking;
using AlgorithmsAndDataStructures.Algorithms.Graph.Common;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Graph.Backtracking
{
    public class HamiltonianCycleTest
    {
        [Fact]
        public void Baseline()
        {
            var sut = new HamiltonPath();
            var graph = new UndirectedGraph(5);
            graph.Connect(0, 1);
            graph.Connect(0, 3);
            graph.Connect(1, 2);
            graph.Connect(1, 3);
            graph.Connect(1, 4);
            graph.Connect(2, 4);
            graph.Connect(3, 4);

            var result = sut.HasHamiltonPath(graph);

            Assert.True(result.hasCycle);
            Assert.True(result.hasPath);
            Assert.Collection(result.path, 
                arg => Assert.Equal(0, arg),
                arg => Assert.Equal(1, arg),
                arg => Assert.Equal(2, arg),
                arg => Assert.Equal(4, arg),
                arg => Assert.Equal(3, arg),
                arg => Assert.Equal(0, arg));
        }

        [Fact]
        public void BaselineWithNoCycle()
        {
            var sut = new HamiltonPath();
            var graph = new UndirectedGraph(5);
            graph.Connect(0, 1);
            graph.Connect(0, 3);
            graph.Connect(1, 2);
            graph.Connect(1, 3);
            graph.Connect(1, 4);
            graph.Connect(2, 4);

            var result = sut.HasHamiltonPath(graph);

            Assert.False(result.hasCycle);
            Assert.True(result.hasPath);
        }

        [Fact]
        public void BaselineWithNoPath()
        {
            var sut = new HamiltonPath();
            var graph = new UndirectedGraph(5);
            graph.Connect(0, 1);
            graph.Connect(0, 3);
            graph.Connect(1, 2);
            graph.Connect(1, 4);
            graph.Connect(2, 4);

            var result = sut.HasHamiltonPath(graph);

            Assert.False(result.hasCycle);
            Assert.False(result.hasPath);
        }
    }
}
