using System;
using System.Collections.Generic;
using AlgorithmsAndDataStructures.Algorithms.Graph.MinimumSpanningTree.BoruvkasAlgorithm;
using BenchmarkDotNet.Attributes;

namespace AlgorithmsAndDataStructures.Benchmarks.Algorithms.Graph.MinimumSpanningTree;

public class BoruvkasAlgorithmBenchmark
{
    private readonly int verticesCount = 10000000;
    private List<Edge> edges;

    [GlobalSetup]
    public void Setup()
    {
        // Initialize a graph with 1000 edges and some number of vertices
        edges = new List<Edge>();
        var random = new Random(0); // Use a fixed seed for reproducibility

        for (var i = 0; i < verticesCount - 1; i++)
            // Create a connected graph (tree structure)
            edges.Add(new Edge { Source = i, Destination = i + 1, Weight = random.Next(1, 10000000) });

        // Add extra edges to make up to 1000 edges, ensuring no duplicate edges
        while (edges.Count < 10000000)
        {
            var source = random.Next(verticesCount);
            var destination = random.Next(verticesCount);
            if (source != destination && !edges.Exists(e =>
                    (e.Source == source && e.Destination == destination) ||
                    (e.Source == destination && e.Destination == source)))
                edges.Add(new Edge { Source = source, Destination = destination, Weight = random.Next(1, 10000000) });
        }
    }

    [Benchmark]
    public void SimpleBoruvka()
    {
        var algorithm = new BoruvkasAlgorithm();
        algorithm.GetMinimumSpanningTreeWeight(verticesCount, edges);
    }

    [Benchmark]
    public void ParallelBoruvka()
    {
        var algorithm = new BoruvkasAlgorithm();
        algorithm.GetMinimumSpanningTreeWeightParallel(verticesCount, edges);
    }
}