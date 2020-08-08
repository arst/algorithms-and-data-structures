using AlgorithmsAndDataStructures.DataStructures.Common;
using System;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.DataStructures.BinarySearchTree
{
    public class BinarySearchTree<T> where T : IComparable<T> 
    {
        private BinaryTreeNode<T> root;

        public void Insert(T value)
        {
            if (root == null)
            {
                root = new BinaryTreeNode<T> { Value = value };

                return;
            }

            var current = root;

            while (true)
            {
#pragma warning disable HAA0601 // Value type to reference type conversion causing boxing allocation
                if (current.Value.Equals(value))
#pragma warning restore HAA0601 // Value type to reference type conversion causing boxing allocation
                {
                    return;
                }

                if (current.Value.CompareTo(value) > 0 )
                {
                    if (current.Left == null)
                    {
                        current.Left = new BinaryTreeNode<T> { Value = value };

                        return;
                    }

                    current = current.Left;
                }

                if (current.Value.CompareTo(value) < 0)
                {
                    if (current.Right == null)
                    {
                        current.Right = new BinaryTreeNode<T> { Value = value };

                        return;
                    }

                    current = current.Right;
                }
            }
        }

        public void Delete(T value) => DeleteInternal(root, value);

        private static BinaryTreeNode<T> DeleteInternal(BinaryTreeNode<T> currentSubtreeRoot, T value)
        {
            if (currentSubtreeRoot == null)
            {
                return null;
            }

            if (currentSubtreeRoot.Value.CompareTo(value) < 0)
            {
                currentSubtreeRoot.Left = DeleteInternal(currentSubtreeRoot.Left, value);
            }
            else if (currentSubtreeRoot.Value.CompareTo(value) > 0)
            {
                currentSubtreeRoot.Right = DeleteInternal(currentSubtreeRoot.Right, value);
            }
            else
            {
                //Node has no children.

                if (currentSubtreeRoot.Left == null && currentSubtreeRoot.Right == null)
                {
                    return null;
                }

                //Node has only one child.

                if (currentSubtreeRoot.Left == null)
                {
                    return currentSubtreeRoot.Right;
                }

                if(currentSubtreeRoot.Right == null)
                {
                    return currentSubtreeRoot.Left;
                }

                var minNode = FindNodeWithMinValue(currentSubtreeRoot.Right);

                currentSubtreeRoot.Value = minNode.Value;

                DeleteInternal(currentSubtreeRoot.Right, minNode.Value);
            }

            return currentSubtreeRoot;
        }

        private static BinaryTreeNode<T> FindNodeWithMinValue(BinaryTreeNode<T> right)
        {
            var current = right;

            while (current.Left != null)
            {
                current = current.Left;
            }

            return current;
        }

        public BinaryTreeNode<T> Search(T value)
        {
            var current = root;

            while (current != null)
            {
#pragma warning disable HAA0601 // Value type to reference type conversion causing boxing allocation
                if (current.Value.Equals(value))
#pragma warning restore HAA0601 // Value type to reference type conversion causing boxing allocation
                {
                    return current;
                }

                if (current.Value.CompareTo(value) > 0)
                {
                    current = current.Left;
                }

                if (current.Value.CompareTo(value) < 0)
                {
                    current = current.Right;
                }
            }

            return null;
        }

        public List<T> DepthFirstTraversalInOrder()
        {
            var result = new List<T>();

            DepthFirstTraversalInOrder(root, result);

            return result;
        }

        private static void DepthFirstTraversalInOrder(BinaryTreeNode<T> node, ICollection<T> traversalPath)
        {
            if (node.Left != null)
            {
                DepthFirstTraversalInOrder(node.Left, traversalPath);
            }

            traversalPath.Add(node.Value);

            if (node.Right != null)
            {
                DepthFirstTraversalInOrder(node.Right, traversalPath);
            }
        }

        public bool IsEmpty() => root is null;

        public BinaryTreeNode<T> GetRoot() => root;
    }
}
