﻿using System;
using System.Linq;
using AlgorithmsAndDataStructures.Algorithms.Search;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Search;

public class QuickSelectTests
{
    [Fact]
    public void FindSmallestElementInSingleElementArray()
    {
        var sut = new QuickSelect();
        var input = new[] { 1 };
        Assert.Equal(1, sut.GetLargestElement(input, 0));
    }

    [Fact]
    public void SortedArray()
    {
        var sut = new QuickSelect();
        var input = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        Assert.Equal(8, sut.GetLargestElement(input, 7));
    }

    [Fact]
    public void UnsortedArray()
    {
        var sut = new QuickSelect();
        var input = new[] { 3, 1, 7, 10, 2, 5, 9, 4, 8, 9, 6 };
        Assert.Equal(8, sut.GetLargestElement(input, 7));
    }

    [Fact]
    public void UnsortedArrayUnevenLength()
    {
        var sut = new QuickSelect();
        var input = new[] { 3, 1, 7, 10, 2, 5, 9, 4, 8, 6 };
        Assert.Equal(8, sut.GetLargestElement(input, 7));
    }


    [Fact]
    public void Fuzzy()
    {
        var sut = new QuickSelect();
        var random = new Random();
        const int inputLength = 1000;
        var input = new int[inputLength];

        for (var i = 0; i < inputLength; i++) input[i] = random.Next(inputLength * 10);

        var sorted = input.OrderBy(arg => arg).ToArray();

        for (var i = 0; i < inputLength; i++) Assert.Equal(sorted[i], sut.GetLargestElement(input, i));
    }
}