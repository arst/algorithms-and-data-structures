using System;

namespace AlgorithmsAndDataStructures.DataStructures.SegmentTree
{
    public abstract class AbstractSegmentTree
    {
        protected readonly int[] segmentTree;
        private readonly Func<int, int, int> segmentAggregate;
        protected int inputLength;

        protected abstract int DummyValue { get; set; }

        public AbstractSegmentTree(int[] input, Func<int, int, int> segmentAggregate)
        {
            int x = (int)(Math.Ceiling(Math.Log(input.Length) / Math.Log(2)));

            int treeSize = 2 * (int)Math.Pow(2, x) - 1;

            segmentTree = new int[treeSize];
            this.segmentAggregate = segmentAggregate;

            Build(input, 0, input.Length - 1, 0);

            inputLength = input.Length;
        }

        private int Build(int[] input, int start, int end, int current)
        {
            if (start == end)
            {
                segmentTree[current] = input[end];

                return segmentTree[current];
            }

            var middle = start + (end - start) / 2;

            segmentTree[current] = segmentAggregate(Build(input, start, middle, current * 2 + 1),Build(input, middle + 1, end, current * 2 + 2));

            return segmentTree[current];
        }

        public int GetSegmentValue(int start, int end)
        {
            return GetSegmentValueInternal(0, 0, inputLength - 1, start, end);
        }

        private int GetSegmentValueInternal(int currentPosition, int currentStart, int currentEnd, int start, int end)
        {
            if (currentStart >= start && currentEnd <= end)
            {
                return segmentTree[currentPosition];
            }

            if (currentEnd < start || currentStart > end)
            {
                return DummyValue;
            }

            var moddle = currentStart + (currentEnd - currentStart) / 2;

            return segmentAggregate(GetSegmentValueInternal(currentPosition * 2 + 1, currentStart, moddle, start, end),
                GetSegmentValueInternal(currentPosition * 2 + 2, moddle + 1, currentEnd, start, end));
        }
    }
}
