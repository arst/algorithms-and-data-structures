using AlgorithmsAndDataStructures.Algorithms.Sorting;

namespace AlgorithmsAndDataStructures.Algorithms.Search
{
    public class QuickSelect
    {
        public int GetLargestElement(int[] input, int target)
        {
            return GetLargestElementInternal(input, 0, input.Length - 1, target);
        }

        private int GetLargestElementInternal(int[] input, int start, int end, int target)
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
            else
            {
                return GetLargestElementInternal(input, pivot + 1, end, target);
            }
        }

        private int Partition(int[] input, int start, int end)
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
