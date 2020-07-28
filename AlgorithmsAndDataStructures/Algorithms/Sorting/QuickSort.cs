namespace AlgorithmsAndDataStructures.Algorithms.Sorting
{
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
    public class QuickSort : ISortingAlgorithm
    {
        public void Sort(int[] target)
        {
            SortInternal(target, 0, target.Length - 1);
        }

        private static void SortInternal(int[] input, int start, int end)
        {
            if (end <= start)
            {
                return;
            }

            var pivot = Partition(input, start, end);
            
            SortInternal(input, start, pivot);
            SortInternal(input, pivot + 1, end);
        }

        private static int Partition(int[] input, int start, int end)
        {
            var pivot = input[start + ((end - start) / 2)];
            var leftPointer = start-1;
            var rightPointer = end + 1;

            while (true)
            {
                do
                {
                    leftPointer++;
                } while (input[leftPointer] < pivot);

                do
                {
                    rightPointer--;
                } while (input[rightPointer] > pivot);

                if (leftPointer >= rightPointer)
                {
                    return rightPointer;
                }

                SortUtilities.Swap(input, leftPointer, rightPointer);
            }
        }
    }
}
