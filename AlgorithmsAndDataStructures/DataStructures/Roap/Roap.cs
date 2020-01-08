using System;

namespace AlgorithmsAndDataStructures.DataStructures.Roap
{
    public class Roap
    {
        private RoapNode root = new RoapNode();

        public Roap(string start = "")
        {
            root.Left = new RoapNode();
            root.Weight = start.Length;
            root.Left.Text = start;
        }

        public void Concat(string input)
        {
            var oldRoot = this.root;
            this.root = new RoapNode();
            this.root.Weight = oldRoot.Weight;
            this.root.Left = oldRoot;
            this.root.Right = new RoapNode()
            {
                Text = input,
                Weight = input.Length,
            };
        }

        public char CharAt(int index)
        {
            return CharAtInternal(root, index);            
        }

        public char CharAtInternal(RoapNode node, int index)
        {
            if (!string.IsNullOrEmpty(node?.Text))
            {
                return node.Text[index];
            }

            if (node is null || (node.Weight < index && node.Right == null))
            {
                throw new IndexOutOfRangeException();
            }

            return index < node.Weight ? CharAtInternal(node.Left, index) : CharAtInternal(node.Right, index - root.Weight); 
        }

        public string Traverse()
        {
            return TraverseInternal(root);
        }

        private string TraverseInternal(RoapNode root)
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
