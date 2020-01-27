using AlgorithmsAndDataStructures.Algorithms.Sorting;
using System;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Sorting
{
    public class RadixSortTests : BaseSortingTests
    {
        protected override int MaxValue => 1000;

        protected override ISortingAlgorithm GetSystemUnderTest()
        {
            return new RadixSort();
        }
    }
}
