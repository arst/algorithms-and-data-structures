namespace AlgorithmsAndDataStructures.Algorithms.Sorting
{
    public class SelectionSort : ISortingAlgorithm
    {
        /* Characteristics:
        * Complexity: o(n^2)
        * Stable: YES
        * In-place: YES
        * Online: NO
        * Advantages:
        * 1. Simple implementation
        * 2. Makes the minimum possible number of swaps, n − 1 in the worst case.
        */
        public void Sort(int[] target)
        {
            for (int i = 0; i < target.Length; i++)
            {
                var smallestIndex = i;
                
                for (int j = i; j < target.Length; j++)
                {
                    if (target[smallestIndex] > target[j])
                    {
                        smallestIndex = j;
                    }
                }

                SortUtilities.Swap(target,smallestIndex, i);
            }
        }
    }
}
