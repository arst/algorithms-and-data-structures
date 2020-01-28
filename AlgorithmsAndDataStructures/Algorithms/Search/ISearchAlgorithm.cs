using System;

namespace AlgorithmsAndDataStructures.Algorithms.Search
{
    public interface ISearchAlgorithm<T> where T: IComparable<T> 
    {
        int Search(T[] target, T value);
    }
}
