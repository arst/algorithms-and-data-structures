using AlgorithmsAndDataStructures.Algorithms.Sorting;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Sorting;

public class RadixSortTests : BaseSortingTests
{
    protected override int MaxValue => 1000;

    protected override ISortingAlgorithm GetSystemUnderTest()
    {
        return new RadixSort();
    }
}