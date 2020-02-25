using AlgorithmsAndDataStructures.Algorithms.Graph.Common;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.Backtracking
{
    public class HamiltonPath
    {
        public (bool hasPath, bool hasCycle, int[] path) HasHamiltonPath(UndirectedGraph graph)
        {
            var vertices = graph.Vertices();
            var visited = new bool[vertices.Length];
            var parent = new int[vertices.Length];
            var path = new int[vertices.Length + 1];

            for (int i = 0; i < parent.Length; i++)
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

        private bool HasCycle(int[] parent, List<int>[] vertices)
        {
            var lastVerticeIndex = -1;

            for (int i = 0; i < parent.Length && lastVerticeIndex < 0; i++)
            {
                if (parent[i] == -1)
                {
                    lastVerticeIndex = i;
                    break;
                }
            }

            return vertices[lastVerticeIndex].Any(arg => arg == 0);
        }

        private bool IsHamiltonPath(int currentVertice, List<int>[] vertices, bool[] visited, int[] parent)
        {
            visited[currentVertice] = true;

            if (IsPathFormed(visited))
            {
                return true;
            }

            foreach (var adjacentVertices in vertices[currentVertice])
            {
                if (!visited[adjacentVertices])
                {
                    parent[currentVertice] = adjacentVertices;
                    var isPathFormed = IsHamiltonPath(adjacentVertices, vertices, visited, parent);

                    if (isPathFormed)
                    {
                        return true;
                    }

                    parent[currentVertice] = -1;
                    visited[adjacentVertices] = false;
                }
            }

            return false;
        }

        private bool IsPathFormed(bool[] visited)
        {
            return visited.All(arg => arg);
        }
    }
}
