using AlgorithmsAndDataStructures.Algorithms.Sorting;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Sorting;

public class CombSortTests : BaseSortingTests
{
    protected override ISortingAlgorithm GetSystemUnderTest()
    {
        return new CombSort();
    }
}