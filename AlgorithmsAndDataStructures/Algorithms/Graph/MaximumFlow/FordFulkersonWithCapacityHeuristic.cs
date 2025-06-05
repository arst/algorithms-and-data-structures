using System;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.MaximumFlow;

public class FordFulkersonWithCapacityHeuristic
{
    // Actually, flow network here is just a directed graph, though, it may as well be undirected.
#pragma warning disable CA1822 // Mark members as static
    public int MaxFlow(int[][] flowNetwork)
#pragma warning restore CA1822 // Mark members as static
    {
        if (flowNetwork is null) return default;
        var residualGraph = new int[flowNetwork.GetLength(0)][];
        var flow = 0;
        var maxEdgeWeight = int.MinValue;

        for (var i = 0; i < residualGraph.Length; i++)
        {
            residualGraph[i] = new int[flowNetwork[i].Length];

            for (var j = 0; j < residualGraph[i].Length; j++)
            {
                residualGraph[i][j] = flowNetwork[i][j];

                if (flowNetwork[i][j] > maxEdgeWeight) maxEdgeWeight = flowNetwork[i][j];
            }
        }

        var minConsiderableCapacity = 1;

        while (minConsiderableCapacity * 2 < maxEdgeWeight) minConsiderableCapacity *= 2;

        while (minConsiderableCapacity > 0)
        {
            bool hasPath;
            var sink = flowNetwork.Length - 1;
            const int source = 0;

            do
            {
                var path = new int[residualGraph.Length];
                var visited = new bool[residualGraph.Length];
                path[source] = -1;
                visited[source] = true;
                // Do simple DFS and record the path from source to sink if such path exists.
                path = GetPath(residualGraph, source, sink, path, visited, minConsiderableCapacity);
                hasPath = path != null;

                if (hasPath)
                {
                    // Get minimum available capacity in the augmenting path.
                    var capacity = GetDelta(residualGraph, path, sink);
                    // Augment max flow with value of delta since we were able to find augmenting path. 
                    flow += capacity;

                    // Follow the path until we rich the source.
                    var currentVertex = sink;
                    var parent = path[currentVertex];

                    while (parent >= 0)
                    {
                        // Reduce capacity of the vertices along the path with delta.
                        residualGraph[parent][currentVertex] = residualGraph[parent][currentVertex] - capacity;
                        // Create back-vertex to allow flow undo.
                        residualGraph[currentVertex][parent] = residualGraph[currentVertex][parent] + capacity;

                        currentVertex = parent;
                        parent = path[currentVertex];
                    }
                }
            } while (hasPath);

            minConsiderableCapacity /= 2;
        }

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

    private static int[] GetPath(IReadOnlyList<int[]> residualGraph, int currentVertex, int targetVertex, int[] path,
        IList<bool> visited, int delta)
    {
        for (var i = 0; i < residualGraph[currentVertex].Length; i++)
        {
            var adjacentVertexCapacity = residualGraph[currentVertex][i];

            if (adjacentVertexCapacity > 0 && !visited[i] && adjacentVertexCapacity >= delta)
            {
                path[i] = currentVertex;
                visited[i] = true;

                if (i == targetVertex)
                    return path;

                var tempPath = GetPath(residualGraph, i, targetVertex, path, visited, delta);

                if (tempPath != null) return tempPath;
            }
        }

        return null;
    }
}