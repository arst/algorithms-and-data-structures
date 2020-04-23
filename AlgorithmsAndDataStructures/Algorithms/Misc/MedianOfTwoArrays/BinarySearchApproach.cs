using System;

namespace AlgorithmsAndDataStructures.Algorithms.Misc.MedianOfTwoArrays
{
    public class BinarySearchApproach
    {
        public float GetMedian(int[] left, int[] right)
        {
            return GetMedian(left, 0, left.Length, right, 0, right.Length);
        }

        public float GetMedian(int[] left, int leftStart, int leftEnd, int[] right, int rightStart, int rightEnd)
        {
            // base case

            var leftMedian = GetMedian(left, leftStart, leftEnd);
            var rightMedian = GetMedian(right, rightStart, rightEnd);

            if (leftMedian == rightMedian)
            {
                return leftMedian;
            }
            else if (leftMedian < rightMedian)
            {
                return GetMedian(left, (left.Length / 2) - 1, left.Length, right, 0, (right.Length / 2) + 1);
            }
            else
            {
                return GetMedian(left, 0, (left.Length / 2) + 1, right, (right.Length / 2) - 1, right.Length);
            }
        }

        private float GetMedian(int[] input, int start, int end)
        {
            if (input.Length == 1)
            {
                return input[0];
            }

            var mid = start + (end - start) / 2;

            return (float)(input[mid] + input[mid - 1]) / 2;
        }
    }
}
