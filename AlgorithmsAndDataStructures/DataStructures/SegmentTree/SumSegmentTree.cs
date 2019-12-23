using System;

namespace AlgorithmsAndDataStructures.DataStructures.SegmentTree
{
    public class SumSegmentTree : AbstractSegmentTree
    {
        public SumSegmentTree(int[] input)
            : base(input, (x, y) => x+ y)
        {
        }

        protected override int DummyValue { get; set; } = 0;
    }
}
