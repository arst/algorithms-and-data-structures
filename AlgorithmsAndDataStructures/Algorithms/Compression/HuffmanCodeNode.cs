using System;

namespace AlgorithmsAndDataStructures.Algorithms.Compression;
#pragma warning disable CA1036 // Override methods on comparable types
public class HuffmanCodeNode : IComparable<HuffmanCodeNode>
#pragma warning restore CA1036 // Override methods on comparable types
{
    public HuffmanCodeNode Right { get; set; }

    public HuffmanCodeNode Left { get; set; }

    public char? Character { get; set; }

    public int Frequency { get; set; }

    public int CompareTo(HuffmanCodeNode other)
    {
        return Frequency.CompareTo(other?.Frequency ?? default);
    }
}