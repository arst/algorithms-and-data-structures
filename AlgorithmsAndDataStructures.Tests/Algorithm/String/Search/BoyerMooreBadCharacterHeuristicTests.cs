using AlgorithmsAndDataStructures.Algorithms.StringAlgorithms.Search;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.String.Search
{
    public class BoyerMooreBadCharacterHeuristicTests : StringSearchAlgorithmBaseTests
    {
        protected override IStringPatternSearchAlgorithm GetSystemUnderTest()
        {
            return new BoyerMooreBadCharacterHeuristic();
        }
    }
}
