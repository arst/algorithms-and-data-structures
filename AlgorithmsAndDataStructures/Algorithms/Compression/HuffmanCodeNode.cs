using System;

namespace AlgorithmsAndDataStructures.Algorithms.Compression
{
    public class HuffmanCodeNode : IComparable<HuffmanCodeNode>
    {
        public HuffmanCodeNode Right { get; set; }

        public HuffmanCodeNode Left { get; set; }

        public char? Character { get; set; }

        public int Frequency { get; set; }

        public int CompareTo(HuffmanCodeNode other) => Frequency.CompareTo(other?.Frequency);
    }
}
