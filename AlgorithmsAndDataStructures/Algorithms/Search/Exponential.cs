using System;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.Algorithms.Search
{
    public class Exponential<T> : ISearchAlgorithm<T> where T : IComparable<T>
    {
        public int Search(T[] target, T value)
        {
            if (target is null)
            {
                return default;
            }

            if (target.Length == 0)
            {
                return -1;
            }

            if (target.Length == 1)
            {
                return target[0].CompareTo(value) == 0 ? 0 : -1;
            }

            var position = 1;

            while (position < target.Length)
            {
                if (target[position].CompareTo(value) == 0)
                {
                    return position;
                }

                if (target[position].CompareTo(value) < 0)
                {
                    position *= 2;
                    continue;
                }

                return InternalBinarySearch(target, position / 2, position, value);
            }

            return InternalBinarySearch(target, position / 2, target.Length, value);
        }

        private static int InternalBinarySearch(IReadOnlyList<T> target, int start, int end, T value)
        {
            while (end >= start)
            {
                var mid = start + (end - start) / 2;

                if (target[mid].CompareTo(value) == 0)
                {
                    return mid;
                }

                if (target[mid].CompareTo(value) > 0)
                {
                    end = mid - 1;
                }
                else
                {
                    start = mid + 1;
                }
            }

            return -1;
        }
    }
}
