using System;

namespace AlgorithmsAndDataStructures.Algorithms.Search
{
    public class BinaryRecursive<T> : ISearchAlgorithm<T> where T : IComparable<T>
    {
        public int Search(T[] target, T value)
        {
            return target is null ? default : SearchInternal(target, 0, target.Length, value);
        }

        private static int SearchInternal(T[] target, int start, int end, T value)
        {
            if (start >= end)
            {
                return -1;
            }

            var mid = start + (end - start) / 2;

            if (value.CompareTo(target[mid]) == 0)
            {
                return mid;
            }

            if (value.CompareTo(target[mid]) < 0)
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
