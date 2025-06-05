using AlgorithmsAndDataStructures.Algorithms.PseudorandomNumberGenerators;
using BenchmarkDotNet.Attributes;

namespace AlgorithmsAndDataStructures.Benchmarks.Algorithms.PseudorandomNumberGenerators;

[HtmlExporter]
[RPlotExporter]
[CsvMeasurementsExporter]
[MarkdownExporterAttribute.GitHub]
public class PseudorandomNumberGeneratorsBenchmark
{
    private readonly LinearCongruentialRandomNumberGenerator linearCongruentialRandomNumberGenerator;
    private readonly XorShift1024Star xOrShift1024Star;
    private readonly XorShift64Star xOrShift64Star;

    public PseudorandomNumberGeneratorsBenchmark()
    {
        linearCongruentialRandomNumberGenerator = new LinearCongruentialRandomNumberGenerator();
        xOrShift64Star = new XorShift64Star();
        xOrShift1024Star = new XorShift1024Star();
    }

    [Benchmark(Baseline = true)]
    public long LinearCongruentialRandomNumberGenerator()
    {
        return linearCongruentialRandomNumberGenerator.Generate();
    }

    [Benchmark]
    public long XorShift64Star()
    {
        return xOrShift64Star.Generate();
    }

    [Benchmark]
    public long XorShift1024Star()
    {
        return xOrShift1024Star.Generate();
    }
}