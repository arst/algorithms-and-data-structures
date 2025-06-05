using System;

namespace AlgorithmsAndDataStructures.DataStructures.SegmentTree;

public class MinSegmentTree : AbstractSegmentTree
{
    public MinSegmentTree(int[] input)
        : base(input, Math.Min)
    {
    }

    protected override int DummyValue { get; set; } = int.MaxValue;

    public void Update(int index, int value)
    {
        UpdateInternal(0, 0, OriginalInputLength - 1, index, value);
    }

    private int UpdateInternal(int currentPosition, int currentStart, int currentEnd, int index, int value)
    {
        if (currentStart == currentEnd && currentStart == index)
        {
            Tree[currentPosition] = value;
            return Tree[currentPosition];
        }

        if (index > currentEnd || index < currentStart) return Tree[currentPosition];

        var middle = currentStart + (currentEnd - currentStart) / 2;

        Tree[currentPosition] = Math.Min(UpdateInternal(currentPosition * 2 + 1, currentStart, middle, index, value),
            UpdateInternal(currentPosition * 2 + 2, middle + 1, currentEnd, index, value));

        return Tree[currentPosition];
    }
}