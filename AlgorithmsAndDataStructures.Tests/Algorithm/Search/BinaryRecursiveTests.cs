using AlgorithmsAndDataStructures.Algorithms.Search;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Search;

public class BinaryRecursiveTests : BaseSearchAlgorithmTests
{
    public override ISearchAlgorithm<int> GetSystemUnderTest()
    {
        return new BinaryRecursive<int>();
    }
}