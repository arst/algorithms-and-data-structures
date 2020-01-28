using System;

namespace AlgorithmsAndDataStructures.Algorithms.Search
{
    public class Binary<T> : ISearchAlgorithm<T> where T : IComparable<T>
    {
        public int Search(T[] target, T value)
        {
            var start = 0;
            var end = target.Length;
            var mid = start + (end - start) / 2;

            while (end > start)
            {
                if (value.CompareTo(target[mid]) == 0)
                {
                    return mid;
                }
                else if (value.CompareTo(target[mid]) > 0)
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid;
                }
                
                mid = start + (end - start) / 2;
            }

            return -1;
        }
    }
}
