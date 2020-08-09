using System;

namespace AlgorithmsAndDataStructures.DataStructures.RbTree
{
    public class RedBlackTree
    {
        #region Fields
        private RedBlackTreeNode root;
        #endregion

        #region Properties
        public int Height => Math.Max(HeightInternal(root) - 1, 0);
        #endregion

        #region Constructors
        public RedBlackTree(RedBlackTreeNode root)
        {
            this.root = root;
        }

        public RedBlackTree()
        {
        }
        #endregion

        #region Insert
        public void Insert(int value)
        {
            var newNode = new RedBlackTreeNode
            { 
                IsRed = true,
                Value = value,
            };

            if (root == null)
            {
                root = newNode;
                root.IsRed = false;
                return;
            }

            InsertInternal(root, newNode);
            CheckInsert(newNode);
        }

        private void InsertInternal(RedBlackTreeNode rootNode, RedBlackTreeNode toInsert)
        {
            if (toInsert.Value > rootNode.Value)
            {
                if (rootNode.Right.IsLeafNode)
                {
                    rootNode.Right = toInsert;
                    toInsert.Parent = rootNode;
                    return;
                }

                InsertInternal(rootNode.Right, toInsert);
            }
            else if(toInsert.Value < rootNode.Value)
            {
                if (rootNode.Left.IsLeafNode)
                {
                    rootNode.Left = toInsert;
                    toInsert.Parent = rootNode;
                    return;
                }

                InsertInternal(rootNode.Left, toInsert);
            }
        }

        private void CheckInsert(RedBlackTreeNode node)
        {
            if (node == root || node == null || node.Parent == null)
            {
                return;
            }

            //Check if there are two consequitive red nodes in a tree
            if (node.IsRed && node.Parent.IsRed)
            {
                CorrectInsert(node);
            }

            CheckInsert(node.Parent);
        }

        private void CorrectInsert(RedBlackTreeNode node)
        {
            if (IsUncleRed(node))
            {
                node.Parent.Parent.Left.IsRed = false;
                node.Parent.Parent.Right.IsRed = false;
                if (node.Parent.Parent != root)
                {
                    node.Parent.Parent.IsRed = true;
                }
                return;
            }

            if(IsUncleBlack(node))
            {
                Rotate(node);
            }
        }

        private static bool IsUncleRed(RedBlackTreeNode node)
        {
            var grandparent = node.Parent.Parent;

            if (grandparent == null)
            {
                return false;
            }

            if (node.Parent.IsLeft)
            {
                return grandparent.Right.IsRed;
            }

            return grandparent.Left.IsRed;
        }

        private static bool IsUncleBlack(RedBlackTreeNode node)
        {
            var grandparent = node.Parent.Parent;

            if (grandparent == null)
            {
                return false;
            }

            return node.Parent.IsLeft ? grandparent.Right.IsBlack : grandparent.Left.IsBlack;
        }

        private void Rotate(RedBlackTreeNode node)
        {
            if (node.IsLeft && node.Parent.IsLeft)
            {
                RotateRight(node.Parent.Parent);
                node.IsRed = true;
                node.Parent.IsRed = false;

                if (!node.Parent.Right.IsLeafNode)
                    node.Parent.Right.IsRed = true;
            }
            else if (node.IsRight && node.Parent.IsRight)
            {
                RotateLeft(node.Parent.Parent);
                node.IsRed = true;
                node.Parent.IsRed = false;

                if (!node.Parent.Left.IsLeafNode)
                    node.Parent.Left.IsRed = true;
            }
            else if (node.IsRight && node.Parent.IsLeft)
            {
                RotateLeftRight(node.Parent.Parent);
                node.IsRed = false;
                node.Right.IsRed = true;
                node.Left.IsRed = true;
            }
            else if (node.IsLeft && node.Parent.IsRight)
            {
                RotateRightLeft(node.Parent.Parent);

                node.IsRed = false;
                node.Left.IsRed = true;
                node.Right.IsRed = true;
            }
        }
        #endregion

        #region Delete
        public void Delete(int value)
        {
            root = DeleteInternal(root, value, out var doubleBlackNode);

            if (doubleBlackNode != null)
            {
                FixDelete(doubleBlackNode);
            }
        }

