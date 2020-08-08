using System;
using AlgorithmsAndDataStructures.Algorithms.Graph.Common;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.Backtracking
{
    public class HamiltonPath
    {
#pragma warning disable CA1822 // Mark members as static
        public (bool hasPath, bool hasCycle, int[] path) HasHamiltonPath(UndirectedGraph graph)
#pragma warning restore CA1822 // Mark members as static
        {
            if (graph is null)
            {
                return (default, default, Array.Empty<int>());
            }

            var vertices = graph.Vertices();
            var visited = new bool[vertices.Length];
            var parent = new int[vertices.Length];
            var path = new int[vertices.Length + 1];

            for (var i = 0; i < parent.Length; i++)
            {
                parent[i] = -1;
            }

            var hasPath = IsHamiltonPath(0, vertices, visited, parent);
            var hasCycle = hasPath &&HasCycle(parent, vertices);

            if (hasPath)
            {
                var index = 0;
                var pathIndex = 1;

                while (parent[index] != -1)
                {
                    path[pathIndex] = parent[index];
                    pathIndex++;
                    index = parent[index];
                }

                path[pathIndex] = hasCycle ? 0 : -1;
            }

            return (hasPath, hasCycle, path);
        }

        private static bool HasCycle(IReadOnlyList<int> parent, IReadOnlyList<List<int>> vertices)
        {
            var lastVertexIndex = -1;

            for (var i = 0; i < parent.Count; i++)
            {
                if (parent[i] == -1)
                {
                    lastVertexIndex = i;
                    break;
                }
            }

            return vertices[lastVertexIndex].Any(arg => arg == 0);
        }

        private static bool IsHamiltonPath(int currentVertex, IReadOnlyList<List<int>> vertices, IList<bool> visited, IList<int> parent)
        {
            visited[currentVertex] = true;

            if (IsPathFormed(visited))
            {
                return true;
            }

            foreach (var adjacentVertex in vertices[currentVertex])
            {
                if (!visited[adjacentVertex])
                {
                    parent[currentVertex] = adjacentVertex;
                    var isPathFormed = IsHamiltonPath(adjacentVertex, vertices, visited, parent);

                    if (isPathFormed)
                    {
                        return true;
                    }

                    parent[currentVertex] = -1;
                    visited[adjacentVertex] = false;
                }
            }

            return false;
        }

        private static bool IsPathFormed(IEnumerable<bool> visited)
        {
            return visited.All(arg => arg);
        }
    }
}
