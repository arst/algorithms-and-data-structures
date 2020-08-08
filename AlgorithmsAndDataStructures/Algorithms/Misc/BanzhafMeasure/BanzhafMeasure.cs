using AlgorithmsAndDataStructures.Algorithms.Sampling;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.Algorithms.Misc.BanzhafMeasure
{
    public class BanzhafMeasure
    {
#pragma warning disable CA1822 // Mark members as static
        public float Measure(string voterName, string[] otherVoters, int quota, Dictionary<string, int> voterWeights, int numberOfTries)
#pragma warning restore CA1822 // Mark members as static
        {
            if (voterWeights is null)
            {
                return default;
            }

            var subsetSelector = new SimpleRandomSubsetGenerator();
            var numberOfCriticalCoalitions = 0;

            for (var i = 0; i < numberOfTries; i++)
            {
                var coalition = subsetSelector.GetRandomSubset(otherVoters);
                var votes = 0;

                foreach (var voter in coalition)
                {
                    votes += voterWeights[voter];
                }

                if (votes < quota && votes + voterWeights[voterName] >= quota)
                {
                    numberOfCriticalCoalitions += 1;
                }
            }

            return (float)numberOfCriticalCoalitions / numberOfTries;
        }
    }
}
