using AlgorithmsAndDataStructures.DataStructures.Graph;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.DataStructures.Graph
{
    public class AdjacencyListGraphTests
    {
        [Fact]
        public void DFSNonRecursive()
        {
            var sut = new AdjacencyListGraph<int>();
            sut.AddEdge(0, 1);
            sut.AddEdge(0, 3);
            sut.AddEdge(1, 2);
            sut.AddEdge(3, 4);
            sut.AddEdge(4,5);

            var dfs = sut.DepthFirstSearch();

            for (var i = 0; i < 6; i++)
            {
                Assert.Equal(i, dfs[i]);
            }
        }

        [Fact]
        public void DFSRecursive()
        {
            var sut = new AdjacencyListGraph<int>();
            sut.AddEdge(0, 1);
            sut.AddEdge(0, 3);
            sut.AddEdge(1, 2);
            sut.AddEdge(3, 4);
            sut.AddEdge(4, 5);

            var dfs = sut.DepthFirstSearch();

            for (var i = 0; i < 6; i++)
            {
                Assert.Equal(i, dfs[i]);
            }
        }

        [Fact]
        public void BFSNonRecursive()
        {
            var sut = new AdjacencyListGraph<int>();
            sut.AddEdge(0, 1);
            sut.AddEdge(0, 3);
            sut.AddEdge(1, 2);
            sut.AddEdge(3, 4);
            sut.AddEdge(4, 5);

            var bfs = sut.BreadthFirstSearch();

            Assert.Equal(0, bfs[0]);
            Assert.Equal(1, bfs[1]);
            Assert.Equal(3, bfs[2]);
            Assert.Equal(2, bfs[3]);
            Assert.Equal(4, bfs[4]);
            Assert.Equal(5, bfs[5]);
        }
    }
}
