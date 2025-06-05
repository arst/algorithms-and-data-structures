using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.TravelingSalesman;

public class MinSpanningTreeTravelingSalesman
{
#pragma warning disable CA1822 // Mark members as static
    public int Travel(int[][] graph)
#pragma warning restore CA1822 // Mark members as static
    {
        if (graph is null) return default;

        const int startingCity = 0;
        var edges = new List<Tuple<int, int, int>>();
        var minimumSpanningTree = new List<Tuple<int, int, int>>();
        var spanningTree = new HashSet<int> { startingCity };

        //collect all edges for Prim's algorithm
        for (var i = 0; i < graph.Length; i++)
        for (var j = 0; j < graph.Length; j++)
            if (graph[i][j] > 0)
                // Item1 - From, Item2 - To, Item3 - Weight
                edges.Add(new Tuple<int, int, int>(i, j, graph[i][j]));

        // Construct MST using Prim's algorithm
        while (spanningTree.Count < graph.Length)
        {
            Tuple<int, int, int> minEdge = null;

            for (var i = 0; i < edges.Count; i++)
                if ((minEdge == null || minEdge.Item3 > edges[i].Item3) && spanningTree.Contains(edges[i].Item1) &&
                    !spanningTree.Contains(edges[i].Item2))
                    minEdge = edges[i];

            if (minEdge is null) continue;

            edges.Remove(minEdge);
            minimumSpanningTree.Add(minEdge);
            spanningTree.Add(minEdge.Item2);
        }

        //Construct a graph with MST tree edges only
        var minSpanningTreeGraph = new Tuple<int, List<int>>[graph.Length];

        for (var i = 0; i < minimumSpanningTree.Count; i++)
        {
            var (item1, item2, _) = minimumSpanningTree[i];

            minSpanningTreeGraph[item1] =
                minSpanningTreeGraph[item1] ?? new Tuple<int, List<int>>(item1, new List<int>());
            minSpanningTreeGraph[item2] =
                minSpanningTreeGraph[item2] ?? new Tuple<int, List<int>>(item2, new List<int>());

            minSpanningTreeGraph[item1].Item2.Add(item2);
            minSpanningTreeGraph[item2].Item2.Add(item1);
        }

        // Make DFS traversal of constructed graph
        var path = new List<int>();
        var visited = new bool[graph.Length];
        Dfs(minSpanningTreeGraph, path, visited, startingCity);
        var weight = 0;

        // Calculate path weight
        for (var i = 0; i < path.Count - 1; i++) weight += graph[path[i]][path[i + 1]];

        // We should return to the starting city 
        return weight + graph[path.Last()][startingCity];
    }

    private static void Dfs(IReadOnlyList<Tuple<int, List<int>>> minSpanningTreeGraph, ICollection<int> path,
        IList<bool> visited, int current)
    {
        visited[current] = true;
        path.Add(current);

        var adjacentVertices = minSpanningTreeGraph[current].Item2;
        for (var i = 0; i < adjacentVertices.Count; i++)
            if (!visited[adjacentVertices[i]])
                Dfs(minSpanningTreeGraph, path, visited, adjacentVertices[i]);
    }
}