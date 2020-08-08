using AlgorithmsAndDataStructures.Algorithms.StringAlgorithms.Search;

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
