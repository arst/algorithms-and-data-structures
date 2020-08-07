﻿using AlgorithmsAndDataStructures.Algorithms.Graph.Common;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.Backtracking
{
    public class PathOfMoreThanKLength
    {
        public (bool hasPath, HashSet<int> path) GetPathOfMoreThanKLength(WeightedGraphNode[] graph, int startVertex, int targetWeight)
        {
            if (graph is null)
            {
                return (false, new HashSet<int>());
            }

            var path = new HashSet<int> {startVertex};

            var hasPath = DFS(graph, startVertex, 0, targetWeight, path);

            return (hasPath, hasPath ? path : new HashSet<int>());
        }

        private bool DFS(WeightedGraphNode[] graph, int currentVertexIndex, int currentWeight, int targetWeight, ISet<int> path)
        {
            var currentVertex = graph[currentVertexIndex];

            if (currentWeight >= targetWeight)
            {
                return true;
            }

            foreach (var edge in currentVertex.Edges)
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
