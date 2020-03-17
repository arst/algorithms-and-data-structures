using AlgorithmsAndDataStructures.Algorithms.String.Search;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.String.Search
{
    public class RecursivePatternSearchTests : StringSearchAlgorithmBaseTests
    {
        protected override IStringPatternSearchAlgorithm GetSystemUnderTest()
        {
            return new RecursivePatternSearch();
        }
    }
}
