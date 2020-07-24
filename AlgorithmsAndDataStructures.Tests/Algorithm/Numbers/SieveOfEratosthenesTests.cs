using AlgorithmsAndDataStructures.Algorithms.Numbers;
using System.Linq;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Numbers
{
    public class SieveOfEratosthenesTests
    {
        [Fact]
        public void Base()
        {
            var sut = new SieveOfEratosthenes();
            const int input = 31;
            var primesUpTo31 = new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31 };

            var result = sut.IsPrime(input);

            for (int i = 0; i < result.Length; i++)
            {
                if (primesUpTo31.Contains(i))
                {
                    Assert.True(result[i]);
                }
            }
        }
    }
}
