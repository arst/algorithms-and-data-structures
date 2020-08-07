using AlgorithmsAndDataStructures.Algorithms.DynamicProgramming;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.DynamicProgramming
{
    public class UnboundedKnapsackTests
    {
        [Fact]
        public void SmallKnapsack()
        {
            var sut = new UnboundedKnapsack();

            Assert.Equal(100, sut.GetMaxGain(new[] { 1, 50 }, new[] { 1, 30 }, 100));
        }

        [Fact]
        public void Baseline()
        {
            var sut = new UnboundedKnapsack();

            Assert.Equal(300, sut.GetMaxGain(new[] { 5, 10, 15 }, new[] { 10, 30, 20 }, 100)); 
        }
    }
}
