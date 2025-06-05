using AlgorithmsAndDataStructures.Algorithms.Sorting;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Sorting;

public class QuickSortTests : BaseSortingTests
{
    protected override ISortingAlgorithm GetSystemUnderTest()
    {
        return new QuickSort();
    }
}