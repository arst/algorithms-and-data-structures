using AlgorithmsAndDataStructures.DataStructures.Common;
using System;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.DataStructures.BinarySearchTree
{
    public class BinarySearchTree<T> where T : IComparable<T> 
    {
        BinaryTreeNode<T> root;

        public void Insert(T value)
        {
            if (root == null)
            {
                root = new BinaryTreeNode<T>() { Value = value };

                return;
            }

            var current = root;

            while (true)
            {
                if (current.Value.Equals(value))
                {
                    return;
                }

                if (current.Value.CompareTo(value) > 0 )
                {
                    if (current.Left == null)
                    {
                        current.Left = new BinaryTreeNode<T>() { Value = value };

                        return;
                    }
                    else
                    {
                        current = current.Left;
                    }
                }

                if (current.Value.CompareTo(value) < 0)
                {
                    if (current.Right == null)
                    {
                        current.Right = new BinaryTreeNode<T>() { Value = value };

                        return;
                    }
                    else
                    {
                        current = current.Right;
                    }
                }
            }
        }

        public void Delete(T value)
        {
            DeleteInternal(root, value);
        }

        private BinaryTreeNode<T> DeleteInternal(BinaryTreeNode<T> root, T value)
        {
            if (root == null)
            {
                return null;
            }

            if (root.Value.CompareTo(value) < 0)
            {
                root.Left = DeleteInternal(root.Left, value);
            }
            else if (root.Value.CompareTo(value) > 0)
            {
                root.Right = DeleteInternal(root.Right, value);
            }
            else
            {
                //Node has no children.

                if (root.Left == null && root.Right == null)
                {
                    return null;
                }

                //Node has only one child.

                if (root.Left == null)
                {
                    return root.Right;
                }
                else if(root.Right == null)
                {
                    return root.Left;
                }

                var minNode = FindNodeWithMinValue(root.Right);

                root.Value = minNode.Value;

                DeleteInternal(root.Right, minNode.Value);
            }

            return root;
        }

        private BinaryTreeNode<T> FindNodeWithMinValue(BinaryTreeNode<T> right)
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
                if (current.Value.Equals(value))
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

        public List<T> DepthFirstTraversalInorder()
        {
            var result = new List<T>();

            DepthFirstTraversalInorder(root, result);

            return result;
        }

        private void DepthFirstTraversalInorder(BinaryTreeNode<T> node, List<T> traversalPath)
        {
            if (node.Left != null)
            {
                DepthFirstTraversalInorder(node.Left, traversalPath);
            }

            traversalPath.Add(node.Value);

            if (node.Right != null)
            {
                DepthFirstTraversalInorder(node.Right, traversalPath);
            }
        }

        public bool IsEmpty() => root is null;

        public BinaryTreeNode<T> GetRoot() => root;
    }
}
