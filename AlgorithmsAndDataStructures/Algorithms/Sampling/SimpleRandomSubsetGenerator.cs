using System;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.Algorithms.Sampling
{
    public class SimpleRandomSubsetGenerator
    {
        public List<T> GetRandomSubset<T>(T[] set)
        {
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
