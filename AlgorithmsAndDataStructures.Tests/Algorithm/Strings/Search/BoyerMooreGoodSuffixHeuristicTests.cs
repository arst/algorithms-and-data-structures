using AlgorithmsAndDataStructures.Algorithms.StringAlgorithms.Search;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Strings.Search
{
    public class BoyerMooreGoodSuffixHeuristicTests : StringSearchAlgorithmBaseTests
    {
        protected override IStringPatternSearchAlgorithm GetSystemUnderTest()
        {
            return new BoyerMooreGoodSuffixHeuristic();
        }
    }
}
