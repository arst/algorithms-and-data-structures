namespace AlgorithmsAndDataStructures.DataStructures.RedBlackTree
{
    public class RedBlackTreeNode
    {
        private RedBlackTreeNode right;
        private RedBlackTreeNode left;

        private static RedBlackTreeNode GetLeafNode(RedBlackTreeNode parent) =>
            new RedBlackTreeNode
            {
                Parent = parent,
                IsRed = false,
                IsLeafNode = true,
            };

        public bool IsRed { get; set; }

        public bool IsBlack => !IsRed;

        public bool IsLeft => Parent != null && Parent.Left == this;

        public bool IsRight => Parent != null && Parent.Right == this;

        public RedBlackTreeNode Parent { get; set; }

        public RedBlackTreeNode Left
        {
            get => left ?? GetLeafNode(this);
            set => left = value;
        }

        public RedBlackTreeNode Right
        {
            get => right ?? GetLeafNode(this);
            set => right = value;
        }

        public int Value { get; set; }

        public bool IsLeafNode { get; set; }
    }
}
