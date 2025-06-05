using AlgorithmsAndDataStructures.Algorithms.Strings.Search;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Strings.Search;

public class RecursivePatternSearchTests : StringSearchAlgorithmBaseTests
{
    protected override IStringPatternSearchAlgorithm GetSystemUnderTest()
    {
        return new RecursivePatternSearch();
    }
}