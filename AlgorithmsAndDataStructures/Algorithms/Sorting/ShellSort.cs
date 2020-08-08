namespace AlgorithmsAndDataStructures.Algorithms.Sorting
{
    /* Characteristics:
     * Complexity: from o(n^ 5/4), o(n^3/2)[depends on the selected gap size] to o(n^2) on average
     * Stable: NO
     * In-place: YES
     * Online: NO
     * Advantages:
     * 1. No additional memory required for stack(recursion) like in divide and conquer sorts.
     * 2. Doesn't degrade with bad data sets. Quicksort can easily degrade to o(n^2). 
     * 3. More efficient in practice than most other simple quadratic (i.e., O(n^2)) algorithms such as selection sort or bubble sort
     * 4. Adaptive, i.e., efficient for data sets that are already substantially sorted: 
     *    the time complexity is O(kn) when each element in the input is no more than k places away from its sorted position
     */
    public class ShellSort : ISortingAlgorithm
    {
        public void Sort(int[] target)
        {
            if (target is null)
            {
                return;
            }

            for (var gap = target.Length / 2; gap > 0; gap /= 2)
            {
                for (var startingPosition = gap; startingPosition < target.Length; startingPosition++)
                {
                    var temp = target[startingPosition];

                    int finalPosition;
                    //Insertion sort over gap-separated group of elements
                    for (finalPosition = startingPosition; finalPosition >= gap && temp < target[finalPosition - gap]; finalPosition -= gap)
                    {
                        target[finalPosition] = target[finalPosition - gap];
                    }

                    target[finalPosition] = temp;
                }
            }
        }
    }
}
