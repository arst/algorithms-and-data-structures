using AlgorithmsAndDataStructures.Algorithms.Sorting;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Sorting
{
    public class BubbleSortTests : BaseSortingTests
    {
        protected override ISortingAlgorithm GetSystemUnderTest()
        {
            return new BubbleSort();
        }
    }
}
