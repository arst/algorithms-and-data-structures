using AlgorithmsAndDataStructures.Algorithms.Strings.Search;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Strings.Search;

public class KnuthMorrisPrattTests : StringSearchAlgorithmBaseTests
{
    protected override IStringPatternSearchAlgorithm GetSystemUnderTest()
    {
        return new KnuthMorrisPratt();
    }
}