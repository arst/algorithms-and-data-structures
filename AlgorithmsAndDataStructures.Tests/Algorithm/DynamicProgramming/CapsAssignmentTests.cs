using AlgorithmsAndDataStructures.Algorithms.DynamicProgramming;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.DynamicProgramming
{
    public class CapsAssignmentTests
    {
        [Fact]
        public void Baseline() 
        {
            var sut = new CapsAssignment();

            var hatCollections = new int[2][];
            hatCollections[0] = new [] { 1, 4, 3 };
            hatCollections[1] = new [] { 2, 1, 3 };

            Assert.Equal(7, sut.GetMaxAssignment(hatCollections, 5));
        }
    }
}
