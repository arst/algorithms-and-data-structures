﻿using AlgorithmsAndDataStructures.Algorithms.Backtracking;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Backtracking;

public class TugOfWarBestMatchTests
{
    [Fact]
    public void TwoElementsSetHasTug()
    {
        var sut = new TugOfWarBestMatch();
        var set = new[] { 2, 2 };
        var (left, right) = sut.GetTug(set);

        Assert.Collection(left, arg => Assert.Equal(2, arg));
        Assert.Collection(right, arg => Assert.Equal(2, arg));
    }

    [Fact]
    public void FourElementsSetHasTug()
    {
        var sut = new TugOfWarBestMatch();
        var set = new[] { 1, 2, 3, 4 };
        var (left, right) = sut.GetTug(set);
#pragma warning disable HAA0101 // Array allocation for params parameter
        Assert.Collection(left, arg => Assert.Equal(1, arg), arg => Assert.Equal(4, arg));
        Assert.Collection(right, arg => Assert.Equal(2, arg), arg => Assert.Equal(3, arg));
#pragma warning restore HAA0101 // Array allocation for params parameter
    }

    [Fact]
    public void OddElementsSetHasTug()
    {
        var sut = new TugOfWarBestMatch();
        var set = new[] { 2, 2, 3, 1, 4 };
        var (left, right) = sut.GetTug(set);
#pragma warning disable HAA0101 // Array allocation for params parameter
        Assert.Collection(left, arg => Assert.Equal(2, arg), arg => Assert.Equal(4, arg));
        Assert.Collection(right, arg => Assert.Equal(2, arg), arg => Assert.Equal(3, arg), arg => Assert.Equal(1, arg));
#pragma warning restore HAA0101 // Array allocation for params parameter
    }

    [Fact]
    public void BaseLineEven()
    {
        var sut = new TugOfWarBestMatch();
        var set = new[] { 3, 4, 5, -3, 100, 1, 89, 54, 23, 20 };
        var (left, right) = sut.GetTug(set);
#pragma warning disable HAA0101 // Array allocation for params parameter
        Assert.Collection(left, arg => Assert.Equal(4, arg), arg => Assert.Equal(100, arg), arg => Assert.Equal(1, arg),
            arg => Assert.Equal(23, arg), arg => Assert.Equal(20, arg));
        Assert.Collection(right, arg => Assert.Equal(3, arg), arg => Assert.Equal(5, arg), arg => Assert.Equal(-3, arg),
            arg => Assert.Equal(89, arg), arg => Assert.Equal(54, arg));
#pragma warning restore HAA0101 // Array allocation for params parameter
    }

    [Fact]
    public void BaseLineOdd()
    {
        var sut = new TugOfWarBestMatch();
        var set = new[] { 23, 45, -34, 12, 0, 98, -99, 4, 189, -1, 4 };
        var (left, right) = sut.GetTug(set);
#pragma warning disable HAA0101 // Array allocation for params parameter
        Assert.Collection(left, arg => Assert.Equal(23, arg), arg => Assert.Equal(-99, arg),
            arg => Assert.Equal(4, arg), arg => Assert.Equal(189, arg), arg => Assert.Equal(4, arg));
        Assert.Collection(right, arg => Assert.Equal(45, arg), arg => Assert.Equal(-34, arg),
            arg => Assert.Equal(12, arg), arg => Assert.Equal(0, arg), arg => Assert.Equal(98, arg),
            arg => Assert.Equal(-1, arg));
#pragma warning restore HAA0101 // Array allocation for params parameter
    }
}