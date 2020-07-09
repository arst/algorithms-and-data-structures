using AlgorithmsAndDataStructures.Benchmarks.Algorithms;
using BenchmarkDotNet.Running;
using System;
using System.Linq;

namespace AlgorithmsAndDataStructures.Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<SearchBenchmark>();
        }
    }
}
