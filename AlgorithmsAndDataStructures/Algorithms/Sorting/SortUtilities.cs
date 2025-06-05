namespace AlgorithmsAndDataStructures.Algorithms.Sorting;

public static class SortUtilities
{
    public static void Swap(int[] array, int a, int b)
    {
        if (array is null) return;

        (array[a], array[b]) = (array[b], array[a]);
    }
}