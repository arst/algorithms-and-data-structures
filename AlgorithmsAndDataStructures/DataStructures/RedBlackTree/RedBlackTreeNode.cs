using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsAndDataStructures.DataStructures.RedBlackTree
{
    public class RedBlackTreeNode
    {
        private static RedBlackTreeNode CreateLeafNode()
        {
            var result = new RedBlackTreeNode();
            result.IsLeafNode = true;

            return result;
        }

        public RedBlackTreeNode()
        {
            Left = CreateLeafNode();
            Right = CreateLeafNode();
        }

        public bool IsRed { get; set; }

        public bool IsLeft => Parent != null && Parent.Left == this;

        public bool IsRight => Parent != null && Parent.Right == this;

        public RedBlackTreeNode Parent { get; set; }

        public RedBlackTreeNode Left { get; set; }

        public RedBlackTreeNode Right { get; set; }

        public int Value { get; set; }

        public bool IsLeafNode { get; set; }
    }
}
