using System;
using System.Collections.Generic;
using AlgorithmsAndDataStructures.Algorithms.Graph.Common;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.ShortestPath
{
    /*
    Negative weighted edges allowed: NO
    Complexity: o(n^2)
    Application: Most famous - digital services to find shortest path on the maps.
   */
    public class DijkstraNaive
    {
#pragma warning disable CA1822 // Mark members as static
        public (int, int[] path) MinDistance(WeightedGraphVertex[] graph, int from, int to)
#pragma warning restore CA1822 // Mark members as static
        {
            if (graph is null)
            {
                return (default, Array.Empty<int>());
            }

            var visited = new bool[graph.Length];
            var distance = new int[graph.Length];
            var path = new int[graph.Length];

            for (var i = 0; i < distance.Length; i++)
            {
                distance[i] = int.MaxValue;
            }

            distance[from] = 0;
            var current = GetMinNodeIndex(distance, visited);

            while (current > -1)
            {
                var currentNode = graph[current];

                foreach (var edge in currentNode.Edges)
                {
                    if (distance[current] + edge.Weight < distance[edge.To])
                    {
                        distance[edge.To] = distance[current] + edge.Weight;
                        path[edge.To] = current;
                    }
                }

                visited[current] = true;
                current = GetMinNodeIndex(distance, visited);
            }

            return (distance[to], path);
        }

        private static int GetMinNodeIndex(IReadOnlyList<int> distance, IReadOnlyList<bool> visited)
        {
            var currentMin = int.MaxValue;
            var currentMinIndex = -1;

            for (var i = 0; i < distance.Count; i++)
            {
                if (visited[i])
                {
                    continue;
                }

                if (distance[i] < currentMin)
                {
                    currentMinIndex = i;
                    currentMin = distance[i];
                }
            }

            return currentMinIndex;
        }
    }
}
