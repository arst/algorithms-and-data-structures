using System;
using AlgorithmsAndDataStructures.Algorithms.Graph.Common;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.ShortestPath
{
    /*
    Negative weighted edges allowed: YES
    Complexity: o(n^3)
    NOTE: Since it is o(n^3) it is mostly useful only for small graphs(up to 100 vertices)
    Application: Most famous - Transitive closure is a graph.
   */
    public class FloydWarshall
    {
#pragma warning disable CA1822 // Mark members as static
        public (int[][] disatnces, int[][] path) MinDistances(WeightedGraphVertex[] graph)
#pragma warning restore CA1822 // Mark members as static
        {
            if (graph is null)
            {
                return (Array.Empty<int[]>(), Array.Empty<int[]>());
            }

            var distances = new int[graph.Length][];
            var path = new int[graph.Length][];

            for (var i = 0; i < distances.Length; i++)
            {
                distances[i] = new int[graph.Length];
                path[i] = new int[graph.Length];
                distances[i][i] = 0;
                path[i][i] = i;

                for (var j = 0; j < distances[i].Length; j++)
                {
                    if (j != i)
                    {
                        distances[i][j] = int.MaxValue / 2; // int.MaxValue will give us an overflow inside main loop
                    }
                }
            }

            for (var i = 0; i < graph.Length; i++)
            {
                var vertex = graph[i];

                for (var j = 0; j < vertex.Edges.Count; j++)
                {
                    distances[i][vertex.Edges[j].To] = vertex.Edges[j].Weight;
                    path[i][vertex.Edges[j].To] = i;
                }
            }

            for (var k = 0; k < distances.Length; k++)
            {
                for (var i = 0; i < distances.Length; i++)
                {
                    for (var j = 0; j < distances.Length; j++)
                    {
                        if (distances[i][j] > distances[i][k] + distances[k][j])
                        {
                            distances[i][j] = distances[i][k] + distances[k][j];
                            path[i][j] = k;
                        }
                    }
                }
            }

            return (distances, path);
        }
    }
}
