using System;
using System.Collections.Generic;
using System.Linq;
using AlgorithmsAndDataStructures.Algorithms.Graph.Common;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.Misc;

public class BiConnectedGraph
{
    private const int NullParent = -1;

#pragma warning disable CA1822 // Mark members as static
    public bool IsBiConnected(UndirectedGraph graph)
#pragma warning restore CA1822 // Mark members as static
    {
        if (graph is null) return default;

        var vertices = graph.Vertices();
        var visited = new bool[vertices.Length];
        var parents = new int[vertices.Length];
        var discoveryTimes = new int[vertices.Length];
        var lowestReachableDiscoveryTime = new int[vertices.Length];

        parents[0] = NullParent;
        var result = IsBiConnected(vertices, 0, 0, visited, parents, discoveryTimes, lowestReachableDiscoveryTime) &&
                     visited.All(arg => arg);

        return result;
    }

    private static bool IsBiConnected(
        IReadOnlyList<List<int>> vertices,
        int currentVertex,
        int currentDiscoveryTime,
        IList<bool> visited, IList<int> parents,
        IList<int> discoveryTimes,
        IList<int> lowestReachableDiscoveryTime)
    {
        visited[currentVertex] = true;
        discoveryTimes[currentVertex] = lowestReachableDiscoveryTime[currentVertex] = currentDiscoveryTime++;
        var children = 0;

        foreach (var adjacentVertex in vertices[currentVertex])
            if (!visited[adjacentVertex])
            {
                children++;
                parents[adjacentVertex] = currentVertex;

                var result = IsBiConnected(vertices, adjacentVertex, currentDiscoveryTime, visited, parents,
                    discoveryTimes, lowestReachableDiscoveryTime);

                if (!result) return false;

                lowestReachableDiscoveryTime[currentVertex] = Math.Min(lowestReachableDiscoveryTime[currentVertex],
                    lowestReachableDiscoveryTime[adjacentVertex]);

                if (parents[currentVertex] == NullParent && children > 1) return false;
                if (parents[currentVertex] != NullParent &&
                    lowestReachableDiscoveryTime[adjacentVertex] >= discoveryTimes[currentVertex]) return false;
            }
            else if (adjacentVertex != parents[currentVertex])
            {
                lowestReachableDiscoveryTime[currentVertex] = Math.Min(lowestReachableDiscoveryTime[currentVertex],
                    discoveryTimes[adjacentVertex]);
            }

        return true;
    }
}