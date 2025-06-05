using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.TravelingSalesman;

public class NaiveTravelingSalesman
{
#pragma warning disable CA1822 // Mark members as static
    public int GetPath(int[][] graph)
#pragma warning restore CA1822 // Mark members as static
    {
        if (graph is null) return default;

        var visited = new bool[graph.Length];
        visited[0] = true;
        return TravelingSalesman(graph, 0, visited, 0, int.MaxValue);
    }

    private static int TravelingSalesman(IReadOnlyList<int[]> graph, int currentVertex, IList<bool> visited,
        int currentPathWeight, int minPathWeight)
    {
        if (visited.All(arg => arg) && graph[currentVertex][0] > 0)
            return Math.Min(currentPathWeight + graph[currentVertex][0], minPathWeight);

        for (var i = 0; i < graph.Count; i++)
        {
            if (graph[currentVertex][i] < 1 || visited[i]) continue;

            visited[i] = true;
            minPathWeight = TravelingSalesman(graph, i, visited, currentPathWeight + graph[currentVertex][i],
                minPathWeight);
            visited[i] = false;
        }


        return minPathWeight;
    }
}