using AlgorithmsAndDataStructures.Algorithms.Search;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Search;

public class LinearSearchTests : BaseSearchAlgorithmTests
{
    public override ISearchAlgorithm<int> GetSystemUnderTest()
    {
        return new Linear<int>();
    }
}