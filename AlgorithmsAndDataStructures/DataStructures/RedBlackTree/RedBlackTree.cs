using System;

namespace AlgorithmsAndDataStructures.DataStructures.RedBlackTree
{
    public class RedBlackTree
    {
        public int Height => Math.Max(HeightInternal(this.root) - 1, 0);

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
            if (node == root || node == null)
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
                node.IsRed = true;
                node.Parent.IsRed = false;

                if (node.Parent.Right != null)
                    node.Parent.Right.IsRed = true;
            }
            else if (node.IsRight && node.Parent.IsRight)
            {
                RotateLeft(node.Parent.Parent);
                node.IsRed = true;
                node.Parent.IsRed = false;

                if (node.Parent.Left != null)
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

        private void RotateRightLeft(RedBlackTreeNode node)
        {

            /*
             RotateRight(node.Left);
             RotateLeft(node);
             */
            var parent = node.Parent;

            var rightChild = node.Right;

            var leftGrandChild = node.Right.Left;

            var rightGrandChildLeft = leftGrandChild.Left;
            var rightGrandChildRight = leftGrandChild.Right;

            leftGrandChild.Left = node;
            node.Parent = leftGrandChild;
            leftGrandChild.Right = rightChild;
            rightChild.Parent = leftGrandChild;
            rightChild.Left = rightGrandChildRight;

            if (rightChild.Left != null)
            {
                rightChild.Left.Parent = rightChild;
            }

            node.Right = rightGrandChildLeft;

            if (node.Right != null)
            {
                node.Right.Parent = node;
            }

            if (parent == null)
            {
                root = leftGrandChild;
                root.Parent = null;
                return;
            }

            leftGrandChild.Parent = parent;

            if (node.IsRight)
            {
                parent.Right = leftGrandChild;
            }
            else
            {
                parent.Left = leftGrandChild;
            }
        }

        private void RotateLeftRight(RedBlackTreeNode node)
        {
            /*
             RotateLeft(node.Left);
             RotateRight(node);
             */

            var parent = node.Parent;

            var leftChild = node.Left;

            var rightGrandChild = node.Left.Right;

            var rightGrandChildLeft = rightGrandChild.Left;
            var rightGrandChildRight = rightGrandChild.Right;

            rightGrandChild.Left = leftChild;
            leftChild.Parent = rightGrandChild;
            rightGrandChild.Right = node;
            node.Parent = rightGrandChild;
            leftChild.Right = rightGrandChildLeft;
            if (leftChild.Right != null)
            {
                leftChild.Right.Parent = leftChild;
            }
            node.Left = rightGrandChildRight;

            if (node.Left != null)
            {
                node.Left.Parent = node;
            }

            if (parent == null)
            {
                root = rightGrandChild;
                root.Parent = null;
                return;
            }

            rightGrandChild.Parent = parent;

            if (node.IsRight)
            {
                parent.Right = rightGrandChild;
            }
            else
            {
                parent.Left = rightGrandChild;
            }
        }

        private void RotateRight(RedBlackTreeNode node)
        {
            var parent = node.Parent;

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

            if (node.IsRight)
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

            if (node.IsRight)
            {
                parent.Right = rightChild;
            }
            else
            {
                parent.Left = rightChild;
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
                return grandparent.Left != null && grandparent.Left.IsRed;
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
                return grandparent.Left is null || !grandparent.Left.IsRed;
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

        public void Delete(int value)
        {
            root = DeleteInternal(root, value);
        }

        public RedBlackTreeNode DeleteInternal(RedBlackTreeNode node, int value)
        {
            if (node == null)
            {
                return null;
            }

            if (node.Value > value)
            {
                node.Left = DeleteInternal(node.Left, value);
            }
            else if (node.Value < value)
            {
                node.Right = DeleteInternal(node.Right, value);
            }
            else
            {
                // Leaf Node.
                if (node.Left == null && node.Right == null)
                {
                    if (node.IsRed)
                    {
                        return null;
                    }
                    else
                    {
                        FixTreeAfterDeletion(node);
                        //TODO: Black node without any children.
                        return null;
                    }
                }

                // One Children.
                if (node.Left == null || node.Right == null)
                {
                    if (node.Left == null)
                    {
                        if (node.Right.IsRed && !node.IsRed)
                        {
                            node.Right.IsRed = false;
                        }

                        return node.Right;
                    }

                    if (node.Right == null)
                    {
                        if (node.Left.IsRed && !node.IsRed)
                        {
                            node.Left.IsRed = false;
                        }

                        return node.Left;
                    }
                }

                // Two children. Convert to one children case.
                var minNode = FindNodeWithMinValue(node.Right);

                node.Value = minNode.Value;

                DeleteInternal(node.Right, minNode.Value);
            }

            return node;
        }

        private void FixTreeAfterDeletion(RedBlackTreeNode node)
        {
            // https://youtu.be/CTvfzU_uNKE?t=1033 

            if (IsCase4(node))
            {
                FixCase4(node);
            }
            if (IsCase6(node))
            {
                FixCase6(node);
            }

            if (IsCase3())
            {
                FixCase3();
                FixTreeAfterDeletion(node.Parent);
            }
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
                leftSibling.IsRed = false;
                leftSibling.Right.IsRed = false;
                leftSibling.Left.IsRed = false;

            }
        }

        private bool IsCase6(RedBlackTreeNode node)
        {
            var isSiblingRightChildRed = false;

            bool isSiblingBlack;

            if (node.IsLeft)
            {
                var rightSibling = node.Parent.Right;

                isSiblingBlack = rightSibling == null || !rightSibling.IsRed;

                if (rightSibling != null)
                {
                    isSiblingRightChildRed = rightSibling.Right != null && rightSibling.Right.IsRed;
                }

                return node.Parent.IsRed && isSiblingBlack && isSiblingRightChildRed;
            }

            var leftSibling = node.Parent.Left;

            isSiblingBlack = leftSibling == null || !leftSibling.IsRed;

            if (leftSibling != null)
            {
                isSiblingRightChildRed = leftSibling.Right != null && leftSibling.Right.IsRed;
            }

            return node.Parent.IsRed && isSiblingBlack && isSiblingRightChildRed;
        }

        private void FixCase4(RedBlackTreeNode node)
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

        private bool IsCase4(RedBlackTreeNode node)
        {
            var isSiblingChildrenBlack = false;

            bool isSiblingBlack;
            if (node.IsLeft)
            {
                var rightSibling = node.Parent.Right;

                isSiblingBlack = rightSibling == null || !rightSibling.IsRed;

                if (rightSibling != null)
                {
                    isSiblingChildrenBlack = (rightSibling.Left == null || !rightSibling.Left.IsRed) &&
                                             (rightSibling.Right == null || !rightSibling.Right.IsRed);
                }

                return node.Parent.IsRed && isSiblingBlack && isSiblingChildrenBlack;
            }

            var leftSibling = node.Parent.Left;

            isSiblingBlack = leftSibling == null || !leftSibling.IsRed;

            if (leftSibling != null)
            {
                isSiblingChildrenBlack = (leftSibling.Left == null || !leftSibling.Left.IsRed) &&
                                         (leftSibling.Right == null || !leftSibling.Right.IsRed);
            }

            return node.Parent.IsRed && isSiblingBlack && isSiblingChildrenBlack;

        }

        private RedBlackTreeNode FindNodeWithMinValue(RedBlackTreeNode right)
        {
            var current = right;

            while (current.Left != null)
            {
                current = current.Left;
            }

            return current;
        }

        private void FlipColor(RedBlackTreeNode node)
        {
            node.IsRed = !node.IsRed;
        }

        private int HeightInternal(RedBlackTreeNode node)
        {
            if (node == null)
            {
                return 0;
            }

            var leftHeight = HeightInternal(node.Left) + 1;
            var rightHeight = HeightInternal(node.Right) + 1;

            return Math.Max(leftHeight, rightHeight);
        }
    }
}
