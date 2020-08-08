using System;
using Xunit;
using System.Linq;
using AlgorithmsAndDataStructures.DataStructures.BinaryHeaps;

namespace AlgorithmsAndDataStructures.Tests.DataStructures.BinaryHeap
{
    public class MaxBinaryHeapTests
    {
        [Fact]
        public void TopElementIsInsertedWhenHeapIsEmpty()
        {
            var sut = new MaxBinaryHeap<int>();
            sut.Insert(10);
            Assert.Equal(10, sut.GetTop());
        }

        [Fact]
        public void MaxValueElementIsOnTheTop()
        {
            var sut = new MaxBinaryHeap<int>();
            sut.Insert(10);
            sut.Insert(20);

            Assert.Equal(20, sut.GetTop());
            Assert.Equal(10, sut.GetTop());
        }

        // TODO: Replace with property based testing.

        [Fact]
        public void MaxValueElementIsAlwaysOnTheTop()
        {
            var sut = new MaxBinaryHeap<int>(1001);
            var randomValues = new int[1000];
            var random = new Random();

            for (var i = 0; i < 1000; i++)
            {
                randomValues[i] = random.Next(10000);
                sut.Insert(randomValues[i]);
            }

            var orderedArray = randomValues.OrderByDescending(arg => arg).ToArray();

            for (var i = 0; i < 1000; i++)
            {
                Assert.Equal(orderedArray[i], sut.GetTop());
            }
        }
    }
}
