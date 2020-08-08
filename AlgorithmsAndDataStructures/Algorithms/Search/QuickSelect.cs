using AlgorithmsAndDataStructures.Algorithms.Sorting;

namespace AlgorithmsAndDataStructures.Algorithms.Search
{
    public class QuickSelect
    {
#pragma warning disable CA1822 // Mark members as static
        public int GetLargestElement(int[] input, int target)
#pragma warning restore CA1822 // Mark members as static
        {
            return input is null ? default : GetLargestElementInternal(input, 0, input.Length - 1, target);
        }

        private static int GetLargestElementInternal(int[] input, int start, int end, int target)
        {
            if (start == end && start == target)
            {
                return input[target];
            }

            var pivot = Partition(input, start, end);

            if (pivot == target)
            {
                return input[target];
            }

            if (pivot > target)
            {
                return GetLargestElementInternal(input, start, pivot, target);
            }

            return GetLargestElementInternal(input, pivot + 1, end, target);
        }

        private static int Partition(int[] input, int start, int end)
        {
            var mid = start + ((end - start) / 2);

            var leftPointer = start - 1;
            var rightPointer = end + 1;

            while (true)
            {
                do
                {
                    leftPointer++;
                } while (input[leftPointer] < input[mid]);
                do
                {
                    rightPointer--;
                } while (input[rightPointer] > input[mid]);

                if (rightPointer <= leftPointer)
                {
                    return rightPointer;
                }

                SortUtilities.Swap(input, leftPointer, rightPointer);
            }            
        }
    }
}
