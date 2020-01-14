using System;

namespace AlgorithmsAndDataStructures.DataStructures.AVLTree
{
    public class AvlTree
    {
        private AvlTreeNode root;

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

            return rootNode;
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
    }
}
