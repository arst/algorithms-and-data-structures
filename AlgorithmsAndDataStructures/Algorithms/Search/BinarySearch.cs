using System;

namespace AlgorithmsAndDataStructures.Algorithms.Search;

public class BinarySearch<T> : ISearchAlgorithm<T> where T : IComparable<T>
{
    public int Search(T[] target, T value)
    {
        if (target is null) return default;

        var start = 0;
        var end = target.Length;

        var mid = end / 2;

        while (end > start)
        {
            if (value.CompareTo(target[mid]) == 0) return mid;

            if (value.CompareTo(target[mid]) > 0)
                start = mid + 1;
            else
                end = mid;

            mid = start + (end - start) / 2;
        }

        return -1;
    }
}