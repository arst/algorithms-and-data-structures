using AlgorithmsAndDataStructures.Algorithms.Search;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Search;

public class Fibonacci : BaseSearchAlgorithmTests
{
    public override ISearchAlgorithm<int> GetSystemUnderTest()
    {
        return new Fibonacci<int>();
    }
}