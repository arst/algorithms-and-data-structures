using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsAndDataStructures.Algorithms.Sorting;

/* Characteristics:
 * Complexity: O(w*n), where w is the number of bits required to store each key.
 * Stable: YES
 * In-place: NO
 * Advantages:
 * 1. Fast when the keys are short i.e. when the range of the array elements is less.
 * 2. Used in suffix array constuction algorithms like Manber's algorithm and DC3 algorithm.
 * Disadvantages:
 * 1. Since Radix Sort depends on digits or letters, Radix Sort is much less flexible than other sorts. Hence , for every different type of data it needs to be rewritten.
 * 2. The constant for Radix sort is greater compared to other sorting algorithms.
 * 3. It takes more space compared to Quicksort which is inplace sorting.
 */
public class RadixSort : ISortingAlgorithm
{
    public void Sort(int[] target)
    {
        if (target is null) return;

        if (!target.Any()) return;

        var max = target.Max();

        for (var exp = 1; max / exp > 0; exp *= 10) StableCountingSort(target, exp);
    }

    private static void StableCountingSort(IList<int> target, int exp)
    {
        var counters = new int[10];
        var holder = new int[target.Count];

        foreach (var element in target) counters[element / exp % 10]++;

        for (var i = 1; i < counters.Length; i++) counters[i] = counters[i] + counters[i - 1];

        for (var i = target.Count - 1; i > -1; i--)
        {
            counters[target[i] / exp % 10]--;
            holder[counters[target[i] / exp % 10]] = target[i];
        }

        for (var i = 0; i < target.Count; i++) target[i] = holder[i];
    }
}