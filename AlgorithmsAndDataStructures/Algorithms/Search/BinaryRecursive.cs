using System;

namespace AlgorithmsAndDataStructures.Algorithms.Search
{
    public class BinaryRecursive : ISearchAlgorithm<int>
    {
        public int Search(int[] target, int value)
        {
            return SearchInternal(target, 0, target.Length, value);
        }

        private int SearchInternal(int[] target, int start, int end, int value)
        {
            if (start >= end)
            {
                return -1;
            }

            var mid = start + (end - start) / 2;

            if (target[mid] == value)
            {
                return mid;
            }

            if (target[mid] > value)
            {
                return SearchInternal(target, start, mid, value);
            }
            else
            {
                return SearchInternal(target, mid + 1, end, value);
            }
        }
    }
}
