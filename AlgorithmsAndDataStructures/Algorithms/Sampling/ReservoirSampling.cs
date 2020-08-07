using System;

namespace AlgorithmsAndDataStructures.Algorithms.Sampling
{
    public class ReservoirSampling
    {
        public int[] GetRandomSample(SampleSource population, int sampleSize)
        {
            var result = new int[sampleSize];
            var random = new Random();

            // We populate all samples from population to result rightaway because we don't know whether we get sampleSize + 1 at any time at all.
            for (var i = 0; i < sampleSize; i++)
            {
                result[i] = population.GetNext();
            }

            var currentPopulationSize = sampleSize;
            var nextSample = population.GetNext();

            while (nextSample > 0)
            {
                currentPopulationSize++;
                var probabilityToPickNextSample = random.Next(1, currentPopulationSize);

                if (probabilityToPickNextSample <= sampleSize)
                {
                    result[probabilityToPickNextSample - 1] = nextSample;
                }

                nextSample = population.GetNext();
            }

            return result;
        }
    }
}
