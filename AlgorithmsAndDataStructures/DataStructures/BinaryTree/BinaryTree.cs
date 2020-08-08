using System.Collections.Generic;
using AlgorithmsAndDataStructures.DataStructures.Common;

namespace AlgorithmsAndDataStructures.DataStructures.BinaryTree
{
    public class BinaryTree<T>
    {
        private BinaryTreeNode<T> root;

        public void Insert(T value)
        {
            if (root == null)
            {
                root = new BinaryTreeNode<T> { Value = value };
                return;
            }

            var queue = new Queue<BinaryTreeNode<T>>();
            queue.Enqueue(root);

            while (queue.Peek() != null)
            {
                var currentNode = queue.Dequeue();

                if (currentNode.Left == null)
                {
                    currentNode.Left = new BinaryTreeNode<T> { Value = value };
                    return;
                }

                if (currentNode.Right == null)
                {
                    currentNode.Right = new BinaryTreeNode<T> { Value = value };
                    return;
                }

                queue.Enqueue(currentNode.Left);
                queue.Enqueue(currentNode.Right);
            }
        }

        public void Delete(T value)
        {
            if (root == null)
            {
                return;
            }

            BinaryTreeNode<T> toDelete = null;
            
            var queue = new Queue<ParentChildNodePair<T>>();
            queue.Enqueue(new ParentChildNodePair<T>
            { 
                Child = root,
                Parent = null,
            });

            while (queue.Count > 0)
            {
                var currentPair = queue.Dequeue();
                var currentNode = currentPair.Child;

#pragma warning disable HAA0601 // Value type to reference type conversion causing boxing allocation
                if (currentNode.Value.Equals(value))
#pragma warning restore HAA0601 // Value type to reference type conversion causing boxing allocation
                {
                    toDelete = currentNode;
                }

                if (currentNode.Left != null)
                {
                    queue.Enqueue(new ParentChildNodePair<T> { Child = currentNode.Left, Parent = currentNode });
                }
                if (currentNode.Right != null)
                {
                    queue.Enqueue(new ParentChildNodePair<T> { Child = currentNode.Right, Parent = currentNode });
                }

                if (queue.Count == 0 && toDelete != null)
                {
                    if (toDelete == root && currentNode == root)
                    {
                        root = null;
                        return;
                    }

                    toDelete.Value = currentNode.Value;

                    if (currentPair.Parent.Right == currentNode)
                    {
                        currentPair.Parent.Right = null;
                    }
                    else
                    {
                        currentPair.Parent.Left = null;
                    }
                }
            }
        }

        public BinaryTreeNode<T> GetRoot() => root;

        public List<T> BreadthFirstTraversal()
        {
            var result = new List<T>();
            var bfsOrder = new Queue<BinaryTreeNode<T>>();
            bfsOrder.Enqueue(root);

            while (bfsOrder.Count > 0)
            {
                var current = bfsOrder.Dequeue();
                result.Add(current.Value);

                if (current.Left != null)
                {
                    bfsOrder.Enqueue(current.Left);
                }

                if (current.Right != null)
                {
                    bfsOrder.Enqueue(current.Right);
                }
            }

            return result;
        }

        public List<T> DepthFirstTraversalPostorder()
        {
            var result = new List<T>();

            DepthFirstInternaPostorder(root, result);

            return result;
        }

        private void DepthFirstInternaPostorder(BinaryTreeNode<T> node, List<T> traversalPath)
        {
            if (node.Left != null)
            {
                DepthFirstInternaPostorder(node.Left, traversalPath);
            }

            if (node.Right != null)
            {
                DepthFirstInternaPostorder(node.Right, traversalPath);
            }

            traversalPath.Add(node.Value);
        }

        public List<T> DepthFirstTraversalPreorder()
        {
            var result = new List<T>();

            DepthFirstInternaPreorder(root, result);

            return result;
        }

        private void DepthFirstInternaPreorder(BinaryTreeNode<T> node, List<T> traversalPath)
        {
            traversalPath.Add(node.Value);
            
            if (node.Left != null)
            {
                DepthFirstInternaPreorder(node.Left, traversalPath);
            }

            if (node.Right != null)
            {
                DepthFirstInternaPreorder(node.Right, traversalPath);
            }

            
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

        private class ParentChildNodePair<T>
        {
            public BinaryTreeNode<T> Parent { get; set; }
            public BinaryTreeNode<T> Child { get; set; }
        }
    }
}
