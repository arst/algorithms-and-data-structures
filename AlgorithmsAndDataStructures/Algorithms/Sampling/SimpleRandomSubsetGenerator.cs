using System;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.Algorithms.Sampling
{
    public class SimpleRandomSubsetGenerator
    {
#pragma warning disable CA1822 // Mark members as static
        public List<T> GetRandomSubset<T>(T[] set)
#pragma warning restore CA1822 // Mark members as static
        {
            if (set is null)
            {
                return new List<T>(0);
            }

            var result = new List<T>();
            var random = new Random();

            foreach (var item in set)
            {
                if (random.NextDouble() < 0.5)
                {
                    result.Add(item);
                }
            }

            return result;
        }
    }
}
