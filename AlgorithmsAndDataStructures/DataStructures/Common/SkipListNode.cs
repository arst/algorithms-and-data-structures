namespace AlgorithmsAndDataStructures.DataStructures.Common
{
    public class SkipListNode<T>
    {
        public T Value { get; set; }

        public SkipListNode<T> Next { get; set; }

        public SkipListNode<T> Down { get; set; }

        public SkipListNode<T> Up { get; set; }

        public bool IsSentinelNode { get; set; }
    }
}
