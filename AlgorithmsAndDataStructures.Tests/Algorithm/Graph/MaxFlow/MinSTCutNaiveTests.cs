using AlgorithmsAndDataStructures.Algorithms.Graph.MinCut;
using System;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Graph.MaxFlow
{
    public class MinSTCutNaiveTests
    {
        [Fact]
        public void Baseline()
        {
            var sut = new MinStCutNaive();
            var graph = new int[4][];

            graph[0] = new [] { 0, 1, 1, 1 };
            graph[1] = new [] { 1, 0, 0, 1 };
            graph[2] = new [] { 1, 0, 0, 1 };
            graph[3] = new [] { 1, 1, 1, 0 };

            var minCut = sut.GetStCut(graph);

            Assert.Collection(minCut, 
                arg => 
                {
                    var (item1, item2) = arg;
                    Assert.Equal(0, item1);
                    Assert.Equal(1, item2);
                },
                arg =>
                {
                    var (item1, item2) = arg;
                    Assert.Equal(3, item1);
                    Assert.Equal(1, item2);
                });
        }
    }
}
