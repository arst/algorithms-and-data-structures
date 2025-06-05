using AlgorithmsAndDataStructures.Algorithms.Sorting;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Sorting;

public class MergeSortTests : BaseSortingTests
{
    protected override ISortingAlgorithm GetSystemUnderTest()
    {
        return new MergeSort();
    }
}