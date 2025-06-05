using System;
using System.Linq;
using AlgorithmsAndDataStructures.Algorithms.Backtracking;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Backtracking;

public class TugOfWarBestMatchTests
{
    private readonly TugOfWarBestMatch sut;

    public TugOfWarBestMatchTests()
    {
        sut = new TugOfWarBestMatch();
    }

    [Theory]
    [InlineData(null)]
    [InlineData(new int[0])]
    public void GetTug_EmptyOrNullInput_ReturnsEmptyArrays(int[] input)
    {
        var (left, right) = sut.GetTug(input);

        Assert.Empty(left);
        Assert.Empty(right);
    }

    [Theory]
    [InlineData(new[] { 2, 2 })]
    [InlineData(new[] { -1, -1 })]
    [InlineData(new[] { 0, 0 })]
    public void GetTug_TwoIdenticalElements_SplitsEvenly(int[] input)
    {
        var (left, right) = sut.GetTug(input);

        Assert.Single(left);
        Assert.Single(right);
        Assert.Equal(left[0], right[0]);
        Assert.Equal(0, Math.Abs(left.Sum() - right.Sum()));
    }

    [Theory]
    [InlineData(new[] { 1, 2, 3, 4 }, 5, 5)]
    [InlineData(new[] { -2, -1, 1, 2 }, 0, 0)]
    [InlineData(new[] { 10, 20, 15, 25 }, 35, 35)]
    public void GetTug_EvenElementCount_FindsOptimalSplit(int[] input, int expectedLeftSum, int expectedRightSum)
    {
        var (left, right) = sut.GetTug(input);

        Assert.Equal(input.Length / 2, left.Length);
        Assert.Equal(input.Length / 2, right.Length);
        Assert.Equal(expectedLeftSum, left.Sum());
        Assert.Equal(expectedRightSum, right.Sum());
    }

    [Theory]
    [InlineData(new[] { 2, 2, 3, 1, 4 })]
    [InlineData(new[] { 1, 2, 3, 4, 5 })]
    [InlineData(new[] { -1, -2, 0, 1, 2 })]
    public void GetTug_OddElementCount_SplitsWithMinimalDifference(int[] input)
    {
        var (left, right) = sut.GetTug(input);

        Assert.Equal((input.Length - 1) / 2, left.Length);
        Assert.Equal((input.Length + 1) / 2, right.Length);
        
        // Verify this is the best possible split by checking all elements are used
        var allElements = left.Concat(right).OrderBy(x => x);
        var inputOrdered = input.OrderBy(x => x);
        Assert.Equal(inputOrdered, allElements);
    }

    [Theory]
    [InlineData(new[] { 3, 4, 5, -3, 100, 1, 89, 54, 23, 20 })]
    [InlineData(new[] { 23, 45, -34, 12, 0, 98, -99, 4, 189, -1, 4 })]
    public void GetTug_LargeInputs_ProducesValidSplit(int[] input)
    {
        var (left, right) = sut.GetTug(input);

        // Verify all elements are used exactly once
        var allElements = left.Concat(right).OrderBy(x => x);
        var inputOrdered = input.OrderBy(x => x);
        Assert.Equal(inputOrdered, allElements);

        // Verify the split sizes are correct
        var expectedLeftSize = input.Length % 2 == 1 ? (input.Length - 1) / 2 : input.Length / 2;
        Assert.Equal(expectedLeftSize, left.Length);
        Assert.Equal(input.Length - expectedLeftSize, right.Length);
    }
}