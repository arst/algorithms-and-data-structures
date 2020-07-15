using System;

namespace AlgorithmsAndDataStructures.Algorithms.Search
{
    public class Fibonacci<T> : ISearchAlgorithm<T> where T : IComparable<T>
    {
        public int Search(T[] target, T value)
        {
            var startingFibonacciNumber = 0;
            var offset = -1;

            while (FibonacciNumber(startingFibonacciNumber) < target.Length)
            {
                startingFibonacciNumber += 1;
            }

            while (FibonacciNumber(startingFibonacciNumber) > 1)
            {
                // Fibonacci number - 2 is ~ 1/3 of Fibonacci number
                var splitIndex = Math.Min(offset + FibonacciNumber(startingFibonacciNumber - 2), target.Length - 1);

                if (target[splitIndex].CompareTo(value) < 0)
                {
                    // Fibonacci number - 1 is ~ 2/3 of Fibonacci number
                    startingFibonacciNumber -= 1;
                    offset = splitIndex;
                }
                else if (target[splitIndex].CompareTo(value) > 0)
                {
                    // Fibonacci number - 2 is ~ 1/3 of Fibonacci number
                    startingFibonacciNumber -= 2;
                }
                else
                {
                    return splitIndex;
                }
            }

            // FibonacciNumber(startingFibonacciNumber) > 0 - check that array is not empty
            if (FibonacciNumber(startingFibonacciNumber) > 0 && target[offset + 1].CompareTo(value) == 0)
            {
                return offset + 1;
            }
            
            return -1;
        }
        // It's not the best idea to generate it on the fly,
        // it's better to either pregenerate them or generate them alongside the main loop
        private static int FibonacciNumber(int number)
        {
            if (number < 1)
            {
                return 0;
            }

            if (number == 1)
            {
                return 1;
            }

            return FibonacciNumber(number - 1) + FibonacciNumber(number - 2);
        }
    }
}
