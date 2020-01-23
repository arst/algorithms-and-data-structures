namespace AlgorithmsAndDataStructures.Algorithms.Sorting
{
    public static class SortUtilities
    {
        public static void Swap(int[] array, int a, int b)
        {
            var temp = array[a];
            array[a] = array[b];
            array[b] = temp;
        }
    }
}
