namespace AlgorithmsAndDataStructures.DataStructures.Roap
{
    public class RopeNode
    {
        public bool IsLeaf { get; set; }

        public int Weight { get; set; }

        public string Text { get; set; }

        public RopeNode Left { get; set; }

        public RopeNode Right { get; set; }
    }
}
