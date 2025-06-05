using System;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.MaximumFlow;

public class StCutFordFulkersonBased
{
#pragma warning disable CA1822 // Mark members as static
    public List<Tuple<int, int>> GetStCut(int[][] graph)
#pragma warning restore CA1822 // Mark members as static
    {
        if (graph is null) return new List<Tuple<int, int>>(0);

        var residualGraph = new int[graph.Length][];

        for (var i = 0; i < residualGraph.Length; i++)
        {
            residualGraph[i] = new int[graph.Length];

            for (var j = 0; j < graph.Length; j++) residualGraph[i][j] = graph[i][j];
        }

        bool hasPath;
        var targetVertex = graph.Length - 1;

        do
        {
            var path = GetBfsPath(residualGraph, targetVertex);
            hasPath = path != null;

            if (hasPath)
            {
                var delta = GetDelta(path, residualGraph, targetVertex);
                var currentVertex = graph.Length - 1;
                var parent = path[currentVertex];

                while (parent >= 0)
                {
                    residualGraph[parent][currentVertex] = residualGraph[parent][currentVertex] - delta;
                    residualGraph[currentVertex][parent] = residualGraph[currentVertex][parent] + delta;

                    currentVertex = parent;
                    parent = path[currentVertex];
                }
            }
        } while (hasPath);

        var visited = new bool[graph.Length];

        Dfs(0, residualGraph, visited);

        var result = new List<Tuple<int, int>>();

        for (var i = 0; i < graph.Length; i++)
        {
            var currentVertex = graph[i];

            for (var j = 0; j < graph.Length; j++)
                if (currentVertex[j] > 0 && visited[i] && !visited[j])
                    result.Add(new Tuple<int, int>(i, j));
        }

        return result;
    }

    private static void Dfs(int v, IReadOnlyList<int[]> residualGraph, IList<bool> visited)
    {
        visited[v] = true;

        for (var i = 0; i < residualGraph[v].Length; i++)
            if (!visited[i] && residualGraph[v][i] > 0)
                Dfs(i, residualGraph, visited);
    }

    private static int GetDelta(IReadOnlyList<int> path, IReadOnlyList<int[]> residualGraph, int targetVertex)
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

    private static int[] GetBfsPath(IReadOnlyList<int[]> residualGraph, int targetVertex)
    {
        var queue = new Queue<int>();
        var visited = new bool[residualGraph.Count];
        var path = new int[residualGraph.Count];
        visited[0] = true;
        path[0] = -1;
        queue.Enqueue(0);

        while (queue.Count > 0)
        {
            var currentVertex = queue.Dequeue();

            for (var i = 0; i < residualGraph[currentVertex].Length; i++)
                if (!visited[i] && residualGraph[currentVertex][i] > 0)
                {
                    path[i] = currentVertex;
                    visited[i] = true;

                    if (i == targetVertex) return path;

                    queue.Enqueue(i);
                }
        }

        return null;
    }
}