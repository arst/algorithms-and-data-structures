using System.Collections.Generic;
using AlgorithmsAndDataStructures.DataStructures.Common;

namespace AlgorithmsAndDataStructures.DataStructures.BinaryTrees;

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
        if (root == null) return;

        BinaryTreeNode<T> toDelete = null;

        var queue = new Queue<ParentChildNodePair<T>>();
        queue.Enqueue(new ParentChildNodePair<T>
        {
            Child = root,
            Parent = null
        });

        while (queue.Count > 0)
        {
            var currentPair = queue.Dequeue();
            var currentNode = currentPair.Child;

#pragma warning disable HAA0601 // Value type to reference type conversion causing boxing allocation
            if (currentNode.Value.Equals(value))
#pragma warning restore HAA0601 // Value type to reference type conversion causing boxing allocation
                toDelete = currentNode;

            if (currentNode.Left != null)
                queue.Enqueue(new ParentChildNodePair<T> { Child = currentNode.Left, Parent = currentNode });
            if (currentNode.Right != null)
                queue.Enqueue(new ParentChildNodePair<T> { Child = currentNode.Right, Parent = currentNode });

            if (queue.Count == 0 && toDelete != null)
            {
                if (toDelete == root && currentNode == root)
                {
                    root = null;
                    return;
                }

                toDelete.Value = currentNode.Value;

                if (currentPair.Parent.Right == currentNode)
                    currentPair.Parent.Right = null;
                else
                    currentPair.Parent.Left = null;
            }
        }
    }

    public BinaryTreeNode<T> GetRoot()
    {
        return root;
    }

    public List<T> BreadthFirstTraversal()
    {
        var result = new List<T>();
        var bfsOrder = new Queue<BinaryTreeNode<T>>();
        bfsOrder.Enqueue(root);

        while (bfsOrder.Count > 0)
        {
            var current = bfsOrder.Dequeue();
            result.Add(current.Value);

            if (current.Left != null) bfsOrder.Enqueue(current.Left);

            if (current.Right != null) bfsOrder.Enqueue(current.Right);
        }

        return result;
    }

    public List<T> DepthFirstTraversalPostOrder()
    {
        var result = new List<T>();

        DepthFirstInternalPostOrder(root, result);

        return result;
    }

    private static void DepthFirstInternalPostOrder(BinaryTreeNode<T> node, List<T> traversalPath)
    {
        if (node.Left != null) DepthFirstInternalPostOrder(node.Left, traversalPath);

        if (node.Right != null) DepthFirstInternalPostOrder(node.Right, traversalPath);

        traversalPath.Add(node.Value);
    }

    public List<T> DepthFirstTraversalPreOrder()
    {
        var result = new List<T>();

        DepthFirstInternalPreOrder(root, result);

        return result;
    }

    private static void DepthFirstInternalPreOrder(BinaryTreeNode<T> node, ICollection<T> traversalPath)
    {
        traversalPath.Add(node.Value);

        if (node.Left != null) DepthFirstInternalPreOrder(node.Left, traversalPath);

        if (node.Right != null) DepthFirstInternalPreOrder(node.Right, traversalPath);
    }

    public List<T> DepthFirstTraversalInOrder()
    {
        var result = new List<T>();

        DepthFirstTraversalInOrder(root, result);

        return result;
    }

    private static void DepthFirstTraversalInOrder(BinaryTreeNode<T> node, ICollection<T> traversalPath)
    {
        if (node.Left != null) DepthFirstTraversalInOrder(node.Left, traversalPath);

        traversalPath.Add(node.Value);

        if (node.Right != null) DepthFirstTraversalInOrder(node.Right, traversalPath);
    }

    private class ParentChildNodePair<TNodeType>
    {
        public BinaryTreeNode<TNodeType> Parent { get; set; }
        public BinaryTreeNode<TNodeType> Child { get; set; }
    }
}