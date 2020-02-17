using System;
using System.Collections.Generic;
using AlgorithmsAndDataStructures.Algorithms.Graph.Common;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.LongestPath
{
    public class LongestPathInADirectedAcyclicGraph
    {
        public int[] GetLongestPath(WeightedGraphNode[] graph)
        {
            var distances = new int[graph.Length];
            var topologicalOrdering = new Stack<int>(graph.Length);
            var visited = new bool[graph.Length];

            for (int i = 1; i < distances.Length; i++)
                distances[i] = -1;

            // We need TS first to get the right order of the adjacent nodes. Without it it may lead to situation
            // where we use distance of a vertex v to update distances of its adjacent vertices adj[v], 
            // but after that, the distance of vertex v gets updated, so vertices from adj[v] could also get bigger distances, but we won't visit them anymore.
            for (int i = 0; i < distances.Length; i++)
            {
                if (!visited[i])
                    TopologicalSort(graph, i, topologicalOrdering, visited);
            }

            while (topologicalOrdering.Count > 0)
            {
                var currentVertice = topologicalOrdering.Pop();

                foreach (var edge in graph[currentVertice].Edges)
                {
                    if (distances[edge.To] < distances[currentVertice] +  edge.Weight)
                    {
                        distances[edge.To] = distances[currentVertice] + edge.Weight;
                    }
                }
            }

            return distances;
        }

        private void TopologicalSort(WeightedGraphNode[] graph, int currentVertice, Stack<int> topologicalOrdering, bool[] visited)
        {
            var edges = graph[currentVertice].Edges;
            visited[currentVertice] = true;

            foreach (var edge in edges)
            {
                if (!visited[edge.To])
                {
                    TopologicalSort(graph, edge.To, topologicalOrdering, visited);
                }
            }

            topologicalOrdering.Push(currentVertice);
        }
    }
}
