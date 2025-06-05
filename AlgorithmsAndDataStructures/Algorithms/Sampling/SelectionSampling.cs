using System;

namespace AlgorithmsAndDataStructures.Algorithms.Sampling;

public class SelectionSampling
{
#pragma warning disable CA1822 // Mark members as static
    public T[] GetRandomSample<T>(T[] population, int sampleSize)
#pragma warning restore CA1822 // Mark members as static
    {
        if (population is null) return Array.Empty<T>();

        if (population.Length < sampleSize)
            throw new ArgumentException($"{nameof(sampleSize)} must be smaller then population size.");

        var result = new T[sampleSize];

        var selectedCounter = 0;
        var populationPointer = 0;
        var random = new Random();

        while (selectedCounter < sampleSize)
        {
            var randomNumber = random.NextDouble();

            if (randomNumber * (population.Length - populationPointer) < sampleSize - selectedCounter)
            {
                result[selectedCounter] = population[populationPointer];
                selectedCounter++;
            }

            populationPointer++;
        }

        return result;
    }
}