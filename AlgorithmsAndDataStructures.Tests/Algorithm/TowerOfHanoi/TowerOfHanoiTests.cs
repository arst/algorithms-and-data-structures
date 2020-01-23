using AlgorithmsAndDataStructures.Algorithms.TowersOfHanoi;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.TowerOfHanoi
{
    public class TowerOfHanoiTests
    {
        [Fact]
        public void Test()
        {
            var sut = new TowersOfHanoi(2);
            sut.Solve();
        }
    }
}
