using AlgorithmsAndDataStructures.Algorithms.Search;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Search;

public class InterpolationSortTests : BaseSearchAlgorithmTests
{
    public override ISearchAlgorithm<int> GetSystemUnderTest()
    {
        return new Interpolation();
    }
}