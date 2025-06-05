using System;
using AlgorithmsAndDataStructures.Algorithms.Sorting;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Sorting;

public abstract class BaseSortingTests
{
    protected virtual int MaxValue { get; } = int.MaxValue;

    [Fact]
    public void EmptyArrayIsSorted()
    {
        var sut = GetSystemUnderTest();
        var input = Array.Empty<int>();
        sut.Sort(input);
        AssertIsSorted(input);
    }

    [Fact]
    public void OneElementArrayIsSorted()
    {
        var sut = GetSystemUnderTest();
        var target = new[] { 1 };
        sut.Sort(target);
        AssertIsSorted(target);
    }

    [Fact]
    public void BaseSortingWorks()
    {
        var sut = GetSystemUnderTest();
        var target = new[] { 6, 5, 3, 1, 8, 7, 2, 4 };
        sut.Sort(target);

        AssertIsSorted(target);
    }

    [Fact]
    public void Fuzzy()
    {
        var sut = GetSystemUnderTest();
        var r = new Random();
        var target = new int[1000];
        var test = new int[target.Length];

        for (var i = 0; i < 1000; i++)
        {
            for (var j = 0; j < target.Length; j++) target[j] = r.Next(MaxValue);
            Array.Copy(target, 0, test, 0, target.Length);
            sut.Sort(target);

            AssertIsSorted(target);
        }
    }

    public static void AssertIsSorted(int[] input)
    {
        if (input is null) return;

        for (var i = 1; i < input.Length; i++) Assert.True(input[i] >= input[i - 1]);
    }

    protected abstract ISortingAlgorithm GetSystemUnderTest();
}