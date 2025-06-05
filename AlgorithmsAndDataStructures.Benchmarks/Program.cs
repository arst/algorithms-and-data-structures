using AlgorithmsAndDataStructures.Benchmarks.Algorithms.Graph.MinimumSpanningTree;
using BenchmarkDotNet.Running;

namespace AlgorithmsAndDataStructures.Benchmarks;

internal class Program
{
    private static void Main(string[] args)
    {
        var _ = BenchmarkRunner.Run<BoruvkasAlgorithmBenchmark>();
    }
}