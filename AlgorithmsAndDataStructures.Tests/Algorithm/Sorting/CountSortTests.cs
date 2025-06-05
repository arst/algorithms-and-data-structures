using AlgorithmsAndDataStructures.Algorithms.Sorting;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Sorting;

public class CountSortTests : BaseSortingTests
{
    protected override int MaxValue { get; } = 100;

    protected override ISortingAlgorithm GetSystemUnderTest()
    {
        return new CountSort();
    }
}