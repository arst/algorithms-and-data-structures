using AlgorithmsAndDataStructures.Algorithms.DynamicProgramming;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.DynamicProgramming;

public class UniqueChangeMakingProblemTests
{
    [Fact]
    public void Baseline()
    {
        var sut = new UniqueChangeMakingProblem();

        Assert.Equal(4, sut.GetTotalNumberOfPossibleExchanges(new[] { 1, 2, 5 }, 5));

        Assert.Equal(4, sut.GetTotalNumberOfPossibleExchanges(new[] { 1, 2, 3 }, 4));

        Assert.Equal(5, sut.GetTotalNumberOfPossibleExchanges(new[] { 2, 5, 3, 6 }, 10));
    }
}