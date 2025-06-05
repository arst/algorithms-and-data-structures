using System;
using System.Linq;
using AlgorithmsAndDataStructures.Algorithms.Sampling;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Sampling;

public class SelectionSamplingTests
{
    [Fact]
    public void CanSelectSample()
    {
        var sut = new SelectionSampling();
        var population = new[] { 1, 2 };
        const int sampleSize = 1;
        var sample = sut.GetRandomSample(population, sampleSize);

        Assert.True(sample[0] != 0);
    }

    [Fact]
    public void ThrowsOnIncorrectParams()
    {
        var sut = new SelectionSampling();
        var population = new[] { 1, 2 };
        const int sampleSize = 3;
        Assert.Throws<ArgumentException>(() => sut.GetRandomSample(population, sampleSize));
    }

    [Fact]
    public void Fuzzy()
    {
        var sut = new SelectionSampling();
        var random = new Random();
        var population = new int[100];

        for (var i = 0; i < population.Length; i++) population[i] = random.Next(1, 10000);
        var sampleSize = random.Next(1, 100);

        var sample = sut.GetRandomSample(population, sampleSize);

        Assert.True(sample.All(arg => arg != 0));
    }
}