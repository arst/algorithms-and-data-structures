﻿using System;
using System.Linq;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.DataStructures.BinaryIndexedTree;

public class BinaryIndexedTreeTests
{
    [Fact]
    public void CanConstructFromArray()
    {
        var sut = AlgorithmsAndDataStructures.DataStructures.BinaryIndexedTrees.BinaryIndexedTree.FromArray(new[]
            { 1, 2, 3, 4, 5 });
        Assert.Equal(15, sut.GetSum(4));
    }

    [Fact]
    public void CanUpdateValue()
    {
        var sut = AlgorithmsAndDataStructures.DataStructures.BinaryIndexedTrees.BinaryIndexedTree.FromArray(new[]
            { 1, 2, 3, 4, 5 });
        Assert.Equal(15, sut.GetSum(4));
        sut.SetValue(2, 2);
        Assert.Equal(17, sut.GetSum(4));
    }

    [Fact]
    public void CanQueryRangeValue()
    {
        var sut = AlgorithmsAndDataStructures.DataStructures.BinaryIndexedTrees.BinaryIndexedTree.FromArray(new[]
            { 1, 2, 3, 4, 5 });
        Assert.Equal(3, sut.GetSum(0, 1));
        Assert.Equal(6, sut.GetSum(0, 2));
        Assert.Equal(10, sut.GetSum(0, 3));
        Assert.Equal(15, sut.GetSum(0, 4));
        Assert.Equal(12, sut.GetSum(2, 4));
    }

    [Fact]
    public void RangeSumIsCorrect()
    {
        var sut = new AlgorithmsAndDataStructures.DataStructures.BinaryIndexedTrees.BinaryIndexedTree();
        var random = new Random();
        var data = new int[99];

        for (var i = 0; i < 99; i++)
        {
            var number = random.Next(200);
            data[i] = number;
            sut.SetValue(i, number);
        }

        for (var i = 0; i < 100; i++)
        {
            var range = random.Next(0, 98);
            var expectedSum = data.Take(range + 1).Sum();
            Assert.Equal(expectedSum, sut.GetSum(range));
        }
    }
}