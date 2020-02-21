using AlgorithmsAndDataStructures.Algorithms.Backtracking;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Backtracking
{
    public class KnightsTourProblemTests
    {
        [Fact]
        public void HasMove()
        {
            var sut = new KnightsTour();
            Assert.True(sut.GetTour());
        }
    }
}
