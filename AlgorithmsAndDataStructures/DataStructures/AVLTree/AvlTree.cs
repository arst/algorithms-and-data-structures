using System;

namespace AlgorithmsAndDataStructures.DataStructures.AVLTree
{
    public class AvlTree
    {
        private AvlTreeNode root;

        public bool IsBalanced => IsRootBalanced();

        public void Insert(int value)
        {
            var toInsert = new AvlTreeNode()
            {
                Value = value,
            };

            root = InsertInternal(this.root, toInsert);
        }

        private AvlTreeNode InsertInternal(AvlTreeNode rootNode, AvlTreeNode toInsert)
        {
            if (rootNode == null)
            {
                return toInsert;
            }

            if (rootNode.Value == toInsert.Value)
            {
                return rootNode;
            }

            if (toInsert.Value > rootNode.Value)
            {
                 rootNode.Right = InsertInternal(rootNode.Right, toInsert);
            }
            else
            {
                rootNode.Left = InsertInternal(rootNode.Left, toInsert);
            }

            rootNode.Height = 1 + Math.Max(Height(rootNode.Left), Height(rootNode.Right));

            var balanceFactor = GetBalancedFactor(rootNode);

            if (Math.Abs(balanceFactor) > 1)
            {
                if (balanceFactor > 1)
                {
                    if (rootNode.Left.Value > toInsert.Value)
                    {
                        return RotateRight(rootNode);
                    }
                    else
                    {
                        rootNode.Left = RotateLeft(rootNode.Left);
                        return RotateRight(rootNode);
                    }

                }
                else if (balanceFactor < -1)
                {

                    if (rootNode.Left.Value < toInsert.Value)
                    {
                        return RotateLeft(rootNode);
                    }
                    else
                    {
                        root.Right = RotateRight(rootNode.Right);
                        return RotateLeft(rootNode);
                    }
                }
            }

            return rootNode;
        }

        private AvlTreeNode RotateRight(AvlTreeNode rootNode)
        {
            var leftChild = rootNode.Left;
            leftChild.Right = rootNode;
            rootNode.Left = leftChild.Right;

            leftChild.Height = 1 + Math.Max(Height(leftChild.Left), Height(leftChild.Right));
            rootNode.Height = 1 + Math.Max(Height(rootNode.Left), Height(rootNode.Right));

            return leftChild;
        }

        private AvlTreeNode RotateLeft(AvlTreeNode rootNode)
        {
            var rightChild = rootNode.Right;
            rightChild.Left = rootNode;
            rootNode.Right = rightChild.Left;

            rightChild.Height = 1 + Math.Max(Height(rightChild.Left), Height(rightChild.Right));
            rootNode.Height = 1 + Math.Max(Height(rootNode.Left), Height(rootNode.Right));

            return rightChild;
        }

        private int GetBalancedFactor(AvlTreeNode node)
        {
            var leftHeight = node.Left?.Height ?? 0;
            var righrHeight = node.Right?.Height ?? 0;

            return leftHeight - righrHeight;
        }

        private int Height(AvlTreeNode node)
        {
            if (node == null)
            {
                return 0;
            }

            return node.Height;
        }

        private bool IsRootBalanced()
        {
            return Math.Abs(GetBalancedFactor(root)) <= 1;
        }
    }
}
