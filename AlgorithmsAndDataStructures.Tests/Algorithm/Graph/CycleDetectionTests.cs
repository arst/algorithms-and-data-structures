using AlgorithmsAndDataStructures.Algorithms.Graph.Misc;
using AlgorithmsAndDataStructures.DataStructures.Graph;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Graph
{
    public class CycleDetectionTests
    {
        [Fact]
        public void SelfCycleIsDetected()
        {
            var graph = new[]
                {
                    new GraphVertex<int>
                    {
                        Value = 1,
                        AdjacentVertices = new System.Collections.Generic.List<int> { 0 }
                    },
                };

            Assert.True(CycleDetector.IsCyclic(graph));
        }

        [Fact]
        public void SimpleTwoNodeCycleIsDetected()
        {
            var graph = new[]
                {
                    new GraphVertex<int>
                    {
                        Value = 1,
                        AdjacentVertices = new System.Collections.Generic.List<int> { 1 }
                    },
                    new GraphVertex<int>
                    {
                        Value = 2,
                        AdjacentVertices = new System.Collections.Generic.List<int> { 0 }
                    },
                };

            Assert.True(CycleDetector.IsCyclic(graph));
        }

        [Fact]
        public void CycleIsNotDetectedForNonCycledGraph()
        {
            var graph = new[]
                {
                    new GraphVertex<int>
                    {
                        Value = 1,
                        AdjacentVertices = new System.Collections.Generic.List<int> { 1 }
                    },
                    new GraphVertex<int>
                    {
                        Value = 2,
                    },
                };

            Assert.True(CycleDetector.IsCyclic(graph));
        }

        [Fact]
        public void DisconnectedGraphCycleIsDetected()
        {
            var graph = new[]
                {
                    new GraphVertex<int>
                    {
                        Value = 1,
                    },
                    new GraphVertex<int>
                    {
                        Value = 2,
                        AdjacentVertices = new System.Collections.Generic.List<int> { 2 }
                    },
                    new GraphVertex<int>
                    {
                        Value = 2,
                        AdjacentVertices = new System.Collections.Generic.List<int> { 1 }
                    },
                };

            Assert.True(CycleDetector.IsCyclic(graph));
        }

        [Fact]
        public void DisconnectedGraphWithMultipleCyclesIsDetected()
        {
            var graph = new[]
                {
                    new GraphVertex<int>
                    {
                        Value = 1,
                        AdjacentVertices = new System.Collections.Generic.List<int> { 1, 2 }
                    },
                    new GraphVertex<int>
                    {
                        Value = 2,
                        AdjacentVertices = new System.Collections.Generic.List<int> { 2 }
                    },
                    new GraphVertex<int>
                    {
                        Value = 2,
                        AdjacentVertices = new System.Collections.Generic.List<int> { 0, 3 }
                    },
                    new GraphVertex<int>
                    {
                        Value = 2,
                        AdjacentVertices = new System.Collections.Generic.List<int> { 3 }
                    },
                };

            Assert.True(CycleDetector.IsCyclic(graph));
        }
    }
}
