using AlgorithmsAndDataStructures.Algorithms.Search;
using System;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Search
{
    public abstract class BaseSearchAlgorithmTests
    {
        [Fact]
        public void AlgorithmCantFindElementInZeroElementArray()
        {
            var sut = GetSystemUnderTest();
            Assert.Equal(-1, sut.Search(target: Array.Empty<int>(), 1));
        }

        [Fact]
        public void AlgorithmCanFindElementInOneElementArray()
        {
            var sut = GetSystemUnderTest();
            Assert.Equal(0, sut.Search(new int[] { 1 }, 1));
        }

        [Fact]
        public void BaseSearching()
        {
            var sut = GetSystemUnderTest();
            Assert.Equal(3, sut.Search(new int[] { 6, 5, 3, 1, 8, 7, 2, 4 }, 1));
        }

        public abstract ISearchAlgorithm<int> GetSystemUnderTest();
    }
}
