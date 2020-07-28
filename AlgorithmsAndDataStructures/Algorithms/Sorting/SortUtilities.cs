namespace AlgorithmsAndDataStructures.Algorithms.Sorting
{
    public static class SortUtilities
    {
        public static void Swap(int[] array, int a, int b)
        {
            (array[a], array[b]) = (array[b], array[a]);
        }
    }
}
