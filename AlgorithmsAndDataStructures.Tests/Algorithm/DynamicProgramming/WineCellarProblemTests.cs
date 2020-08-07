using AlgorithmsAndDataStructures.Algorithms.DynamicProgramming;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.DynamicProgramming
{
    public class WineCellarProblemTests
    {
        [Fact]
        public void Baseline()
        {
            var sut = new WineCellarProblem();

            Assert.Equal(50, sut.GetMaxProfit(new [] { 2, 3, 5, 1, 4 }));
        }
    }
}
