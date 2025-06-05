using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.MaximumFlow;

public class MaximumBiPartiteMatchingDfsBased
{
#pragma warning disable CA1822 // Mark members as static
    public int GetMaxMatching(int[][] graph)
#pragma warning restore CA1822 // Mark members as static
    {
        if (graph is null) return default;

        var result = 0;
        var assignment = new int[graph.Length];

        for (var i = 0; i < assignment.Length; i++) assignment[i] = -1;

        for (var i = 0; i < graph.Length; i++)
        {
            var visited = new bool[graph.Length];
            if (TryAssign(i, graph, visited, assignment)) result++;
        }

        return result;
    }

    private static bool TryAssign(int currentVertex, IReadOnlyList<int[]> graph, IList<bool> visited,
        IList<int> assignment)
    {
        for (var i = 0; i < graph.Count; i++)
            if (graph[currentVertex][i] > 0 && !visited[i])
            {
                visited[i] = true;
                if (assignment[i] < 0 || TryAssign(assignment[i], graph, visited, assignment))
                {
                    assignment[i] = currentVertex;
                    return true;
                }
            }

        return false;
    }
}