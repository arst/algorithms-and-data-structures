﻿using AlgorithmsAndDataStructures.Algorithms.Graph.MaximumFlow;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Graph.MaxFlow
{
    public class STCutFordFulkersonBasedTests
    {
        [Fact]
        public void Baseine()
        {
            var sut = new STCutFordFulkersonBased();
            var graph = new int[6][];
            graph[0] = new[] { 0, 16, 13, 0, 0, 0 };
            graph[1] = new[] { 0, 0, 10, 12, 0, 0 };
            graph[2] = new[] { 0, 4, 0, 0, 14, 0 };
            graph[3] = new[] { 0, 0, 9, 0, 0, 20 };
            graph[4] = new[] { 0, 0, 0, 7, 0, 4 };
            graph[5] = new[] { 0, 0, 0, 0, 0, 0 };

            var stCut = sut.GetSTCut(graph);

            Assert.Collection(stCut,
                arg =>
                {
                    Assert.Equal(1, arg.Item1);
                    Assert.Equal(3, arg.Item2);
                },
                arg => 
                {
                    Assert.Equal(4, arg.Item1);
                    Assert.Equal(3, arg.Item2);
                },
                arg =>
                {
                    Assert.Equal(4, arg.Item1);
                    Assert.Equal(5, arg.Item2);
                });
        }
    }
}
