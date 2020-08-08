using AlgorithmsAndDataStructures.Algorithms.StringAlgorithms.Search;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.String.Search
{
    public class BoyerMooreGoodSuffixHeuristicTests : StringSearchAlgorithmBaseTests
    {
        protected override IStringPatternSearchAlgorithm GetSystemUnderTest()
        {
            return new BoyerMooreGoodSuffixHeuristic();
        }
    }
}
