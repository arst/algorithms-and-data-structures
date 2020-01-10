using AlgorithmsAndDataStructures.DataStructures.Roap;

namespace AlgorithmsAndDataStructures.DataStructures.Rope
{
    public class Rope
    {
        private RopeNode root;

        public Rope(RopeNode root)
        {
            this.root = root;
        }

        public Rope(string initialValue)
        {
            root = new RopeNode();
            root.Left = new RopeNode();
            root.Weight = initialValue.Length;
            root.Left.Text = initialValue;
            root.Left.IsLeaf = true;
        }

        public void Concat(string input)
        {
            var oldRoot = root;
            root = new RopeNode();
            root.Weight = oldRoot.Weight + oldRoot.Right?.Weight ?? 0;
            root.Left = oldRoot;
            root.Right = new RopeNode()
            {
                Text = input,
                Weight = input.Length,
            };
        }
    }
}
