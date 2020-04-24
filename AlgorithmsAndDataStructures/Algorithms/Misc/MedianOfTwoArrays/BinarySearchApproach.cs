using System;

namespace AlgorithmsAndDataStructures.Algorithms.Misc.MedianOfTwoArrays
{
    public class BinarySearchApproach : IMediaOfTwoArraysAlgorithm
    {
        public float GetMedian(int[] left, int[] right)
        {
            return GetMedian(left, 0, left.Length, right, 0, right.Length);
        }

        public float GetMedian(int[] left, int leftStart, int leftEnd, int[] right, int rightStart, int rightEnd)
        {
            if ((leftEnd - leftStart) + (rightEnd - rightStart) <= 4)
            {
                var merged = Merge(left, leftStart, leftEnd, right, rightStart, rightEnd);
                return GetMedian(merged, 0, merged.Length);
            }

            var leftMedian = GetMedian(left, leftStart, leftEnd);
            var rightMedian = GetMedian(right, rightStart, rightEnd);

            if (leftMedian == rightMedian)
            {
                return leftMedian;
            }
            else if (leftMedian < rightMedian)
            {
                // Take bigger part of the smaller array since these element would be closer to the median
                // Take smaller elements from the bigger array since there elements would be closer to median
                return GetMedian(
                    left,
                    leftStart: (left.Length / 2), 
                    leftEnd: leftEnd, 
                    right,
                    rightStart: 0,
                    rightEnd: (right.Length / 2) + 1);
            }
            else
            {
                // Take bigger part of the smaller array since these element would be closer to the median
                // Take smaller elements from the bigger array since there elements would be closer to median
                return GetMedian(
                   left,
                   leftStart: leftStart,
                   leftEnd: (left.Length / 2) + 1, 
                   right,
                   rightStart: (right.Length / 2),
                   rightEnd: rightEnd);
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

        private int[] Merge(int[] left, int leftStart, int leftEnd, int[] right, int rightStart, int rightEnd)
        {
            var leftPointer = leftStart;
            var rightPointer = rightStart;
            var resultPointer = 0;

            var result = new int[(leftEnd - leftStart) + (rightEnd - rightStart)];

            while (leftPointer < leftEnd && rightPointer < rightEnd)
            {
                if (left[leftPointer] < right[rightPointer])
                {
                    result[resultPointer] = left[leftPointer];
                    leftPointer++;
                }
                else
                {
                    result[resultPointer] = right[rightPointer];
                    rightPointer++;
                }

                resultPointer++;
            }

            UpFillArray(result, left, resultPointer, leftPointer, leftEnd);
            UpFillArray(result, right, resultPointer, rightPointer, rightEnd);

            return result;
        }

        private void UpFillArray(int[] result, int[] source, int resultIndex, int sourceStart, int sourceEnd)
        {
            while (sourceStart < sourceEnd)
            {
                result[resultIndex] = source[sourceStart];
                sourceStart++;
                resultIndex++;
            }
        }
    }
}
