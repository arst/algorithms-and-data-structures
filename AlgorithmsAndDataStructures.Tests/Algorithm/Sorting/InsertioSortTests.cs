using AlgorithmsAndDataStructures.Algorithms.Sorting;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Sorting;

public class InsertioSortTests : BaseSortingTests
{
    protected override ISortingAlgorithm GetSystemUnderTest()
    {
        return new InsertionSort();
    }
}