using System;

namespace AlgorithmsAndDataStructures.DataStructures.SegmentTree
{
    public class SumSegmentTree
    {
        private readonly int[] segmentTree;

        public SumSegmentTree(int[] input)
        {
            int x = (int)(Math.Ceiling(Math.Log(input.Length) / Math.Log(2)));

            int treeSize = 2 * (int)Math.Pow(2, x) - 1;

            segmentTree = new int[treeSize];

            Build(input, 0, input.Length -1, 0);
        }


        private int Build(int[] input, int start, int end, int current)
        {
            if (start == end)
            {
                segmentTree[current] = input[end];

                return segmentTree[current];
            }

            var middle = (start + (end - start)) / 2;

            segmentTree[current] = Build(input, start, middle, current * 2 + 1) + 
                Build(input, middle + 1, end, current * 2 + 2);

            return segmentTree[current];
        }

        /*
        private int Build(int[] input, int start, int end, int current)
        {
            if (end == start)
            {
                segmentTree[current] = input[end];
                return input[end];
            }

            var middle = start + (end - start) / 2;

            segmentTree[current] = Build(input, start, middle, current * 2 + 1) + 
                Build(input, middle + 1, end, current * 2 + 2);

            return segmentTree[current];
        }*/
    }
}
