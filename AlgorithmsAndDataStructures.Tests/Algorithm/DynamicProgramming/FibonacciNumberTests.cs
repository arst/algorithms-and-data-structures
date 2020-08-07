using AlgorithmsAndDataStructures.Algorithms.DynamicProgramming;
using System;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.DynamicProgramming
{
    public class FibonacciNumberTests
    {
        [Fact]
        public void ZeroNumber()
        {
            var sut = new FibonacciNumber();

            Assert.Equal(0, sut.GetNumber(0));
        }

        [Fact]
        public void FirstNumber()
        {
            var sut = new FibonacciNumber();

            Assert.Equal(1, sut.GetNumber(1));
        }

        [Fact]
        public void SecondNumber()
        {
            var sut = new FibonacciNumber();

            Assert.Equal(1, sut.GetNumber(2));
        }

        [Fact]
        public void Baseline()
        {
            var sut = new FibonacciNumber();
            var numbers = new int[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765 };

            for (int i = 0; i < numbers.Length; i++)
            {
                Assert.Equal(numbers[i], sut.GetNumber(i));
            }
        }
    }
}
