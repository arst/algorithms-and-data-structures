using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsAndDataStructures.DataStructures.Roap
{
    public class Roap
    {
        private RopeNode root = new RopeNode();

        public Roap(string start = "")
        {
            root.Left = new RopeNode();
            root.Weight = start.Length;
            root.Left.Text = start;
        }

        public Roap(RopeNode root)
        {
            this.root = root;
        }

        public void Concat(string input)
        {
            var oldRoot = this.root;
            this.root = new RopeNode();
            this.root.Weight = oldRoot.Weight + oldRoot.Right?.Weight ?? 0;
            this.root.Left = oldRoot;
            this.root.Right = new RopeNode()
            {
                Text = input,
                Weight = input.Length,
            };
        }

        public char CharAt(int index)
        {
            return CharAtInternal(root, index);            
        }

        public char CharAtInternal(RopeNode node, int index)
        {
            if (node is null || (node.Weight < index && node.Right == null))
            {
                throw new IndexOutOfRangeException();
            }

            if (!string.IsNullOrEmpty(node.Text))
            {
                return node.Text[index];
            }

            return index < node.Weight ? CharAtInternal(node.Left, index) : CharAtInternal(node.Right, index - root.Weight); 
        }

        public RopeNode Split(int index)
        {
            var newRope = new List<RopeNode>();
            var secondRopeRoot = SplitInternal(this.root, index, newRope);

            return secondRopeRoot;
        }

        private RopeNode SplitInternal(RopeNode node, int index, List<RopeNode> newRope)
        {
            if (node is null || (node.Weight < index && node.Right == null))
            {
                throw new IndexOutOfRangeException();
            }

            if (!string.IsNullOrEmpty(node.Text))
            {
                var splitHolder = new RopeNode();
                splitHolder.Weight = index + 1;

                if (index == node.Weight - 1)
                {
                    splitHolder.Left = node;
                    return splitHolder;
                }

                node.Left = new RopeNode()
                {
                    Text = node.Text.Substring(0, index),
                    Weight = index + 1,
                };
                node.Weight = node.Left.Weight;

                splitHolder.Left = new RopeNode()
                { 
                    Text = node.Text.Substring(index),
                    Weight = node.Weight - index - 1,
                };

                return splitHolder;
            }

            RopeNode splittedNode = null;

            if (index < node.Weight)
            {
                splittedNode = SplitInternal(node.Left, index, newRope);
            }
            else
            {
                splittedNode = SplitInternal(node.Right, index - node.Weight, newRope);
            }

            if (node.Right != null && node != root)
            {
                if (splittedNode.Right == null)
                {
                    splittedNode.Right = node.Right;
                    node.Right = null;
                }
                else
                {
                    var splitter = new RopeNode();
                    splitter.Left = splittedNode;
                    node.Right = null;

                    return splitter;
                }
            }      
                        
            return splittedNode;
        }

        public string Traverse()
        {
            return TraverseInternal(root);
        }

        private string TraverseInternal(RopeNode root)
        {
            if (root is null)
            {
                return string.Empty;
            }

            if (!string.IsNullOrEmpty(root.Text))
            {
                return root.Text;
            }

            return TraverseInternal(root.Left) + TraverseInternal(root.Right);
        }
    }
}
