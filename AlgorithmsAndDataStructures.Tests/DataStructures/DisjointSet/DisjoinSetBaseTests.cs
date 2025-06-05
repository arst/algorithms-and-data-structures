using System;
using System.Collections.Generic;
using AlgorithmsAndDataStructures.DataStructures.DisjointSet;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.DataStructures.DisjointSet;

public abstract class DisjoinSetBaseTests
{
    protected abstract IDisjointSet GetSut(int size);

    [Fact]
    public void SetsAreInitialySingletoneSets()
    {
        var sut = GetSut(2);
        Assert.False(sut.Connected(0, 1));
    }

    [Fact]
    public void CanJoinTwoSingeltoneSets()
    {
        var sut = GetSut(2);
        sut.Union(0, 1);
        Assert.True(sut.Connected(0, 1));
    }

    [Fact]
    public void TwoNonSingeltoneSetsAreDisjoint()
    {
        var sut = GetSut(4);
        sut.Union(0, 1);
        sut.Union(2, 3);
        Assert.False(sut.Connected(0, 2));
    }

    [Fact]
    public void CanJoinTwoNonSingeltoneSets()
    {
        var sut = GetSut(4);
        sut.Union(0, 1);
        sut.Union(2, 3);
        sut.Union(1, 2);
        Assert.True(sut.Connected(0, 3));
    }

    [Fact]
    public void Fuzzy()
    {
        var size = 1000;
        var sut = GetSut(size);
        var r = new Random();
        var leftSet = new List<int>();
        var rightSet = new List<int>();

        while (rightSet.Count < size / 2 && leftSet.Count < size / 2)
        {
            var left = r.Next(size);
            var right = r.Next(size);
            if (left != right)
            {
                leftSet.Add(left);
                rightSet.Add(right);
            }
        }

        for (var i = 0; i < size / 2; i++)
        {
            var leftCurrent = leftSet[i];
            var rightCurrent = rightSet[i];

            for (var j = 0; j < size / 2; j++)
            {
                sut.Union(leftCurrent, leftSet[j]);
                sut.Union(rightCurrent, rightSet[j]);
            }
        }

        sut.Union(leftSet[0], rightSet[0]);


        for (var i = 0; i < size / 2; i++)
        {
            var leftCurrent = leftSet[i];
            var rightCurrent = rightSet[i];

            Assert.True(sut.Connected(leftCurrent, rightCurrent));
        }
    }
}