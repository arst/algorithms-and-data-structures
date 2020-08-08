using AlgorithmsAndDataStructures.Algorithms.StringAlgorithms.Search;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Strings.Search
{
    public class BooyerMooreCombinedHeuristicTests : StringSearchAlgorithmBaseTests
    {
        protected override IStringPatternSearchAlgorithm GetSystemUnderTest()
        {
            return new BooyerMooreCombinedHeuristic();
        }
    }
}
