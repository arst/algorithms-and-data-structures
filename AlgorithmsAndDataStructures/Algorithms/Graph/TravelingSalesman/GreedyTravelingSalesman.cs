using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.TravelingSalesman;

public class GreedyTravelingSalesman
{
#pragma warning disable CA1822 // Mark members as static
    public int GetPath(int[][] graph)
#pragma warning restore CA1822 // Mark members as static
    {
        if (graph is null) return default;

        var visited = new bool[graph.Length];

        return Travel(graph, 0, visited, 0, 0);
    }

    private static int Travel(IReadOnlyList<int[]> graph, int currentVertex, bool[] visited, int startingVertex,
        int path)
    {
        visited[currentVertex] = true;

        if (graph[currentVertex][startingVertex] > 0 && visited.All(arg => arg))
            return path + graph[currentVertex][startingVertex];

        var minEdge = GetMinEdge(graph, currentVertex, visited);

        path += graph[currentVertex][minEdge];

        return Travel(graph, minEdge, visited, startingVertex, path);
    }

    private static int GetMinEdge(IReadOnlyList<int[]> graph, int currentVertex, IReadOnlyList<bool> visited)
    {
        var minIndex = -1;
        var minValue = int.MaxValue;

        for (var i = 0; i < graph.Count; i++)
            if (graph[currentVertex][i] > 0 && minValue > graph[currentVertex][i] && !visited[i])
            {
                minValue = graph[currentVertex][i];
                minIndex = i;
            }

        return minIndex;
    }
}