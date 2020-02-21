using AlgorithmsAndDataStructures.Algorithms.Graph.Common;
using System;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.Backtracking
{
    public class PathOfMoreThanKLength
    {
        public (bool hasPath, HashSet<int> path) GetPathOfMoreThanKLength(WeightedGraphNode[] graph, int startVertice, int targetWeight)
        {
            var path = new HashSet<int>();

            path.Add(startVertice);
            var hasPath = DFS(graph, startVertice, 0, targetWeight, path);

            return (hasPath, hasPath ? path : new HashSet<int>());
        }

        private bool DFS(WeightedGraphNode[] graph, int currentVertice, int currentWeight, int targetWeight, HashSet<int> path)
        {
            var vertice = graph[currentVertice];

            if (currentWeight >= targetWeight)
            {
                return true;
            }

            foreach (var edge in vertice.Edges)
            {
                if (!path.Contains(edge.To))
                {
                    path.Add(edge.To);

                    var isPath = DFS(graph, edge.To, currentWeight + edge.Weight, targetWeight, path);

                    if (isPath)
                    {
                        return true;
                    }

                    path.Remove(edge.To);
                }
            }

            return false;
        }
    }
}
