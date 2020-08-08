using System;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.Algorithms.Misc.MedianOfTwoArrays
{
    public class BinarySearchApproach : IMediaOfTwoArraysAlgorithm
    {
        public float GetMedian(int[] left, int[] right)
        {
            if (left is null || right is null)
            {
                return default;
            }

            return GetMedian(left, 0, left.Length, right, 0, right.Length);
        }

        private static float GetMedian(IReadOnlyList<int> left, int leftStart, int leftEnd, IReadOnlyList<int> right, int rightStart, int rightEnd)
        {
            if ((leftEnd - leftStart) + (rightEnd - rightStart) <= 4)
            {
                var merged = Merge(left, leftStart, leftEnd, right, rightStart, rightEnd);
                return GetMedian(merged, 0, merged.Length);
            }

            var leftMedian = GetMedian(left, leftStart, leftEnd);
            var rightMedian = GetMedian(right, rightStart, rightEnd);

            if (Math.Abs(leftMedian - rightMedian) < 0.1)
            {
                return leftMedian;
            }

            if (leftMedian < rightMedian)
            {
                // Take bigger part of the smaller array since these element would be closer to the median
                // Take smaller elements from the bigger array since there elements would be closer to median
                return GetMedian(
                    left,
                    leftStart: (left.Count / 2),
                    leftEnd: leftEnd,
                    right,
                    rightStart: 0,
                    rightEnd: (right.Count / 2) + 1);
            }

            // Take bigger part of the smaller array since these element would be closer to the median
            // Take smaller elements from the bigger array since there elements would be closer to median
            return GetMedian(
                left,
                leftStart: leftStart,
                leftEnd: (left.Count / 2) + 1,
                right,
                rightStart: (right.Count / 2),
                rightEnd: rightEnd);
        }

        private static float GetMedian(IReadOnlyList<int> input, int start, int end)
        {
            if (input.Count == 1)
            {
                return input[0];
            }

            var mid = start + (end - start) / 2;

            return (float)(input[mid] + input[mid - 1]) / 2;
        }

        private static int[] Merge(IReadOnlyList<int> left, int leftStart, int leftEnd, IReadOnlyList<int> right, int rightStart, int rightEnd)
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

        private static void UpFillArray(IList<int> result, IReadOnlyList<int> source, int resultIndex, int sourceStart, int sourceEnd)
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