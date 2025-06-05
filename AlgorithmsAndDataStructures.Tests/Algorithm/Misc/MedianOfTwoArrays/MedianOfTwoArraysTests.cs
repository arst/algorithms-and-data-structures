﻿using AlgorithmsAndDataStructures.Algorithms.Misc.MedianOfTwoArrays;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Misc.MedianOfTwoArrays;

public abstract class MedianOfTwoArraysTests
{
    protected abstract IMediaOfTwoArraysAlgorithm GetSut();

    [Fact]
    public void NonEqualLength()
    {
        var sut = GetSut();

        Assert.Equal(1.5f, sut.GetMedian(new[] { 1, 3 }, new[] { 2 }));
    }

    [Fact]
    public void NonEqualLengthReversed()
    {
        var sut = GetSut();

        Assert.Equal(1.5f, sut.GetMedian(new[] { 1 }, new[] { 2, 3 }));
    }

    [Fact]
    public void TwoElements()
    {
        var sut = GetSut();

        Assert.Equal(1.5f, sut.GetMedian(new[] { 1 }, new[] { 2 }));
    }

    [Fact]
    public void RepeatedElements()
    {
        var sut = GetSut();

        Assert.Equal(4f, sut.GetMedian(new[] { 4, 4, 4 }, new[] { 4, 4, 4 }));
    }

    [Fact]
    public void RepeatedElementsNonEqualLength()
    {
        var sut = GetSut();

        Assert.Equal(4f, sut.GetMedian(new[] { 4, 4 }, new[] { 4, 4, 4 }));
    }

    [Fact]
    public void Baseline()
    {
        var sut = GetSut();

        Assert.Equal(3.5f, sut.GetMedian(new[] { 1, 3, 5 }, new[] { 2, 4, 6 }));
    }
}