using System;

namespace AlgorithmsAndDataStructures.DataStructures.AVLTree
{
    public class AvlTree
    {
        private AvlTreeNode root;

        public bool IsBalanced => IsRootBalanced();

        public void Insert(int value)
        {
            var toInsert = new AvlTreeNode
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


            if (toInsert.Value < rootNode.Value)
            {
                rootNode.Left = InsertInternal(rootNode.Left, toInsert);
            }
            else if (toInsert.Value > rootNode.Value)
            {
                rootNode.Right = InsertInternal(rootNode.Right, toInsert);
            }
            else
            {
                return rootNode;
            }

            rootNode.Height = CalculateNodeHeight(rootNode);

            var balanceFactor = GetBalancedFactor(rootNode);

            if (balanceFactor > 1 && toInsert.Value < rootNode.Left.Value)
            {
                return RotateRight(rootNode);
            }
            if (balanceFactor > 1 && toInsert.Value > rootNode.Left.Value)
            {
                rootNode.Left = RotateLeft(rootNode.Left);
                return RotateRight(rootNode);
            }
            if (balanceFactor < -1 && toInsert.Value > rootNode.Right.Value)
            {
                return RotateLeft(rootNode);
            }
            if (balanceFactor < -1 && toInsert.Value < rootNode.Right.Value)
            {
                rootNode.Right = RotateRight(rootNode.Right);
                return RotateLeft(rootNode);
            }

            return rootNode;
        }

        public void Delete(int value)
        {
            root = DeleteInternal(root, value);
        }

        private AvlTreeNode DeleteInternal(AvlTreeNode root, int value)
        {
            if (root == null)
            {
                return null; 
            }

            if (root.Value < value)
            {
                root.Right = DeleteInternal(root.Right, value);
            }
            else if (root.Value > value)
            {
                root.Left = DeleteInternal(root.Left, value);
            }
            else
            {
                var isChildlessNode = root.Left == null && root.Right == null;

                if (isChildlessNode)
                {
                    return null;
                }

                var hasOneChild = root.Left == null || root.Right == null;

                if (hasOneChild)
                {
                    return root.Left ?? root.Right;
                }

                var inOrderSuccessor = GetInOrderSuccessor(root.Right);

                root.Value = inOrderSuccessor.Value;

                root.Right = DeleteInternal(root.Right, inOrderSuccessor.Value);
            }

            root.Height = CalculateNodeHeight(root);

            var balanceFactor = GetBalancedFactor(root);

            if (Math.Abs(balanceFactor) > 1)
            {
                var highestChild = balanceFactor > 1 ? root.Left : root.Right;
                var leftGrandChildHeight = highestChild.Left?.Height ?? 0;
                var rightGrandChildHeight = highestChild.Right?.Height ?? 0;
                var highestGrandChild = leftGrandChildHeight > rightGrandChildHeight ? highestChild.Left : highestChild.Right;

                if (balanceFactor > 1)
                {
                    if (highestChild.Left == highestGrandChild)
                    {
                        return RotateRight(root);
                    }
                    else
                    {
                        root.Left = RotateLeft(root.Left);
                        return RotateRight(root);
                    }

                }
                else if (balanceFactor < -1)
                {

                    if (highestChild.Right == highestGrandChild)
                    {
                        return RotateLeft(root);
                    }
                    else
                    {
                        root.Right = RotateRight(root.Right);
                        return RotateLeft(root);
                    }
                }
            }

            return root;
        }

        private AvlTreeNode GetInOrderSuccessor(AvlTreeNode node)
        {
            if (node.Left == null)
            {
                return node;
            }

            return GetInOrderSuccessor(node.Left);
        }

        private AvlTreeNode RotateRight(AvlTreeNode y)
        {
            var x = y.Left;
            var T2 = x.Right;

            x.Right = y;
            y.Left = T2;

            y.Height = CalculateNodeHeight(y);
            x.Height = CalculateNodeHeight(x);

            return x;
        }

        private int CalculateNodeHeight(AvlTreeNode node)
        {
            return 1 + Math.Max(Height(node.Left), Height(node.Right));
        }

        private AvlTreeNode RotateLeft(AvlTreeNode x)
        {
            var y = x.Right;
            var T2 = y.Left;

            y.Left = x;
            x.Right = T2;
            
            x.Height = CalculateNodeHeight(x);
            y.Height = CalculateNodeHeight(y);

            return y;
        }

        private int GetBalancedFactor(AvlTreeNode node)
        {
            if (node == null)
            {
                return 0;
            }

            return Height(node.Left) - Height(node.Right);
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
