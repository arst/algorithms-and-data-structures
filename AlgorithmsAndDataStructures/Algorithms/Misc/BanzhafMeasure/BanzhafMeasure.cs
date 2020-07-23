using AlgorithmsAndDataStructures.Algorithms.Sampling;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.Algorithms.Misc.BanzhafMeasure
{
    public class BanzhafMeasure
    {
        public float Measure(string voterName, string[] otherVoters, int quota, Dictionary<string, int> voterWeights, int numberOfTries)
        {
            var currentSample = 0;
            var subsetSelector = new SimpleRandomSubsetGenerator();
            var numberOfCriticalCoalitions = 0;

            while (currentSample < numberOfTries)
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

                currentSample++;
            }

            return (float)numberOfCriticalCoalitions / currentSample;
        }
    }
}
