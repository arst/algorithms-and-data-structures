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
            if (target is null)
            {
                return;
            }

            for (var i = 0; i < target.Length; i++)
            {
                var smallestIndex = i;
                
                for (var j = i; j < target.Length; j++)
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
