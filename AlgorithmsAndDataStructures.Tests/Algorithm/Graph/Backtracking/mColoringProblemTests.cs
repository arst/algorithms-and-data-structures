using AlgorithmsAndDataStructures.Algorithms.Graph.Backtracking;
using AlgorithmsAndDataStructures.Algorithms.Graph.Common;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Graph.Backtracking
{
    public class mColoringProblemTests
    {
        [Fact]
        public void Baseline()
        {
            var sut = new mColoringProblem();
            var graph = new UndirectedGraph(4);
            graph.Connect(0, 1);
            graph.Connect(0, 2);
            graph.Connect(0, 3);
            graph.Connect(1, 2);
            graph.Connect(2, 3);

            var result = sut.CanBeColored(graph, 3);

            Assert.True(result);
        }
    }
}
