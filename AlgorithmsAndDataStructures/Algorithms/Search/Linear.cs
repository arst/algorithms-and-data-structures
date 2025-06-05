﻿using System;

namespace AlgorithmsAndDataStructures.Algorithms.Search;

/* Characteristics:
 * Complexity: o(n)
 * It's slow, useful only for comparison with other algorithms. Though, it may be ok to use it on a small sets of data.
 */
public class Linear<T> : ISearchAlgorithm<T> where T : IComparable<T>
{
    public int Search(T[] target, T value)
    {
        if (target is null) return default;

        for (var i = 0; i < target.Length; i++)
            if (target[i].CompareTo(value) == 0)
                return i;

        return -1;
    }
}