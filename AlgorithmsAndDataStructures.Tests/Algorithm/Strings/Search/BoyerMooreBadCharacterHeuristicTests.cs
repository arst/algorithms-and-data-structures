using AlgorithmsAndDataStructures.Algorithms.Strings.Search;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Strings.Search
{
    public class BoyerMooreBadCharacterHeuristicTests : StringSearchAlgorithmBaseTests
    {
        protected override IStringPatternSearchAlgorithm GetSystemUnderTest()
        {
            return new BoyerMooreBadCharacterHeuristic();
        }
    }
}
