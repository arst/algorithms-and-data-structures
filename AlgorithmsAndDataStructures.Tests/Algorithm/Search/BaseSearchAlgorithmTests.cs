using AlgorithmsAndDataStructures.Algorithms.Search;
using System;
using System.Linq;
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
            var testData = new int[] { 6, 5, 3, 1, 8, 7, 2, 4 };
            Array.Sort(testData);
            Assert.Equal(2, sut.Search(testData, 3));
        }

        [Fact]
        public void PropertyBased()
        {
            var sut = GetSystemUnderTest();
            var r = new Random();
            var testData = new int[10000];
            var toSearchNegative = new int[100];
            var toSearchPositive = new Tuple<int, int>[100];

            var testDataCounter = 0;
            while (testDataCounter < testData.Length)
            {
                var randomValue = r.Next(1000000);
                if (!testData.Contains(randomValue))
                {
                    testData[testDataCounter] = randomValue;
                    testDataCounter++;
                }
            }

            Array.Sort(testData);
            var toSearchCounter = 0;

            while (toSearchCounter < 100)
            {
                var randomValue = r.Next(10000);

                if (!testData.Contains(randomValue))
                {
                    toSearchNegative[toSearchCounter] = randomValue;
                    toSearchCounter++;
                }
            }

            for (int i = 0; i < toSearchPositive.Length; i++)
            {
                toSearchPositive[i] = new Tuple<int, int>(i * 10, testData[i * 10]);
            }

            foreach (var item in toSearchNegative)
            {
                Assert.Equal(-1, sut.Search(testData, item));
            }

            foreach (var item in toSearchPositive)
            {
                Assert.Equal(item.Item1, sut.Search(testData, item.Item2));
            }

        }

        public abstract ISearchAlgorithm<int> GetSystemUnderTest();
    }
}
