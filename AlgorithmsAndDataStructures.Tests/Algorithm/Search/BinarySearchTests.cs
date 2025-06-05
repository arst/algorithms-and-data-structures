using AlgorithmsAndDataStructures.Algorithms.Search;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Search;

public class BinarySearchTests : BaseSearchAlgorithmTests
{
    public override ISearchAlgorithm<int> GetSystemUnderTest()
    {
        return new BinarySearch<int>();
    }
}