using AlgorithmsAndDataStructures.Benchmarks.Algorithms.Compression;
using BenchmarkDotNet.Running;

namespace AlgorithmsAndDataStructures.Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            var _ = BenchmarkRunner.Run<CompressionBenchmark>();
        }
    }
}
