using AlgorithmsAndDataStructures.Algorithms.Sorting;
using System;

namespace AlgorithmsAndDataStructures.Algorithms.Sorting
{
    public class HeapSort : ISortingAlgorithm
    {
        public void Sort(int[] target)
        {

            // (target.Length / 2) - 1 - this will remove all leaves from the build, they are triviaal and has no children
            // to they are already hipified
            for (int i = (target.Length / 2) - 1; i >= 0; i--)
            {
                BuildMaxHeapInPlace(target, target.Length, i);
            }

            var lastElement = target.Length - 1;

            for (int i = target.Length - 1; i >= 0; i--)
            {
                // Move current root to end 
                int temp = target[0];
                target[0] = target[i];
                target[i] = temp;

                BuildMaxHeapInPlace(target, i, 0);
            }
        }

        private static void BuildMaxHeapInPlace(int[] target, int heapSize, int root)
        {
            var largestIndexInSubtree = root;
            var leftChildIdex = (root * 2) + 1;
            var rightChildIndex = (root * 2) + 2;

            if (heapSize > leftChildIdex && target[largestIndexInSubtree] < target[leftChildIdex])
            {
                largestIndexInSubtree = leftChildIdex;
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
