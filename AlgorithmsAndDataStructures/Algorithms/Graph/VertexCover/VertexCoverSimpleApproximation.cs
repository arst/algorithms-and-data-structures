using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.VertexCover;

public class VertexCoverSimpleApproximation
{
#pragma warning disable CA1822 // Mark members as static
    public List<int> GetVertexCover(int[][] graph)
#pragma warning restore CA1822 // Mark members as static
    {
        if (graph is null) return new List<int>(0);

        var visited = new bool[graph.Length];

        for (var i = 0; i < graph.Length; i++)
        {
            if (visited[i]) continue;

            for (var j = 0; j < graph.Length; j++)
            {
                if (graph[i][j] == 0) continue;

                if (!visited[j] && i != j)
                {
                    visited[j] = true;
                    visited[i] = true;
                    break;
                }
            }
        }

        var result = new List<int>();

        for (var i = 0; i < visited.Length; i++)
            if (visited[i])
                result.Add(i);

        return result;
    }

#pragma warning disable CA1822 // Mark members as static
    public List<int> GetVertexCoverOptimized(int[][] graph)
#pragma warning restore CA1822 // Mark members as static
    {
        if (graph is null) return new List<int>(0);

        var visited = new int[graph.Length];

        for (var i = 0; i < graph.Length; i++)
        {
            var vertexWithMaxDegree = -1;

            for (var v = 0; v < graph.Length; v++)
                if (visited[v] == 0 && (vertexWithMaxDegree == -1 || graph[vertexWithMaxDegree].Sum() < graph[v].Sum()))
                    vertexWithMaxDegree = v;

            if (vertexWithMaxDegree < 0) break;

            for (var j = 0; j < graph.Length; j++)
            {
                if (graph[vertexWithMaxDegree][j] == 0) continue;

                if (visited[j] == 0 && vertexWithMaxDegree != j)
                {
                    visited[j] = 1;
                    visited[vertexWithMaxDegree] = 2;
                    break;
                }
            }
        }

        var result = new List<int>();

        for (var i = 0; i < visited.Length; i++)
            if (visited[i] == 2)
                result.Add(i);

        return result;
    }
}