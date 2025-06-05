using System.Linq;
using AlgorithmsAndDataStructures.Algorithms.Sampling;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Sampling;

public class ReservoirSamplingTests
{
    [Fact]
    public void TakesFirstMSamples()
    {
        var sut = new ReservoirSampling();
        var sampleSource = new SampleSource(2);

        var sample = sut.GetReservoirSample(sampleSource, 2);

        Assert.True(sample.All(arg => arg > 0));
    }

    [Fact]
    public void TakesSamplesFromStream()
    {
        var sut = new ReservoirSampling();
        var sampleSource = new SampleSource(1000);

        var sample = sut.GetReservoirSample(sampleSource, 10);

        Assert.True(sample.All(arg => arg > 0));
    }
}