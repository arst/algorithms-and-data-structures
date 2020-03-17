using AlgorithmsAndDataStructures.Algorithms.String.Search;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.String.Search
{
    public class KnuthMorrisPrattTests : StringSearchAlgorithmBaseTests
    {
        protected override IStringPatternSearchAlgorithm GetSystemUnderTest()
        {
            return new KnuthMorrisPratt();
        }
    }
}
