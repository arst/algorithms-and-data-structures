using System;
using System.Linq;
using AlgorithmsAndDataStructures.Algorithms.Backtracking;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Backtracking;

public class TugOfWarTests
{
    private readonly TugOfWar sut;

    public TugOfWarTests()
    {
        sut = new TugOfWar();
    }

    [Theory]
    [InlineData(null)]
    [InlineData(new int[0])]
    public void GetTug_EmptyOrNullSet_ReturnsEmptyArrays(int[] set)
    {
        var (left, right) = sut.GetTug(set);

        Assert.Empty(left);
        Assert.Empty(right);
    }

    [Fact]
    public void GetTug_TwoEqualElements_ReturnsEqualSplit()
    {
        var set = new[] { 2, 2 };
        var (left, right) = sut.GetTug(set);

        Assert.Single(left);
        Assert.Single(right);
        Assert.Equal(2, left[0]);
        Assert.Equal(2, right[0]);
        Assert.Equal(left.Sum(), right.Sum());
    }

    [Fact]
    public void GetTug_FourElements_ReturnsEqualSumSplit()
    {
        var set = new[] { 1, 2, 3, 4 };
        var (left, right) = sut.GetTug(set);

        Assert.Equal(2, left.Length);
        Assert.Equal(2, right.Length);
        Assert.Equal(left.Sum(), right.Sum());
        Assert.Equal(5, left.Sum());
    }

    [Fact]
    public void GetTug_OddElementCount_ReturnsValidSplit()
    {
        var set = new[] { 2, 2, 3, 1, 4 };
        var (left, right) = sut.GetTug(set);

        Assert.Equal(2, left.Length);
        Assert.Equal(3, right.Length);
        Assert.Equal(left.Sum(), right.Sum());
        Assert.Equal(6, left.Sum());
    }

    [Fact]
    public void GetTug_LargeEvenSet_ReturnsValidSplit()
    {
        var set = new[] { 3, 4, 5, -3, 100, 1, 89, 54, 23, 20 };
        var (left, right) = sut.GetTug(set);

        Assert.Equal(5, left.Length);
        Assert.Equal(5, right.Length);
        Assert.Equal(left.Sum(), right.Sum());
        Assert.Equal(148, left.Sum());
    }

    [Fact]
    public void GetTug_NoSolutionExists_ReturnsEmptyArrays()
    {
        var set = new[] { 23, 45, -34, 12, 0, 98, -99, 4, 189, -1, 4 };
        var (left, right) = sut.GetTug(set);

        Assert.Empty(left);
        Assert.Empty(right);
    }

    [Theory]
    [InlineData(new[] { 1, 1, 1, 1 })]       // Equal numbers
    [InlineData(new[] { -2, -2, 2, 2 })]     // Positive and negative
    [InlineData(new[] { 0, 0, 0, 0 })]       // All zeros
    public void GetTug_SymmetricSets_ReturnsValidSplit(int[] set)
    {
        var (left, right) = sut.GetTug(set);

        Assert.Equal(2, left.Length);
        Assert.Equal(2, right.Length);
        Assert.Equal(left.Sum(), right.Sum());
    }
}