using System;
using System.Collections.Generic;
using AlgorithmsAndDataStructures.Algorithms.Graph.Common;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.Misc;

public class BridgesInGraph
{
    private const int NullParent = -1;

#pragma warning disable CA1822 // Mark members as static
    public List<Tuple<int, int>> GetBridges(UndirectedGraph graph)
#pragma warning restore CA1822 // Mark members as static
    {
        if (graph is null) return new List<Tuple<int, int>>(0);

        var vertices = graph.Vertices();
        var discoveryTimes = new int[vertices.Length];
        var lowestReachableDiscoveryTimeInSubtree = new int[vertices.Length];
        var visited = new bool[vertices.Length];
        var bridges = new List<Tuple<int, int>>();
        var parents = new int[vertices.Length];

        for (var i = 0; i < vertices.Length; i++)
            if (!visited[i])
                GetBridges(i, 0, vertices, discoveryTimes, lowestReachableDiscoveryTimeInSubtree, visited, parents,
                    bridges);

        return bridges;
    }

    private static void GetBridges(
        int currentVertex,
        int discoveryTime,
        IReadOnlyList<List<int>> vertices,
        IList<int> discoveryTimes,
        IList<int> lowestReachableDiscoveryTimeInSubtree,
        IList<bool> visited,
        IList<int> parents,
        ICollection<Tuple<int, int>> bridges)
    {
        discoveryTimes[currentVertex] = lowestReachableDiscoveryTimeInSubtree[currentVertex] = discoveryTime++;
        visited[currentVertex] = true;
        var children = 0;

        foreach (var adjacentVertex in vertices[currentVertex])
            if (!visited[adjacentVertex])
            {
                children++;
                parents[adjacentVertex] = currentVertex;
                GetBridges(adjacentVertex, discoveryTime, vertices, discoveryTimes,
                    lowestReachableDiscoveryTimeInSubtree, visited, parents, bridges);

                lowestReachableDiscoveryTimeInSubtree[currentVertex] = Math.Min(
                    lowestReachableDiscoveryTimeInSubtree[currentVertex],
                    lowestReachableDiscoveryTimeInSubtree[adjacentVertex]);

                if (parents[currentVertex] == NullParent && children > 1)
                    bridges.Add(new Tuple<int, int>(currentVertex, adjacentVertex));
                if (parents[currentVertex] != NullParent && lowestReachableDiscoveryTimeInSubtree[adjacentVertex] >
                    discoveryTimes[currentVertex]) bridges.Add(new Tuple<int, int>(currentVertex, adjacentVertex));
            }
            else if (adjacentVertex != parents[currentVertex])
            {
                lowestReachableDiscoveryTimeInSubtree[currentVertex] =
                    Math.Min(lowestReachableDiscoveryTimeInSubtree[currentVertex], discoveryTimes[adjacentVertex]);
            }
    }
}