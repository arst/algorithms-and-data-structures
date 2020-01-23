namespace AlgorithmsAndDataStructures.Algorithms.Sorting
{
    public class BubbleSort : ISortingAlgorithm
    {
        /* Characteristics:
        * Complexity: o(n^2)
        * Stable: YES
        * In-place: YES
        * Online: YES
        * Advantages:
        * 1. Simple implementation
        */

        public void Sort(int[] target)
        {
            var swapped = false;
            var j = 0;
            do
            {
                swapped = false;
                for (int i = 1; i < target.Length - j; i++)
                {
                    if (target[i - 1] > target[i])
                    {
                        SortUtilities.Swap(target, i, i - 1);
                        swapped = true;
                    }
                }
                j++;
            } while (swapped);
        }
    }
}
