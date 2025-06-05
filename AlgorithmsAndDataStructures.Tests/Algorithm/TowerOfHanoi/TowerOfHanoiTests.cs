using AlgorithmsAndDataStructures.Algorithms.TowersOfHanoi;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.TowerOfHanoi;

public class TowerOfHanoiTests
{
    [Fact]
    public void Test()
    {
        var sut = new HanoiTowers(2);
        sut.Solve();
    }
}