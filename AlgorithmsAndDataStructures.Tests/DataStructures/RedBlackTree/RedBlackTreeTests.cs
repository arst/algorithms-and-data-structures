using Xunit;

namespace AlgorithmsAndDataStructures.Tests.DataStructures.RedBlackTree
{
    public class RedBlackTreeTests
    {
        [Fact]
        public void EmptyTreeHasZeroHeight()
        {
            var sut = new AlgorithmsAndDataStructures.DataStructures.RedBlackTree.RedBlackTree();

            Assert.Equal(0, sut.Height);
        }

        [Fact]
        public void CanInsertRootNode()
        {
            var sut = new AlgorithmsAndDataStructures.DataStructures.RedBlackTree.RedBlackTree();
            sut.Insert(3);

            Assert.Equal(0, sut.Height);
        }

        [Fact]
        public void TreeIsBalancedWhenLeftSideUnbalanced()
        {
            var sut = new AlgorithmsAndDataStructures.DataStructures.RedBlackTree.RedBlackTree();
            sut.Insert(5);
            sut.Insert(4);
            sut.Insert(3);

            Assert.Equal(1, sut.Height);
        }

        [Fact]
        public void TreeIsBalancedWhenRightSideUnbalanced()
        {
            var sut = new AlgorithmsAndDataStructures.DataStructures.RedBlackTree.RedBlackTree();
            sut.Insert(5);
            sut.Insert(6);
            sut.Insert(7);

            Assert.Equal(1, sut.Height);
        }

        [Fact]
        public void TreeIsBalancedWhenLeftRightSideUnbalanced()
        {
            var sut = new AlgorithmsAndDataStructures.DataStructures.RedBlackTree.RedBlackTree();
            sut.Insert(5);
            sut.Insert(3);
            sut.Insert(4);

            Assert.Equal(1, sut.Height);
        }

        [Fact]
        public void TreeIsBalancedWhenRightLeftSideUnbalanced()
        {
            var sut = new AlgorithmsAndDataStructures.DataStructures.RedBlackTree.RedBlackTree();
            sut.Insert(3);
            sut.Insert(5);
            sut.Insert(4);

            Assert.Equal(1, sut.Height);
        }
    }
}
