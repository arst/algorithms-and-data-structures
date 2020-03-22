using AlgorithmsAndDataStructures.Algorithms.String.Search;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.String.Search
{
    public class BooyerMooreCombinedHeuristicTests : StringSearchAlgorithmBaseTests
    {
        protected override IStringPatternSearchAlgorithm GetSystemUnderTest()
        {
            return new BooyerMooreCombinedHeuristic();
        }
    }
}
