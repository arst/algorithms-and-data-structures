using System.Collections.Generic;
using AlgorithmsAndDataStructures.Algorithms.Graph.Common;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.Misc;

public class EulerianPath
{
#pragma warning disable CA1822 // Mark members as static
    public (bool hasEulerianCycle, bool hasEulerianPath) IsEulerian(UndirectedGraph graph)
#pragma warning restore CA1822 // Mark members as static
    {
        if (graph is null) return (default, default);

        if (graph.Vertices().Length < 2) return (true, true);

        var vertices = graph.Vertices();
        var visited = new bool[vertices.Length];


        // Check if all non-zero degree vertices are connected.
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
            if (i == vertices.Length - 1) return (false, false);
        }

        Dfs(vertices, visited, nonZeroDegreeVertex);

        for (var i = 0; i < vertices.Length; i++)
            // If some of the vertices with non-zero degree are not visited during DFS, then graph is not Eulerian.
            if (!visited[i] && vertices[i].Count > 0)
                return (false, false);

        //Count vertices with odd degree, in Eulerian graph there are 0 or 2 vertices with odd degree. It is impossible to have 1 odd degree vertex in undirected graph.
        var odd = 0;

        for (var i = 0; i < vertices.Length; i++)
            if (vertices[i].Count % 2 != 0)
                odd++;

        if (odd > 2) return (false, false);

        // if there are 2 vertices with odd degree then it is a semi-Eulerian(has only Eulerian path) graph, if all vertices are even then it is a full-Eulerian(has Eulerian cycle) graph
        return (odd == 0, odd == 2);
    }

    private static void Dfs(IReadOnlyList<List<int>> vertices, IList<bool> visited, int currentVertex)
    {
        visited[currentVertex] = true;

        for (var i = 0; i < vertices[currentVertex].Count; i++)
            if (!visited[vertices[currentVertex][i]])
                Dfs(vertices, visited, vertices[currentVertex][i]);
    }
}