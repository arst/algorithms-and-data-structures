using AlgorithmsAndDataStructures.DataStructures.BinaryTrees;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.DataStructures.BinaryTree
{
    public class BinaryTreeTests
    {
        [Fact]
        public void InsertIntoEmptyTreeCreatesHead()
        {
            var sut = new BinaryTree<int>();
            Assert.Null(sut.GetRoot());
            sut.Insert(1);
            Assert.NotNull(sut.GetRoot());
            Assert.Equal(1, sut.GetRoot().Value);
        }

        [Fact]
        public void InsertAddsNodeToTheTreeWithEmptyLeaf()
        {
            var sut = new BinaryTree<int>();
            sut.Insert(1);
            sut.Insert(2);
            sut.Insert(3);

            Assert.NotNull(sut.GetRoot());
            Assert.Equal(2, sut.GetRoot().Left.Value);
            Assert.Equal(3, sut.GetRoot().Right.Value);

            sut.Insert(4);
            sut.Insert(5);
            sut.Insert(6);
            sut.Insert(7);

            Assert.Equal(4, sut.GetRoot().Left.Left.Value);
            Assert.Equal(5, sut.GetRoot().Left.Right.Value);

            Assert.Equal(6, sut.GetRoot().Right.Left.Value);
            Assert.Equal(7, sut.GetRoot().Right.Right.Value);
        }

        [Fact]
        public void DeleteRootAssignsNewRootValue()
        {
            var sut = new BinaryTree<int>();
            sut.Insert(1);
            sut.Insert(2);
            sut.Insert(3);

            sut.Delete(1);

            Assert.Equal(3, sut.GetRoot().Value);
            Assert.Equal(2, sut.GetRoot().Left.Value);
            Assert.Null(sut.GetRoot().Right);
        }

        [Fact]
        public void DeleteShrinkTreeFromTheBottomRight()
        {
            var sut = new BinaryTree<int>();
            sut.Insert(1);
            sut.Insert(2);
            sut.Insert(3);
            sut.Insert(4);
            sut.Insert(5);
            sut.Insert(6);
            sut.Insert(7);

            Assert.Equal(2, sut.GetRoot().Left.Value);
            Assert.NotNull(sut.GetRoot().Right.Right);

            sut.Delete(2);

            Assert.Equal(7, sut.GetRoot().Left.Value);
            Assert.Null(sut.GetRoot().Right.Right);
        }

        [Fact]
        public void DeleteShrinkTreeFromTheBottomLeft()
        {
            var sut = new BinaryTree<int>();
            sut.Insert(1);
            sut.Insert(2);
            sut.Insert(3);
            sut.Insert(4);
            sut.Insert(5);
            sut.Insert(6);
            sut.Insert(7);
            sut.Insert(8);

            Assert.Equal(2, sut.GetRoot().Left.Value);
            Assert.NotNull(sut.GetRoot().Left.Left.Left);

            sut.Delete(2);

            Assert.Equal(8, sut.GetRoot().Left.Value);
            Assert.Null(sut.GetRoot().Left.Left.Left);
        }

        [Fact]
        public void BreadthFirstTraversalTraverseTreeLevelByLevel()
        {
            var sut = new BinaryTree<int>();
            sut.Insert(1);
            sut.Insert(2);
            sut.Insert(3);
            sut.Insert(4);
            sut.Insert(5);
            sut.Insert(6);
            sut.Insert(7);
            sut.Insert(8);

            var bfsResult = sut.BreadthFirstTraversal();
            var counter = 0;

            for (var i = 1; i < 9; i++)
            {
                Assert.Equal(i, bfsResult[counter]);
                counter++;
            }

        }

        [Fact]
        public void DepthFirstTraversalPostorder()
        {
            var sut = new BinaryTree<int>();
            sut.Insert(1);
            sut.Insert(2);
            sut.Insert(3);
            sut.Insert(4);
            sut.Insert(5);

            var dfsResult = sut.DepthFirstTraversalPostOrder();
            Assert.Equal(4, dfsResult[0]);
            Assert.Equal(5, dfsResult[1]);
            Assert.Equal(2, dfsResult[2]);
            Assert.Equal(3, dfsResult[3]);
            Assert.Equal(1, dfsResult[4]);

        }

        [Fact]
        public void DepthFirstTraversalPreorder()
        {
            var sut = new BinaryTree<int>();
            sut.Insert(1);
            sut.Insert(2);
            sut.Insert(3);
            sut.Insert(4);
            sut.Insert(5);

            var dfsResult = sut.DepthFirstTraversalPreOrder();
            Assert.Equal(1, dfsResult[0]);
            Assert.Equal(2, dfsResult[1]);
            Assert.Equal(4, dfsResult[2]);
            Assert.Equal(5, dfsResult[3]);
            Assert.Equal(3, dfsResult[4]);

        }

        [Fact]
        public void DepthFirstTraversalInorder()
        {
            var sut = new BinaryTree<int>();
            sut.Insert(1);
            sut.Insert(2);
            sut.Insert(3);
            sut.Insert(4);
            sut.Insert(5);

            var dfsResult = sut.DepthFirstTraversalInOrder();
            Assert.Equal(4, dfsResult[0]);
            Assert.Equal(2, dfsResult[1]);
            Assert.Equal(5, dfsResult[2]);
            Assert.Equal(1, dfsResult[3]);
            Assert.Equal(3, dfsResult[4]);

        }
    }
}