        private RedBlackTreeNode DeleteInternal(RedBlackTreeNode node, int value, out RedBlackTreeNode doubleBlackNode)
        {
            if (node.IsLeafNode)
            {
                doubleBlackNode = null;
                return node;
            }

            if (node.Value > value)
            {
                node.Left = DeleteInternal(node.Left, value, out doubleBlackNode);
            }
            else if (node.Value < value)
            {
                node.Right = DeleteInternal(node.Right, value, out doubleBlackNode);
            }
            else
            {
                // Leaf Node.
                if (node.Left.IsLeafNode && node.Right.IsLeafNode)
                {
                    if (node.IsRed)
                    {
                        doubleBlackNode = null;
                        return null;
                    }

                    doubleBlackNode = node.Left;
                    doubleBlackNode.Parent = node.Parent;

                    return doubleBlackNode;
                }

                // One Children.
                if (node.Left.IsLeafNode || node.Right.IsLeafNode)
                {
                    var nonNullChild = node.Left.IsLeafNode ? node.Right : node.Left;

                    if (node.IsRed)
                    {
                        nonNullChild.Parent = node.Parent;
                        doubleBlackNode = null;

                        return nonNullChild;
                    }

                    if (nonNullChild.IsRed)
                    {
                        nonNullChild.IsRed = false;
                        doubleBlackNode = null;
                        nonNullChild.Parent = node.Parent;

                        return nonNullChild;
                    }
                    else
                    {

                        doubleBlackNode = nonNullChild;
                        doubleBlackNode.Parent = node.Parent;

                        return doubleBlackNode;
                    }
                }

                // Two children. Convert to one children case.
                var minNode = FindInOrderSuccessor(node.Right);

                node.Value = minNode.Value;

                node.Right = DeleteInternal(node.Right, minNode.Value, out doubleBlackNode);
            }

            return node;
        }

        private static RedBlackTreeNode FindInOrderSuccessor(RedBlackTreeNode right)
        {
            var current = right;

            while (!current.Left.IsLeafNode)
            {
                current = current.Left;
            }

            return current;
        }


        private void FixDelete(RedBlackTreeNode node)
        {
            if (node == root)
            {
                node.IsRed = false;
                return;
            }
            if (IsCase2(node))
            {
                FixCase2(node);
            }

            if (IsCase3(node))
            {
                FixCase3(node);
                FixDelete(node.Parent);
                return;
            }
            if (IsCase4(node))
            {
                FixCase4(node);
                return;
            }
            if (IsCase5(node))
            {
                FixCase5(node);
                return;
            }
            if (IsCase6(node))
            {
                FixCase6(node);
            }
        }

        #endregion

        #region Check Delete Cases

        private static bool IsCase2(RedBlackTreeNode node)
        {
            var parent = node.Parent;
            var sibling = node.IsLeft ? parent.Right : parent.Left;
            var isSiblingChildrenBlack = (sibling.Left.IsLeafNode || sibling.Left.IsBlack) && (sibling.Right.IsLeafNode || sibling.Right.IsBlack);

            return parent.IsBlack && sibling.IsRed && isSiblingChildrenBlack;
        }

        private static bool IsCase3(RedBlackTreeNode node)
        {
            var parent = node.Parent;
            var sibling = node.IsLeft ? parent.Right : parent.Left;
            var isSiblingChildrenBlack = (sibling.Left.IsLeafNode|| sibling.Left.IsBlack) && (sibling.Right.IsLeafNode || sibling.Right.IsBlack);

            return node.Parent.IsBlack && sibling.IsBlack && isSiblingChildrenBlack;
        }

        private static bool IsCase4(RedBlackTreeNode node)
        {
            var parent = node.Parent;
            var sibling = node.IsLeft ? parent.Right : parent.Left;
            var isSiblingChildrenBlack = (sibling.Left.IsLeafNode || sibling.Left.IsBlack) && (sibling.Right.IsLeafNode || sibling.Right.IsBlack);

            return node.Parent.IsRed && sibling.IsBlack && isSiblingChildrenBlack;

        }

        private static bool IsCase5(RedBlackTreeNode node)
        {
            var parent = node.Parent;
            var sibling = node.IsLeft ? parent.Right : parent.Left;
            var isSiblingChildrenRedBlack = node.IsLeft 
                ? sibling.Left.IsRed && (sibling.Right.IsLeafNode || sibling.Right.IsBlack)
                : (sibling.Left.IsLeafNode || sibling.Left.IsBlack) && sibling.Right.IsRed;

            return sibling.IsBlack && isSiblingChildrenRedBlack;
        }

        private static bool IsCase6(RedBlackTreeNode node)
        {
            var parent = node.Parent;
            var sibling = node.IsLeft ? parent.Right : parent.Left;
            var isSiblingRightChildRed = node.IsLeft
                ? sibling.Right.IsRed
                : sibling.Left.IsRed;

            return sibling.IsBlack && isSiblingRightChildRed;
        }
        #endregion

        #region Fix Delete Cases
        private void FixCase2(RedBlackTreeNode node)
        {
            var parent = node.Parent;
            var originalParentColor = node.Parent.IsRed;
            var sibling = node.IsLeft ? node.Parent.Right : node.Parent.Left;
            var originalSiblingColor = sibling.IsRed;

            if (node.IsLeft)
            {
                RotateLeft(node.Parent);
            }
            else
            {
                RotateRight(node.Parent);
            }

            parent.IsRed = originalSiblingColor;
            sibling.IsRed = originalParentColor;
        }

        private static void FixCase3(RedBlackTreeNode node)
        {
            var parent = node.Parent;
            var sibling = node.IsLeft ? parent.Right : parent.Left;
            sibling.IsRed = true;
        }

