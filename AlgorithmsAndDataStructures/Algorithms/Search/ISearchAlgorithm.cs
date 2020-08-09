using System;

namespace AlgorithmsAndDataStructures.Algorithms.Search
{
    public interface ISearchAlgorithm<in T> where T: IComparable<T> 
    {
        int Search(T[] target, T value);
    }
}
