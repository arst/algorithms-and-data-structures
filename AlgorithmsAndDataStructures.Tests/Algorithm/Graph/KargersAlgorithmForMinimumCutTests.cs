using AlgorithmsAndDataStructures.Algorithms.Graph.Common;
using AlgorithmsAndDataStructures.Algorithms.Graph.Misc;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Graph
{
    public class KargersAlgorithmForMinimumCutTests
    {
        [Fact]
        public void Baseline()
        {
            var sut = new KargersAlgorithmForMinimumCut();
            var graph = new UndirectedGraph(4);
            graph.Connect(0, 1);
            graph.Connect(0, 2);
            graph.Connect(1, 3);
            graph.Connect(1, 2);
            graph.Connect(2, 3);

            var minCut = int.MaxValue;

            while (minCut > 2)
            {
                minCut = sut.MinCut(graph, 10000);

                Assert.NotInRange(minCut, 0, 1);
            }
        }
    }
}
