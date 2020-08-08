using System;

namespace AlgorithmsAndDataStructures.DataStructures.AdelsonVelskyLandisTree
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

            root = InsertInternal(root, toInsert);
        }

        private static AvlTreeNode InsertInternal(AvlTreeNode rootNode, AvlTreeNode toInsert)
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

        public void Delete(int value) => root = DeleteInternal(root, value);

        private static AvlTreeNode DeleteInternal(AvlTreeNode currentSubtreeRoot, int value)
        {
            if (currentSubtreeRoot == null)
            {
                return null; 
            }

            if (currentSubtreeRoot.Value < value)
            {
                currentSubtreeRoot.Right = DeleteInternal(currentSubtreeRoot.Right, value);
            }
            else if (currentSubtreeRoot.Value > value)
            {
                currentSubtreeRoot.Left = DeleteInternal(currentSubtreeRoot.Left, value);
            }
            else
            {
                var isChildlessNode = currentSubtreeRoot.Left == null && currentSubtreeRoot.Right == null;

                if (isChildlessNode)
                {
                    return null;
                }

                var hasOneChild = currentSubtreeRoot.Left == null || currentSubtreeRoot.Right == null;

                if (hasOneChild)
                {
                    return currentSubtreeRoot.Left ?? currentSubtreeRoot.Right;
                }

                var inOrderSuccessor = GetInOrderSuccessor(currentSubtreeRoot.Right);

                currentSubtreeRoot.Value = inOrderSuccessor.Value;

                currentSubtreeRoot.Right = DeleteInternal(currentSubtreeRoot.Right, inOrderSuccessor.Value);
            }

            currentSubtreeRoot.Height = CalculateNodeHeight(currentSubtreeRoot);

            var balanceFactor = GetBalancedFactor(currentSubtreeRoot);

            var isUnbalanced = Math.Abs(balanceFactor) > 1;

            if (isUnbalanced)
            {
                var highestChild = balanceFactor > 1 ? currentSubtreeRoot.Left : currentSubtreeRoot.Right;
                var leftGrandChildHeight = highestChild.Left?.Height ?? 0;
                var rightGrandChildHeight = highestChild.Right?.Height ?? 0;
                var highestGrandChild = leftGrandChildHeight > rightGrandChildHeight ? highestChild.Left : highestChild.Right;

                if (balanceFactor > 1)
                {
                    if (highestChild.Left == highestGrandChild)
                    {
                        return RotateRight(currentSubtreeRoot);
                    }

                    currentSubtreeRoot.Left = RotateLeft(currentSubtreeRoot.Left);
                    return RotateRight(currentSubtreeRoot);

                }

                if (balanceFactor < -1)
                {
                    if (highestChild.Right == highestGrandChild)
                    {
                        return RotateLeft(currentSubtreeRoot);
                    }

                    currentSubtreeRoot.Right = RotateRight(currentSubtreeRoot.Right);
                    return RotateLeft(currentSubtreeRoot);
                }
            }

            return currentSubtreeRoot;
        }

        private static AvlTreeNode GetInOrderSuccessor(AvlTreeNode node)
        {
            return node.Left == null ? node : GetInOrderSuccessor(node.Left);
        }

        private static AvlTreeNode RotateRight(AvlTreeNode y)
        {
            var x = y.Left;
            var t2 = x.Right;

            x.Right = y;
            y.Left = t2;

            y.Height = CalculateNodeHeight(y);
            x.Height = CalculateNodeHeight(x);

            return x;
        }

        private static int CalculateNodeHeight(AvlTreeNode node) => 1 + Math.Max(Height(node.Left), Height(node.Right));

        private static AvlTreeNode RotateLeft(AvlTreeNode x)
        {
            var y = x.Right;
            var t2 = y.Left;

            y.Left = x;
            x.Right = t2;
            
            x.Height = CalculateNodeHeight(x);
            y.Height = CalculateNodeHeight(y);

            return y;
        }

        private static int GetBalancedFactor(AvlTreeNode node)
        {
            if (node == null)
            {
                return 0;
            }

            return Height(node.Left) - Height(node.Right);
        }

        private static int Height(AvlTreeNode node) => node?.Height ?? 0;

        private bool IsRootBalanced() => Math.Abs(GetBalancedFactor(root)) <= 1;
    }
}
