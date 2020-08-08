using AlgorithmsAndDataStructures.Algorithms.Graph.Common;
using System;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.Misc
{
    public class FleurysAlgorithm
    {
        public List<Tuple<int, int>> GetEulerianTrail(UndirectedGraph graph)
        {
            if (graph is null)
            {
                return new List<Tuple<int, int>>(0);
            }

            var result = new List<Tuple<int, int>>();

            if (graph.Vertices().Length < 2)
            {
                return result;
            }

            var vertices = graph.Vertices();
            var visited = new bool[vertices.Length];


            // Check if all non-zero degree vertices are connected
            var nonZeroDegreeVertex = 0;

            for (var i = 0; i < vertices.Length; i++)
            {
                // We need to start from non-zero degree vertex to traverse non-zero degree vertices
                if (vertices[i].Count > 0)
                {
                    nonZeroDegreeVertex = i;
                    break;
                }
                //There is no non-zero degree vertices, graph is disconnected
                if (i == vertices.Length - 1)
                {
                    return result;
                }
            }

            Dfs(vertices, visited, nonZeroDegreeVertex);

            for (var i = 0; i < vertices.Length; i++)
            {
                // If some of the vertices with non-zero degree are not visited during DFS, then graph is not Eulerian
                if (!visited[i] && vertices[i].Count > 0)
                {
                    return result;
                }
            }

            //Count vertices with odd degree, in Eulerian graph there are 0 or 2 vertices with odd degree. It is impossible to have 1 odd degree vertex in undirected graph.
            var oddVerticesCount = 0;
            var oddVertex = 0;

            for (var i = 0; i < vertices.Length; i++)
            {
                if (vertices[i].Count % 2 != 0)
                {
                    oddVerticesCount++;
                    oddVertex = i;
                }
            }

            if (oddVerticesCount > 2)
            {
                return result;
            }

            EulerianTraversal(oddVertex, vertices, result);

            return result;
        }

        private static void EulerianTraversal(int currentVertex, IReadOnlyList<List<int>> vertices, ICollection<Tuple<int, int>> eulerianPath)
        {
            var adjacentVertices = vertices[currentVertex];

            for (var i = 0; i < vertices[currentVertex].Count; i++)
            {
                if (adjacentVertices[i] == -1)
                {
                    continue;
                }

                if (IsValidEdgeToIncludeInEulerianTrail(currentVertex, adjacentVertices[i], vertices))
                {
                    var adjacentVertex = adjacentVertices[i];
                    eulerianPath.Add(new Tuple<int, int>(currentVertex, adjacentVertex));
                    RemoveEdge(vertices, currentVertex, adjacentVertex);
                    EulerianTraversal(adjacentVertex, vertices, eulerianPath);
                }
            }
        }

        private static bool IsValidEdgeToIncludeInEulerianTrail(int from, int to, IReadOnlyList<List<int>> vertices)
        {

            //if it is the nly edge we have no other choices then to take it
            if (vertices[from].Count == 1)
            {
                return true;
            }

            var visited = new bool[vertices.Count];
            var reachableVerticesCount = DfsCount(from, vertices, visited);
            RemoveEdge(vertices, from, to);

            var visitedReduced = new bool[vertices.Count];
            var reachableVerticesCountReduced = DfsCount(from, vertices, visitedReduced);

            //add removed edge back to the graph
            vertices[from].Add(to);
            vertices[to].Add(from);
            //if dfs could reach less vertices after node removal then we have a bridge and according to Fleury's algorithm we should prefer non-bridges over bridges
            return reachableVerticesCountReduced <= reachableVerticesCount;
        }

        private static int DfsCount(int currentVertex, IReadOnlyList<List<int>> vertices, IList<bool> visited)
        {
            visited[currentVertex] = true;
            const int count = 1;

            for (var i = 0; i < vertices[currentVertex].Count; i++)
            {
                if (!visited[vertices[currentVertex][i]])
                {
                    return count + DfsCount(vertices[currentVertex][i], vertices, visited);
                }
            }

            return count;
        }

        private static void RemoveEdge(IReadOnlyList<List<int>> vertices, int from, int to)
        {
            vertices[from].Remove(to);
            vertices[to].Remove(from);
        }

        private static void Dfs(IReadOnlyList<List<int>> vertices, IList<bool> visited, int currentVertex)
        {
            visited[currentVertex] = true;

            for (var i = 0; i < vertices[currentVertex].Count; i++)
            {
                if (!visited[vertices[currentVertex][i]])
                {
                    Dfs(vertices, visited, vertices[currentVertex][i]);
                }
            }
        }
    }
}
