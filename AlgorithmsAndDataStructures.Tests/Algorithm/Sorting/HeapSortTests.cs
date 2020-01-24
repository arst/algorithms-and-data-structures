using AlgorithmsAndDataStructures.Algorithms.Sorting;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Sorting
{
    public class HeapSortTests : BaseSortingTests
    {
        protected override ISortingAlgorithm GetSystemUnderTest()
        {
            return new HeapSort();
        }
    }
}
