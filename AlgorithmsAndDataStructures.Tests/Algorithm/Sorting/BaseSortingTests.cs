﻿using AlgorithmsAndDataStructures.Algorithms.Sorting;
using System;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Sorting
{
    public abstract class BaseSortingTests
    {

        [Fact]
        public void EmptyArrayIsSorted()
        {
            var sut = GetSystemUnderTest();
            var input = System.Array.Empty<int>();
            sut.Sort(input);
            AssertIsSorted(input);
        }

        [Fact]
        public void OneElementArrayIsSorted()
        {
            var sut = GetSystemUnderTest();
            var target = new int[] { 1 };
            sut.Sort(target);
            AssertIsSorted(target);
        }

        [Fact]
        public void BaseSortingWorks()
        {
            var sut = GetSystemUnderTest();
            int[] target = new int[] { 6, 5, 3, 1, 8, 7, 2, 4 };
            sut.Sort(target);

            AssertIsSorted(target);
        }

        [Fact]
        public void PropertyBased()
        {
            var sut = GetSystemUnderTest();
            var r = new Random();
            var target = new int[10000000];
            
            for (int i = 0; i < target.Length; i++)
            {
                target[i] = r.Next();
            }

            sut.Sort(target);

            AssertIsSorted(target);
        }

        public void AssertIsSorted(int[] input)
        {
            for (int i = 1; i < input.Length; i++)
            {
                Assert.True(input[i] >= input[i - 1]);
            }
        }

        protected abstract ISortingAlgorithm GetSystemUnderTest();
    }
}
