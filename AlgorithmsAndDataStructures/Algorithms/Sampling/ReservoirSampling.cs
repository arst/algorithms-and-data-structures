using System;

namespace AlgorithmsAndDataStructures.Algorithms.Sampling
{
    public class ReservoirSampling
    {
#pragma warning disable CA1822 // Mark members as static
        public int[] GetReservoirSample(SampleSource population, int sampleSize)
#pragma warning restore CA1822 // Mark members as static
        {
            if (population is null)
            {
                return Array.Empty<int>();
            }

            var reservoir = new int[sampleSize];
            var random = new Random();

            // We populate all samples from population to result right-away because we don't know whether we get sampleSize + 1 at any time at all.
            for (var i = 0; i < sampleSize; i++)
            {
                reservoir[i] = population.GetNext();
            }

            var currentPopulationSize = sampleSize;
            var nextSample = population.GetNext();

            while (nextSample > 0)
            {
                currentPopulationSize++;
                var probabilityToPickNextSample = random.Next(1, currentPopulationSize);

                if (probabilityToPickNextSample <= sampleSize)
                {
                    reservoir[probabilityToPickNextSample - 1] = nextSample;
                }

                nextSample = population.GetNext();
            }

            return reservoir;
        }
    }
}
