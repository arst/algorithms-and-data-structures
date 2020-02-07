using AlgorithmsAndDataStructures.Algorithms.Graph;
using AlgorithmsAndDataStructures.DataStructures.Graph;
using System;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Graph
{
    public class TopologicalSortTests
    {
        [Fact]
        public void TopologicalSortForOneVertexGraph()
        {
            var sut = new TopologicalSort();

            var node1 = new GraphNode<int>();

            var topologicalOrder = sut.GetTopologicalOrder(new GraphNode<int>[] { node1 });

            Assert.Single(topologicalOrder);
            Assert.Collection<int>(topologicalOrder, arg => Assert.Equal(0, arg));
        }

        [Fact]
        public void TopologicalSortForTwoVertexGraph()
        {
            var sut = new TopologicalSort();

            var node1 = new GraphNode<int>()
            { 
                AdjacentNodes = new System.Collections.Generic.List<int>() { 1 }
            };

            var node2 = new GraphNode<int>();

            var topologicalOrder = sut.GetTopologicalOrder(new GraphNode<int>[] { node1, node2 });

            Assert.Equal(2,topologicalOrder.Count);
            Assert.Collection<int>(topologicalOrder, arg => Assert.Equal(0, arg), arg => Assert.Equal(1, arg));
        }

        [Fact]
        public void TopologicalSortForGraphWithCycle()
        {
            var sut = new TopologicalSort();

            var node1 = new GraphNode<int>()
            {
                AdjacentNodes = new System.Collections.Generic.List<int>() { 1 }
            };

            var node2 = new GraphNode<int>()
            {
                AdjacentNodes = new System.Collections.Generic.List<int>() { 0 }
            };

            Assert.Throws<ArgumentException>(() => sut.GetTopologicalOrder(new GraphNode<int>[] { node1, node2 }));
        }

        [Fact]
        public void TopologicalSortForDisconectedGraph()
        {
            var sut = new TopologicalSort();

            var node1 = new GraphNode<int>()
            {
                AdjacentNodes = new System.Collections.Generic.List<int>() { 1 }
            };

            var node2 = new GraphNode<int>();

            var node3 = new GraphNode<int>();

            var topologicalOrder = sut.GetTopologicalOrder(new GraphNode<int>[] { node1, node2, node3 });

            Assert.Equal(3, topologicalOrder.Count);
            Assert.Collection<int>(topologicalOrder, arg => Assert.Equal(2, arg), arg => Assert.Equal(0, arg), arg => Assert.Equal(1, arg));
        }

        [Fact]
        public void Baseline()
        {
            var sut = new TopologicalSort();

            var node1 = new GraphNode<int>()
            {
                AdjacentNodes = new System.Collections.Generic.List<int>() { 1, 2 }
            };

            var node2 = new GraphNode<int>();

            var node3 = new GraphNode<int>()
            {
                AdjacentNodes = new System.Collections.Generic.List<int>() { 3, 5 }
            };

            var node4 = new GraphNode<int>()
            {
                AdjacentNodes = new System.Collections.Generic.List<int>() { 4 }
            };

            var node5 = new GraphNode<int>();

            var node6 = new GraphNode<int>();

            var topologicalOrder = sut.GetTopologicalOrder(new GraphNode<int>[] { node1, node2, node3, node4, node5, node6 });

            Assert.Equal(6, topologicalOrder.Count);
            Assert.Collection<int>(topologicalOrder, 
                arg => Assert.Equal(0, arg), 
                arg => Assert.Equal(2, arg), 
                arg => Assert.Equal(5, arg),
                arg => Assert.Equal(3, arg),
                arg => Assert.Equal(4, arg),
                arg => Assert.Equal(1, arg));
        }
    }
}
