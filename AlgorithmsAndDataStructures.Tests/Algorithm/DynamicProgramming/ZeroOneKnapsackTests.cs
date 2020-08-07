using AlgorithmsAndDataStructures.Algorithms.DynamicProgramming;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.DynamicProgramming
{
    public class ZeroOneKnapsackTests
    {
        [Fact]
        public void SmallKnapsack()
        {
            var sut = new ZeroOneKnapsack();

            Assert.Equal(30, sut.GetMaxGain(new [] { 5, 2}, new [] { 20, 10, }, 10));
        }

        [Fact]
        public void Baseline()
        {
            var sut = new ZeroOneKnapsack();

            Assert.Equal(220, sut.GetMaxGain(new [] { 10, 20, 30 }, new [] { 60, 100, 120 }, 50));
        }

        [Fact]
        public void BigKnapsack()
        {
            var sut = new ZeroOneKnapsack();

            Assert.Equal(
                1030,
                sut.GetMaxGain(
                new [] { 9, 13, 153, 50, 15, 68, 27, 39, 23, 52, 11, 32, 24, 48, 73, 42, 43, 22, 7, 18, 4 },
                new [] { 150, 35, 200, 160, 60, 45, 60, 40, 30, 10, 70, 30, 15, 10, 40, 70, 75, 80, 20, 12, 50 },
                400));
        }
    }
}
