using AlgorithmsAndDataStructures.Algorithms.Search;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Search
{
    public class ExponentialSearchTests : BaseSearchAlgorithmTests
    {
        public override ISearchAlgorithm<int> GetSystemUnderTest()
        {
            return new Exponential<int>();
        }
    }
}
