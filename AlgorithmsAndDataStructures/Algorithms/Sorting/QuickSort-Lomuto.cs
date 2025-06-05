namespace AlgorithmsAndDataStructures.Algorithms.Sorting;

/* Characteristics:
 * Complexity: O(n log n), O(n2) in worst case
 * Stable: NO
 * In-place: YES
 * Advantages:
 * 1. Good for caching and virtual memory
 * Disadvantages:
 * 1. Heavily decreases in speed down to O(n2) in the case of unsuccessful pivot selections
 * 2. Lame implementation of the algorithm may result in stack overflow error, since it may require O(n) embedded recursive calls
 */
public class QuickSort_Lomuto : ISortingAlgorithm
{
    public void Sort(int[] target)
    {
        if (target is null) return;

        SortInternal(target, 0, target.Length - 1);
    }

    private static void SortInternal(int[] input, int start, int end)
    {
        if (end <= start) return;

        var pivot = Partition(input, start, end);

        SortInternal(input, start, pivot - 1);
        SortInternal(input, pivot + 1, end);
    }

    private static int Partition(int[] input, int start, int end)
    {
        var pivot = input[end];

        var seen = start - 1;

        for (var frontier = start; frontier < end + 1; frontier++)
            if (input[frontier] <= pivot)
            {
                seen += 1;
                SortUtilities.Swap(input, seen, frontier);
            }

        return seen;
    }
}