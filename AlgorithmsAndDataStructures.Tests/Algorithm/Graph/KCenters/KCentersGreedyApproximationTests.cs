using AlgorithmsAndDataStructures.Algorithms.Graph.KCenters;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Graph.KCenters
{
    public class KCentersGreedyApproximationTests
    {
        [Fact]
        public void BaselineForTwoCenters()
        {
            var sut = new KCentersGreedyApproximation();
            var graph = new int[4][];
            graph[0] = new int[] { 0, 10, 6, 7 };
            graph[1] = new int[] { 10, 0, 8, 5 };
            graph[2] = new int[] { 6, 8, 0, 12 };
            graph[3] = new int[] { 7, 5, 12, 0 };

            Assert.Collection(sut.GetKCenters(graph, 2), 
                arg => Assert.Equal(0, arg),
                arg => Assert.Equal(1, arg));
        }

        [Fact]
        public void BaselineForThreeCenters()
        {
            var sut = new KCentersGreedyApproximation();
            var graph = new int[4][];
            graph[0] = new int[] { 0, 10, 6, 7 };
            graph[1] = new int[] { 10, 0, 8, 5 };
            graph[2] = new int[] { 6, 8, 0, 12 };
            graph[3] = new int[] { 7, 5, 12, 0 };

            Assert.Collection(sut.GetKCenters(graph, 3),
                arg => Assert.Equal(0, arg),
                arg => Assert.Equal(1, arg),
                arg => Assert.Equal(2, arg));
        }
    }
}