        private static void FixCase4(RedBlackTreeNode node)
        {
            node.Parent.IsRed = false;

            if (node.IsLeft)
            {
                node.Parent.Right.IsRed = true;
            }
            else
            {
                node.Parent.Left.IsRed = true;
            }

        }

        private void FixCase5(RedBlackTreeNode node)
        {
            var parent = node.Parent;
            if (node.IsLeft)
            {
                RotateRight(parent.Right);
                if (parent.Right.Left != null)
                {
                    parent.Right.Left.IsRed = false;
                }
                parent.Right.IsRed = true;
            }
            else
            {
                RotateLeft(parent.Left);
                if (parent.Left.Right != null)
                {
                    parent.Left.Right.IsRed = false;
                }
                parent.Left.IsRed = true;
            }

            FixCase6(node);
        }

        private void FixCase6(RedBlackTreeNode node)
        {
            if (node.IsLeft)
            {
                var originalColor = node.Parent.IsRed;
                var rightSibling = node.Parent.Right;
                RotateLeft(node.Parent);
                rightSibling.IsRed = originalColor;
                rightSibling.Right.IsRed = false;
                rightSibling.Left.IsRed = false;
            }
            else
            {
                var originalColor = node.Parent.IsRed;
                var leftSibling = node.Parent.Left;
                RotateRight(node.Parent);
                leftSibling.IsRed = originalColor;
                leftSibling.Right.IsRed = false;
                leftSibling.Left.IsRed = false;

            }
        }
        #endregion

        #region Rotations
        private void RotateRightLeft(RedBlackTreeNode node)
        {
             RotateRight(node.Right);
             RotateLeft(node);
        }

        private void RotateLeftRight(RedBlackTreeNode node)
        {
             RotateLeft(node.Left);
             RotateRight(node);
        }

        private void RotateRight(RedBlackTreeNode node)
        {
            var parent = node.Parent;
            var originalNodePosition = node.IsRight;

            var leftChild = node.Left;

            node.Left = leftChild.Right;
            if (node.Left != null)
            {
                node.Left.Parent = node;
            }
            leftChild.Right = node;
            node.Parent = leftChild;

            if (parent == null)
            {
                root = leftChild;
                root.Parent = null;
                return;
            }

            leftChild.Parent = parent;

            if (originalNodePosition)
            {
                parent.Right = leftChild;
            }
            else
            {
                parent.Left = leftChild;
            }
        }

        private void RotateLeft(RedBlackTreeNode node)
        {
            var parent = node.Parent;
            var originalPositionIsRight = node.IsRight;
            var rightChild = node.Right;

            node.Right = rightChild.Left;
            if (node.Right != null)
                node.Right.Parent = node;
            rightChild.Left = node;
            node.Parent = rightChild;

            if (parent == null)
            {
                root = rightChild;
                root.Parent = null;
                return;
            }

            rightChild.Parent = parent;

            if (originalPositionIsRight)
            {
                parent.Right = rightChild;
            }
            else
            {
                parent.Left = rightChild;
            }
        }
        #endregion

        #region Tree Validation
        public void CheckTreeValidity()
        {
            if (root == null)
            {
                return;
            }

            if (root.IsRed)
            {
                throw new Exception("Root is red.");
            }

            CheckBlackNodesBalance(root);
            CheckNoConsequentRedNodes(root);
        }

        private static void CheckNoConsequentRedNodes(RedBlackTreeNode node)
        {
            if (node.IsLeafNode)
            {
                return;
            }

            if (node.IsRed && (node.Left.IsRed || node.Right.IsRed))
            {
#pragma warning disable HAA0601 // Value type to reference type conversion causing boxing allocation
                throw new Exception($"Consequent red nodes. Node value: {node.Value}. Left: {node.Left.Value}. Right {node.Right.Value}");
#pragma warning restore HAA0601 // Value type to reference type conversion causing boxing allocation
            }
        }

        private int CheckBlackNodesBalance(RedBlackTreeNode node)
        {
            if (node == null || node.IsLeafNode)
            {
                return 1;
            }

            var leftHeight = CheckBlackNodesBalance(node.Left);
            var rightHeight = CheckBlackNodesBalance(node.Right);

            if (leftHeight != rightHeight)
            {
#pragma warning disable CA1303 // Do not pass literals as localized parameters
                throw new Exception("Tree is unbalanced.");
#pragma warning restore CA1303 // Do not pass literals as localized parameters
            }

            return node.IsRed ? leftHeight : leftHeight + 1;
        }

        private int HeightInternal(RedBlackTreeNode node)
        {
            if (node == null || node.IsLeafNode)
            {
                return 0;
            }

            var leftHeight = HeightInternal(node.Left) + 1;
            var rightHeight = HeightInternal(node.Right) + 1;

            return Math.Max(leftHeight, rightHeight);
        }
        #endregion
    }
}
