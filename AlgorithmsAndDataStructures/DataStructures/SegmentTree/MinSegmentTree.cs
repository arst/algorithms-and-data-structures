using System;

namespace AlgorithmsAndDataStructures.DataStructures.SegmentTree
{
    public class MinSegmentTree : AbstractSegmentTree
    {
        public MinSegmentTree(int[] input)
            :base(input, (x,y) => Math.Min(x, y))
        {

        }

        protected override int DummyValue { get; set; } = int.MaxValue;
    }
}
