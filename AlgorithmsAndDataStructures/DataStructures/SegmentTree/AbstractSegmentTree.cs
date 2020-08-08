using System;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.DataStructures.SegmentTree
{
    public abstract class AbstractSegmentTree
    {
#pragma warning disable CA1819 // Properties should not return arrays
        protected int[] Tree { get; }
#pragma warning restore CA1819 // Properties should not return arrays

#pragma warning disable CA1819 // Properties should not return arrays
        protected int[] OriginalInput { get; }
#pragma warning restore CA1819 // Properties should not return arrays

        protected int OriginalInputLength { get; }

        private readonly Func<int, int, int> segmentAggregate;

        protected abstract int DummyValue { get; set; }

        protected AbstractSegmentTree(int[] input, Func<int, int, int> segmentAggregate)
        {
            if (input is null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            var x = (int)Math.Ceiling(Math.Log(input.Length) / Math.Log(2));
            var treeSize = 2 * (int)Math.Pow(2, x) - 1;
            Tree = new int[treeSize];
            this.segmentAggregate = segmentAggregate;
            Build(input, 0, input.Length - 1, 0);
            OriginalInput = input;
            OriginalInputLength = OriginalInput.Length;
        }

        private int Build(IReadOnlyList<int> input, int start, int end, int current)
        {
            if (start == end)
            {
                Tree[current] = input[end];

                return Tree[current];
            }

            var middle = start + (end - start) / 2;

            Tree[current] = segmentAggregate(Build(input, start, middle, current * 2 + 1),Build(input, middle + 1, end, current * 2 + 2));

            return Tree[current];
        }

        public int GetSegmentValue(int start, int end)
        {
            return GetSegmentValueInternal(0, 0, OriginalInput.Length - 1, start, end);
        }

        private int GetSegmentValueInternal(int currentPosition, int currentStart, int currentEnd, int start, int end)
        {
            if (currentStart >= start && currentEnd <= end)
            {
                return Tree[currentPosition];
            }

            if (currentEnd < start || currentStart > end)
            {
                return DummyValue;
            }

            var middle = currentStart + (currentEnd - currentStart) / 2;

            return segmentAggregate(GetSegmentValueInternal(currentPosition * 2 + 1, currentStart, middle, start, end),
                GetSegmentValueInternal(currentPosition * 2 + 2, middle + 1, currentEnd, start, end));
        }
    }
}
