using AlgorithmsAndDataStructures.Algorithms.Sorting;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Sorting;

public class QuickSort_LomutoTests : BaseSortingTests
{
    protected override ISortingAlgorithm GetSystemUnderTest()
    {
        return new QuickSort_Lomuto();
    }
}