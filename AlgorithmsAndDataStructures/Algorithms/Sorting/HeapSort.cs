namespace AlgorithmsAndDataStructures.Algorithms.Sorting
{
    public class HeapSort : ISortingAlgorithm
    {
        public void Sort(int[] target)
        {
            // (target.Length / 2) - 1 - this will remove all leaves from the build, they are trivial and has no children
            // to they are already heapified
            for (var i = (target.Length / 2) - 1; i >= 0; i--)
            {
                BuildMaxHeapInPlace(target, target.Length, i);
            }

            for (var i = target.Length - 1; i >= 0; i--)
            {
                // Move current root to the end 
                SortUtilities.Swap(target, 0, i);
                BuildMaxHeapInPlace(target, i, 0);
            }
        }

        private static void BuildMaxHeapInPlace(int[] target, int heapSize, int root)
        {
            var largestIndexInSubtree = root;
            var leftChildIndex = (root * 2) + 1;
            var rightChildIndex = (root * 2) + 2;

            if (heapSize > leftChildIndex && target[largestIndexInSubtree] < target[leftChildIndex])
            {
                largestIndexInSubtree = leftChildIndex;
            }

            if (heapSize > rightChildIndex && target[largestIndexInSubtree] < target[rightChildIndex])
            {
                largestIndexInSubtree = rightChildIndex;
            }

            if (largestIndexInSubtree != root)
            {
                SortUtilities.Swap(target, root, largestIndexInSubtree);
                BuildMaxHeapInPlace(target, heapSize, largestIndexInSubtree);
            }
        }
    }
}
