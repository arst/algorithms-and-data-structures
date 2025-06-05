using System;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.MaximumFlow;

// Ford-Fulkerson is actually an approach and not the while algorithm, it doesn't specify the exact way to traverse a residual graph.
// Since this implementation uses BFS, it's technically Edmonds-Karp algorithm with complexity of O(V*E^2)
public class FordFulkerson
{
    // Actually, flow network here is just a directed graph, though, it may as well be undirected.
#pragma warning disable CA1822 // Mark members as static
    public int MaxFlow(int[][] flowNetwork)
#pragma warning restore CA1822 // Mark members as static
    {
        if (flowNetwork is null) return default;

        var residualGraph = new int[flowNetwork.GetLength(0)][];
        var flow = 0;
        for (var i = 0; i < residualGraph.Length; i++)
        {
            residualGraph[i] = new int[flowNetwork[i].Length];

            for (var j = 0; j < residualGraph[i].Length; j++) residualGraph[i][j] = flowNetwork[i][j];
        }

        bool hasPath;
        var sink = flowNetwork.Length - 1;
        const int source = 0;

        do
        {
            // Do simple BFS and record the path from source to sink if such path exists.
            var path = GetPath(residualGraph, source, sink);
            hasPath = path != null;

            if (hasPath)
            {
                // Get minimum available capacity in the augmenting path.
                var delta = GetDelta(residualGraph, path, sink);
                // Augment max flow with value of delta since we were able to find augmenting path. 
                flow += delta;

                // Follow the path until we rich the source.
                var currentVertex = sink;
                var parent = path[currentVertex];

                while (parent >= 0)
                {
                    // Reduce capacity of the nodes along the path with delta.
                    residualGraph[parent][currentVertex] = residualGraph[parent][currentVertex] - delta;
                    // Create back-node to allow flow undo.
                    residualGraph[currentVertex][parent] = residualGraph[currentVertex][parent] + delta;

                    currentVertex = parent;
                    parent = path[currentVertex];
                }
            }
        } while (hasPath);

        return flow;
    }

    private static int GetDelta(IReadOnlyList<int[]> residualGraph, IReadOnlyList<int> path, int targetVertex)
    {
        var delta = int.MaxValue;
        var currentVertex = targetVertex;
        var parent = path[currentVertex];

        while (parent >= 0)
        {
            delta = Math.Min(residualGraph[parent][currentVertex], delta);
            currentVertex = parent;
            parent = path[currentVertex];
        }

        return delta;
    }

    // Since BFS is used, we get the shortest path here.
    private static int[] GetPath(IReadOnlyList<int[]> residualGraph, int currentVertex, int targetVertex)
    {
        var path = new int[residualGraph.Count];
        var queue = new Queue<int>();
        var visited = new bool[residualGraph.Count];
        path[currentVertex] = -1;
        visited[currentVertex] = true;
        queue.Enqueue(currentVertex);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();

            for (var i = 0; i < residualGraph[current].Length; i++)
            {
                var adjacentVertexCapacity = residualGraph[current][i];

                if (adjacentVertexCapacity > 0 && !visited[i])
                {
                    path[i] = current;
                    visited[i] = true;

                    if (i == targetVertex)
                        return path;

                    queue.Enqueue(i);
                }
            }
        }

        return null;
    }
}