using AlgorithmsAndDataStructures.Algorithms.Graph;
using AlgorithmsAndDataStructures.DataStructures.Graph;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Graph
{
    public class CycleDetectionTests
    {
        [Fact]
        public void SelfCycleIsDetected()
        {
            var sut = new CycleDetection();
            var graph = new GraphNode<int>[]
                {
                    new GraphNode<int>()
                    {
                        Value = 1,
                        AdjacentNodes = new System.Collections.Generic.List<int>() { 0 }
                    },
                };

            Assert.True(sut.IsCyclic(graph));
        }

        [Fact]
        public void SimpleTwoNodeCycleIsDetected()
        {
            var sut = new CycleDetection();
            var graph = new GraphNode<int>[]
                {
                    new GraphNode<int>()
                    {
                        Value = 1,
                        AdjacentNodes = new System.Collections.Generic.List<int>() { 1 }
                    },
                    new GraphNode<int>()
                    {
                        Value = 2,
                        AdjacentNodes = new System.Collections.Generic.List<int>() { 0 }
                    },
                };

            Assert.True(sut.IsCyclic(graph));
        }

        [Fact]
        public void CycleIsNotDetectedForNonCycledGraph()
        {
            var sut = new CycleDetection();
            var graph = new GraphNode<int>[]
                {
                    new GraphNode<int>()
                    {
                        Value = 1,
                        AdjacentNodes = new System.Collections.Generic.List<int>() { 1 }
                    },
                    new GraphNode<int>()
                    {
                        Value = 2,
                    },
                };

            Assert.False(sut.IsCyclic(graph));
        }

        [Fact]
        public void DisconnectedGraphCycleIsDetected()
        {
            var sut = new CycleDetection();
            var graph = new GraphNode<int>[]
                {
                    new GraphNode<int>()
                    {
                        Value = 1,
                    },
                    new GraphNode<int>()
                    {
                        Value = 2,
                        AdjacentNodes = new System.Collections.Generic.List<int>() { 2 }
                    },
                    new GraphNode<int>()
                    {
                        Value = 2,
                        AdjacentNodes = new System.Collections.Generic.List<int>() { 1 }
                    },
                };

            Assert.True(sut.IsCyclic(graph));
        }

        [Fact]
        public void DisconnectedGraphWithMultipleCyclesIsDetected()
        {
            var sut = new CycleDetection();
            var graph = new GraphNode<int>[]
                {
                    new GraphNode<int>()
                    {
                        Value = 1,
                        AdjacentNodes = new System.Collections.Generic.List<int>() { 1, 2 }
                    },
                    new GraphNode<int>()
                    {
                        Value = 2,
                        AdjacentNodes = new System.Collections.Generic.List<int>() { 2 }
                    },
                    new GraphNode<int>()
                    {
                        Value = 2,
                        AdjacentNodes = new System.Collections.Generic.List<int>() { 0, 3 }
                    },
                    new GraphNode<int>()
                    {
                        Value = 2,
                        AdjacentNodes = new System.Collections.Generic.List<int>() { 3 }
                    },
                };

            Assert.True(sut.IsCyclic(graph));
        }
    }
}
