using AlgorithmsAndDataStructures.Algorithms.PseudorandomNumberGenerators;
using BenchmarkDotNet.Attributes;

namespace AlgorithmsAndDataStructures.Benchmarks.Algorithms.PseudorandomNumberGenerators
{
    [HtmlExporter]
    [RPlotExporter]
    [CsvMeasurementsExporter]
    [MarkdownExporterAttribute.GitHub]
    public class PseudorandomNumberGeneratorsBenchmark
    {
        private readonly LinearCongruentialRandomNumberGenerator linearCongruentialRandomNumberGenerator;
        private readonly XorShift64Star xOrShift64Star;
        private readonly XorShift1024Star xOrShift1024Star;

        public PseudorandomNumberGeneratorsBenchmark()
        {
            linearCongruentialRandomNumberGenerator = new LinearCongruentialRandomNumberGenerator();
            xOrShift64Star = new XorShift64Star();
            xOrShift1024Star = new XorShift1024Star();
        }

        [Benchmark(Baseline = true)]
        public long LinearCongruentialRandomNumberGenerator() => linearCongruentialRandomNumberGenerator.Generate();

        [Benchmark]
        public long XorShift64Star() => xOrShift64Star.Generate();

        [Benchmark]
        public long XorShift1024Star() => xOrShift1024Star.Generate();
    }
}
