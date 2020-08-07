using AlgorithmsAndDataStructures.DataStructures.BinarySearchTree;
using AlgorithmsAndDataStructures.DataStructures.Common;
using System;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.DataStructures.BinarySearchTree
{
    public class BinarySearchTreeTests
    {
        [Fact]
        public void EmptyTreeCorrectlyReportsItsEmptiness()
        {
            var sut = new BinarySearchTree<int>();
            Assert.True(sut.IsEmpty());
        }

        [Fact]
        public void NonEmptyTreeCorrectlyReportsItsEmptiness()
        {
            var sut = new BinarySearchTree<int>();
            sut.Insert(1);
            Assert.False(sut.IsEmpty());
        }


        [Fact]
        public void InsertToAnEmptyTreeCreatesRoot()
        {
            var sut = new BinarySearchTree<int>();

            sut.Insert(1);

            var dfsInOrder = sut.DepthFirstTraversalInorder();

            Assert.Equal(1, dfsInOrder[0]);
        }

        [Fact]
        public void LeftSubtreeIsBinarySearchTree()
        {
            var sut = new BinarySearchTree<int>();

            sut.Insert(4);
            sut.Insert(2);
            sut.Insert(3);
            sut.Insert(1);

            var root = sut.GetRoot();

            Assert.Equal(4, root.Value);
            Assert.Equal(2, root.Left.Value);
            Assert.Equal(1, root.Left.Left.Value);
            Assert.Equal(3, root.Left.Right.Value);
        }

        [Fact]
        public void RightSubtreeIsBinarySearchTree()
        {
            var sut = new BinarySearchTree<int>();

            sut.Insert(1);
            sut.Insert(3);
            sut.Insert(2);
            sut.Insert(4);

            var root = sut.GetRoot();

            Assert.Equal(1, root.Value);
            Assert.Equal(3, root.Right.Value);
            Assert.Equal(2, root.Right.Left.Value);
            Assert.Equal(4, root.Right.Right.Value);
        }

        [Fact]
        public void AllSubtreesAreBinarySearchTrees()
        {
            var sut = new BinarySearchTree<int>();
            var random = new Random();

            for (var j = 0; j < 10; j++)
            {
                for (var i = 0; i < 100000; i++)
                {
                    var number = random.Next();
                    sut.Insert(number);                               
                }
            }

            CheckInvariantRecursive(sut.GetRoot());
        }

        [Fact]
        public void AllSubtreesAreBinarySearchTreesAfterDeletes()
        {
            var sut = new BinarySearchTree<int>();
            var random = new Random();

            for (var j = 0; j < 100; j++)
            {
                for (var i = 0; i < 10000; i++)
                {
                    var number = random.Next(1000);
                    sut.Insert(number);
                }

                for (var z = 0; z < 1000; z++)
                {
                    var number = random.Next(1000);
                    sut.Delete(number);

                    CheckInvariantRecursive(sut.GetRoot());
                }
            }
        }

        private void CheckInvariantRecursive(BinaryTreeNode<int> root)
        {
            if (root.Left != null)
            {
                Assert.True(root.Value > root.Left.Value);
                CheckInvariantRecursive(root.Left);
            }

            if (root.Right != null)
            {
                Assert.True(root.Value < root.Right.Value);
                CheckInvariantRecursive(root.Right);
            }
            
        }
    }
}
