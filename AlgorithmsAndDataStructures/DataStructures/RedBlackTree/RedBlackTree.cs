using System;

namespace AlgorithmsAndDataStructures.DataStructures.RedBlackTree
{
    public class RedBlackTree
    {
        private RedBlackTreeNode root;

        public void Insert(int value)
        {
            var newNode = new RedBlackTreeNode()
            { 
                IsRed = true,
                Value = value,
            };

            if (root == null)
            {
                root = newNode;
                FlipColor(root);
                return;
            }

            InsertInternal(root, newNode);
            CheckColor(newNode);
        }

        private void CheckColor(RedBlackTreeNode node)
        {
            if (node == root)
            {
                return;
            }

            //Check if there are two consequitive red nodes in a tree
            if (node.IsRed && node.Parent.IsRed)
            {
                CorrectNode(node);
            }

            CheckColor(node.Parent);
        }

        private void CorrectNode(RedBlackTreeNode node)
        {
            if (IsUncleRed(node))
            {
                node.Parent.Parent.Left.IsRed = false;
                node.Parent.Parent.Right.IsRed = false;
                node.Parent.Parent.IsRed = true;
            }

            if(IsUncleBlack(node))
            {
                Rotate(node);
            }
        }

        private void Rotate(RedBlackTreeNode node)
        {
            if (node.IsLeft && node.Parent.IsLeft)
            {
                RotateRight(node.Parent.Parent);
            }
            else if (node.IsRight && node.Parent.IsRight)
            {
                RotateLeft(node.Parent.Parent);
            }
            else if (node.IsRight && node.Parent.IsLeft)
            {
                RotateLeftRight(node.Parent.Parent);
            }
            else if (node.IsLeft && node.Parent.IsRight)
            {
                RotateRightLeft(node.Parent.Parent);
            }
        }

        private bool IsUncleRed(RedBlackTreeNode node)
        {
            var grandparent = node.Parent.Parent;

            if (grandparent == null)
            {
                return false;
            }

            if (node.Parent.IsLeft)
            {
                return grandparent.Right != null && grandparent.Right.IsRed;
            }
            else
            {
                return grandparent.Right != null && grandparent.Left.IsRed;
            }
        }

        private bool IsUncleBlack(RedBlackTreeNode node)
        {
            var grandparent = node.Parent.Parent;

            if (grandparent == null)
            {
                return false;
            }

            if (node.Parent.IsLeft)
            {
                return grandparent.Right is null || !grandparent.Right.IsRed;
            }
            else
            {
                return grandparent.Right is null || !grandparent.Left.IsRed;
            }
        }

        private void InsertInternal(RedBlackTreeNode rootNode, RedBlackTreeNode toInsert)
        {
            if (toInsert.Value >= rootNode.Value)
            {
                if (rootNode.Right == null)
                {
                    rootNode.Right = toInsert;
                    toInsert.Parent = rootNode;
                    return;
                }

                InsertInternal(rootNode.Right, toInsert);
            }
            else
            {
                if (rootNode.Left == null)
                {
                    rootNode.Left = toInsert;
                    toInsert.Parent = rootNode;
                    return;
                }

                InsertInternal(root.Left, toInsert);
            }
        }

        private void FlipColor(RedBlackTreeNode node)
        {
            node.IsRed = !node.IsRed;
        }
    }
}
