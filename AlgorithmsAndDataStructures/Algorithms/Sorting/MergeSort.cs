using System;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.Algorithms.Sorting;

/* Characteristics:
 * Complexity: O(n*log2n)
 * Stable: YES
 * In-place: NO
 * Memory: О(n) total with O(n) auxiliary
 * Advantages:
 * 1. No target data is considered 'bad'
 * 2. Good for caching and virtual memory
 * 3. May be parallel to some extent
 * Disadvantages:
 * 1. On almost sorted data works with the same complexity as on the non sorted data
 * 2. Requires O(n) additional memory
 */
public class MergeSort : ISortingAlgorithm
{
    public void Sort(int[] target)
    {
        if (target is null) return;

        if (target.Length < 1) return;

        var sorted = Merge(target, 0, target.Length);

        //Just to adhere to the interface
        Buffer.BlockCopy(sorted, 0, target, 0, sorted.Length * sizeof(int));
    }

    private static int[] Merge(IReadOnlyList<int> input, int start, int end)
    {
        if (end - start == 1) return new[] { input[start] };

        var middle = start + (end - start) / 2;

        var left = Merge(input, start, middle);
        var right = Merge(input, middle, end);

        return MergeInternal(left, right);
    }

    private static int[] MergeInternal(IReadOnlyList<int> left, IReadOnlyList<int> right)
    {
        var result = new int[left.Count + right.Count];
        var leftPointer = 0;
        var rightPointer = 0;
        var resultPointer = 0;

        while (leftPointer < left.Count && rightPointer < right.Count)
        {
            var leftValue = left[leftPointer];
            var rightValue = right[rightPointer];

            if (leftValue < rightValue)
            {
                leftPointer++;
                result[resultPointer] = leftValue;
            }
            else
            {
                rightPointer++;
                result[resultPointer] = rightValue;
            }

            resultPointer++;
        }

        while (rightPointer < right.Count)
        {
            result[resultPointer] = right[rightPointer];
            resultPointer++;
            rightPointer++;
        }

        while (leftPointer < left.Count)
        {
            result[resultPointer] = left[leftPointer];
            resultPointer++;
            leftPointer++;
        }

        return result;
    }
}