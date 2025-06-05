using AlgorithmsAndDataStructures.Algorithms.Bitwise;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Bitwise;

public class AddOneTests
{
    [Fact]
    public void Baseline()
    {
        var sut = new AddOne();
        for (var i = -100_000_000; i <= 1_000_000; i++) Assert.Equal(i + 1, sut.Add(i));
    }
}