using AlgorithmsAndDataStructures.DataStructures.Graph;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.Algorithms.Graph
{
    public class CycleDetection
    {
        // Time Complexity O(V+E)
        public bool IsCyclic(GraphNode<int>[] graph)
        {
            // We need to iterate over all vertices for diconnected graphs.
            for (int i = 0; i < graph.Length; i++)
            {
                var visited = new bool[graph.Length];
                visited[i] = true;

                if (IsCyclic(graph, i, visited))
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsCyclic(GraphNode<int>[] graph, int node, bool[] visited)
        {
            List<int> adjacentNodes = graph[node].AdjacentNodes;

            for (int i = 0; i < adjacentNodes.Count; i++)
            {
                if (visited[adjacentNodes[i]])
                {
                    return true;
                }
                else
                {
                    visited[adjacentNodes[i]] = true;
                    return IsCyclic(graph, adjacentNodes[i], visited);
                }
            }

            visited[node] = false;

            return false;
        }
    }
}
