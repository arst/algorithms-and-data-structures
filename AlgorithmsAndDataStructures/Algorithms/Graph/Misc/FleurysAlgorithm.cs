using AlgorithmsAndDataStructures.Algorithms.Graph.Common;
using System;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.Misc
{
    public class FleurysAlgorithm
    {
        public List<Tuple<int, int>> GetEulerianTrail(UndirectedGraph graph)
        {
            var result = new List<Tuple<int, int>>();

            if (graph.Vertices().Length < 2)
            {
                return result;
            }

            var vertices = graph.Vertices();
            var visited = new bool[vertices.Length];


            // Check if all non-zero degree vertices are connected
            var nonZeroDegreeVertice = 0;

            for (var i = 0; i < vertices.Length; i++)
            {
                // We need to start from non-zero degree vertice to traverse non-zero degree vertices
                if (vertices[i].Count > 0)
                {
                    nonZeroDegreeVertice = i;
                    break;
                }
                //There is no non-zero degree vertices, graph is disconnected
                if (i == vertices.Length - 1)
                {
                    return result;
                }
            }

            DFS(vertices, visited, nonZeroDegreeVertice);

            for (var i = 0; i < vertices.Length; i++)
            {
                // If some of the vertices with non-zero degree are not visited during DFS, then graph is not Eulerian
                if (!visited[i] && vertices[i].Count > 0)
                {
                    return result;
                }
            }

            //Count vertices with odd degree, in Eulerian graph there are 0 or 2 vertices with odd degree. It is impossible to have 1 odd degree vertice in undirected graph.
            var oddVerticesCount = 0;
            var oddVertice = 0;

            for (var i = 0; i < vertices.Length; i++)
            {
                if (vertices[i].Count % 2 != 0)
                {
                    oddVerticesCount++;
                    oddVertice = i;
                }
            }

            if (oddVerticesCount > 2)
            {
                return result;
            }

            EulerianTraversal(oddVertice, vertices, result);

            return result;
        }

        private void EulerianTraversal(int currentVertice, List<int>[] vertices, List<Tuple<int, int>> eulerianPath)
        {
            var adjacentVertices = vertices[currentVertice];

            for (var i = 0; i < vertices[currentVertice].Count; i++)
            {
                if (adjacentVertices[i] == -1)
                {
                    continue;
                }

                if (IsValidEdgeToIncludeInEulerianTrail(currentVertice, adjacentVertices[i], vertices))
                {
                    var adjacentVertice = adjacentVertices[i];
                    eulerianPath.Add(new Tuple<int, int>(currentVertice, adjacentVertice));
                    RemoveEdge(vertices, currentVertice, adjacentVertice);
                    EulerianTraversal(adjacentVertice, vertices, eulerianPath);
                }
            }
        }

        private bool IsValidEdgeToIncludeInEulerianTrail(int from, int to, List<int>[] vertices)
        {

            //if it is the nly edge we have no other choises then to take it
            if (vertices[from].Count == 1)
            {
                return true;
            }

            var visited = new bool[vertices.Length];
            var reachableVerticesCount = DFSCount(from, vertices, visited);
            RemoveEdge(vertices, from, to);

            var visitedReduced = new bool[vertices.Length];
            var reachableVerticesCountReduced = DFSCount(from, vertices, visitedReduced);

            //add removed edge back to the graph
            vertices[from].Add(to);
            vertices[to].Add(from);
            //if dfs could reach less vertices after node removal then we have a bridge and according to Flurys algorithm we should prefer non-bridges over bridges
            return reachableVerticesCountReduced > reachableVerticesCount ? false : true;
        }

        private int DFSCount(int currentVertice, List<int>[] vertices, bool[] visited)
        {
            visited[currentVertice] = true;
            var count = 1;

            for (var i = 0; i < vertices[currentVertice].Count; i++)
            {
                if (!visited[vertices[currentVertice][i]])
                {
                    return count + DFSCount(vertices[currentVertice][i], vertices, visited);
                }
            }

            return count;
        }

        private static void RemoveEdge(List<int>[] vertices, int from, int to)
        {
            var fromIndex = vertices[from].Remove(to);
            var toIndex = vertices[to].Remove(from);
        }

        private static void DFS(List<int>[] vertices, bool[] visited, int currentVertice)
        {
            visited[currentVertice] = true;

            for (var i = 0; i < vertices[currentVertice].Count; i++)
            {
                if (!visited[vertices[currentVertice][i]])
                {
                    DFS(vertices, visited, vertices[currentVertice][i]);
                }
            }
        }
    }
}
