﻿using AlgorithmsAndDataStructures.Algorithms.DynamicProgramming;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.DynamincProgramming
{
    public class WineCellarProblemTests
    {
        [Fact]
        public void Baseline()
        {
            var sut = new WineCellarProblem();

            Assert.Equal(50, sut.GetMaxProfit(new int[] { 2, 3, 5, 1, 4 }));
        }
    }
}
