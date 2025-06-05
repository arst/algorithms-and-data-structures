namespace AlgorithmsAndDataStructures.DataStructures.SegmentTree;

public class SumSegmentTree : AbstractSegmentTree
{
    public SumSegmentTree(int[] input)
        : base(input, (x, y) => x + y)
    {
    }

    protected override int DummyValue { get; set; }

    public void Update(int index, int value)
    {
        UpdateInternal(0, 0, OriginalInput.Length - 1, index, value);
    }

    private void UpdateInternal(int currentPosition, int currentStart, int currentEnd, int index, int value)
    {
        if (currentStart == currentEnd && currentStart == index)
        {
            Tree[currentPosition] = value;
            OriginalInput[index] = value;
            return;
        }

        if (index > currentEnd || index < currentStart) return;

        var middle = currentStart + (currentEnd - currentStart) / 2;

        Tree[currentPosition] = Tree[currentPosition] + value - OriginalInput[index];

        UpdateInternal(currentPosition * 2 + 1, currentStart, middle, index, value);

        UpdateInternal(currentPosition * 2 + 2, middle + 1, currentEnd, index, value);
    }
}