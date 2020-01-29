using AlgorithmsAndDataStructures.Algorithms.Search;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Search
{
    public class JumpSearchTests : BaseSearchAlgorithmTests
    {
        public override ISearchAlgorithm<int> GetSystemUnderTest()
        {
            return new Jump<int>();
        }
    }
}
