using AlgorithmsAndDataStructures.Algorithms.Graph.MaximumFlow;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Graph.MaxFlow
{
    public class MinSTCutNaiveTests
    {
        [Fact]
        public void Baseline()
        {
            var sut = new MinSTCutNaive();
            var graph = new int[4][];

            graph[0] = new[] { 0, 1, 1, 1 };
            graph[1] = new[] { 1, 0, 0, 1 };
            graph[2] = new[] { 1, 0, 0, 1 };
            graph[3] = new[] { 1, 1, 1, 0 };

            var minCut = sut.GetSTCut(graph);

            Assert.Collection(minCut, 
                arg => 
                {
                    Assert.Equal(0, arg.Item1);
                    Assert.Equal(1, arg.Item2);
                },
                arg =>
                {
                    Assert.Equal(3, arg.Item1);
                    Assert.Equal(1, arg.Item2);
                });
        }
    }
}
