using System.Collections.Generic;
using AlgorithmsAndDataStructures.DataStructures.Graph;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.Misc;

public static class CycleDetector
{
    // Time Complexity O(V+E)
    public static bool IsCyclic(GraphVertex<int>[] graph)
    {
        if (graph is null) return default;

        // We need to iterate over all vertices for disconnected graphs.
        for (var i = 0; i < graph.Length; i++)
        {
            var visited = new bool[graph.Length];
            visited[i] = true;

            if (IsCyclic(graph, i, visited)) return true;
        }

        return false;
    }

    private static bool IsCyclic(IReadOnlyList<GraphVertex<int>> graph, int node, IList<bool> visited)
    {
        var adjacentVertexes = graph[node].AdjacentVertices;

        foreach (var vertex in adjacentVertexes)
        {
            if (visited[vertex]) return true;

            visited[vertex] = true;
            return IsCyclic(graph, vertex, visited);
        }

        visited[node] = false;

        return false;
    }
}