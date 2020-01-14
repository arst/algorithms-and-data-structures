using Xunit;

namespace AlgorithmsAndDataStructures.Tests.DataStructures.AvlTree
{
    public class AvlTreeTests
    {
        [Fact]
        public void CanInsertRootNode()
        {
            var sut = new AlgorithmsAndDataStructures.DataStructures.AVLTree.AvlTree();
            sut.Insert(10);
            Assert.True(sut.IsBalanced);
        }

        [Fact]
        public void SimpleTreeIsBalanced()
        {
            var sut = new AlgorithmsAndDataStructures.DataStructures.AVLTree.AvlTree();
            sut.Insert(10);
            sut.Insert(11);
            sut.Insert(9);
            Assert.True(sut.IsBalanced);
        }

        [Fact]
        public void TreeIsBalancedWhenUnbalanceIsEqualToOne()
        {
            var sut = new AlgorithmsAndDataStructures.DataStructures.AVLTree.AvlTree();
            sut.Insert(10);
            sut.Insert(11);
            sut.Insert(9);
            sut.Insert(8);
            Assert.True(sut.IsBalanced);
        }

        [Fact]
        public void TreeIsUnbalancedWhenUnbalanceIsEqualToTwo()
        {
            var sut = new AlgorithmsAndDataStructures.DataStructures.AVLTree.AvlTree();
            sut.Insert(10);
            sut.Insert(11);
            sut.Insert(9);
            sut.Insert(8);
            sut.Insert(7);
            Assert.False(sut.IsBalanced);
        }
    }
}
