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
        private readonly XORShift64Star xORShift64Star;
        private readonly XORShift1024Star xORShift1024Star;

        public PseudorandomNumberGeneratorsBenchmark()
        {
            linearCongruentialRandomNumberGenerator = new LinearCongruentialRandomNumberGenerator();
            xORShift64Star = new XORShift64Star();
            xORShift1024Star = new XORShift1024Star();
        }

        [Benchmark(Baseline = true)]
        public long LinearCongruentialRandomNumberGenerator() => linearCongruentialRandomNumberGenerator.Generate();

        [Benchmark]
        public long XORShift64Star() => xORShift64Star.Generate();

        [Benchmark]
        public long XORShift1024Star() => xORShift1024Star.Generate();
    }
}
