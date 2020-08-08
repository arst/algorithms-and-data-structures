using AlgorithmsAndDataStructures.Algorithms.StringAlgorithms.Search;

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
