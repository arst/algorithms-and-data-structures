using AlgorithmsAndDataStructures.Algorithms.DynamicProgramming;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.DynamicProgramming
{
    public class ChangeMakingProblemTests
    {
        [Fact]
        public void SmallChange()
        {
            var sut = new ChangeMakingProblem();

            Assert.Equal(3, sut.GetMinChange(new int[] { 1, 2, 5 }, 11));
        }
    }
}
