using AlgorithmsAndDataStructures.Algorithms.Misc.MedianOfTwoArrays;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Misc.MedianOfTwoArrays
{
    public class NaiveNonMergeApproachTests
    {
        [Fact]
        public void Baseline()
        {
            var sut = new NaiveNonMergeApproach();

            Assert.Equal(3.5f, sut.GetMedian(new int[] { 1, 3, 5 }, new int[] { 2, 4, 6 }));
        }
    }
}
