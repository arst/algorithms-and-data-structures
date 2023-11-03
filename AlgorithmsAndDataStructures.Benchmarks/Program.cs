using AlgorithmsAndDataStructures.Benchmarks.Algorithms.Graph.MinimumSpanningTree;
using BenchmarkDotNet.Running;

namespace AlgorithmsAndDataStructures.Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            var _ = BenchmarkRunner.Run<BoruvkasAlgorithmBenchmark>();
        }
    }
}
