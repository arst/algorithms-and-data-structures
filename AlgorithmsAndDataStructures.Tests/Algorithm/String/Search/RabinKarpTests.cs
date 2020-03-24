using AlgorithmsAndDataStructures.Algorithms.String.Search;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.String.Search
{
    public class RabinKarpTests : StringSearchAlgorithmBaseTests
    {
        protected override IStringPatternSearchAlgorithm GetSystemUnderTest()
        {
            return new RabinKarp();
        }
    }
}
