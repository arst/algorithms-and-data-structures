using AlgorithmsAndDataStructures.Algorithms.Sorting;
using System;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Sorting
{
    public class QuickSortTests : BaseSortingTests
    {
        protected override ISortingAlgorithm GetSystemUnderTest()
        {
            return new QuickSort();
        }
    }
}
