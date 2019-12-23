﻿using AlgorithmsAndDataStructures.DataStructures.SegmentTree;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.DataStructures.SegmentTree
{
    public class SumSegmentTreeTests
    {
        [Fact]
        public void CanConstructSegmentTreeFromArray()
        {
            var sut = new SumSegmentTree(new int[] { 1, 3, 5, 7, 9, 11 });
        }

        [Fact]
        public void CanGetSum() 
        {
            var sut = new SumSegmentTree(new int[] { 1, 3, 5, 7, 9, 11 });

            Assert.Equal(15, sut.GetSegmentValue(1,3));
        }
    }
}