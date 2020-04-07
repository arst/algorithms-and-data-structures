using AlgorithmsAndDataStructures.Algorithms.DynamicProgramming;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.DynamincProgramming
{
    public class UnboundedKnapsackTests
    {
        [Fact]
        public void SmallKnapsack()
        {
            var sut = new UnboundedKnapsack();

            Assert.Equal(100, sut.GetMaxGain(new int[] { 1, 50 }, new int[] { 1, 30 }, 100));
        }

        [Fact]
        public void Baseline()
        {
            var sut = new UnboundedKnapsack();

            Assert.Equal(300, sut.GetMaxGain(new int[] { 5, 10, 15 }, new int[] { 10, 30, 20 }, 100)); 
        }
    }
}
