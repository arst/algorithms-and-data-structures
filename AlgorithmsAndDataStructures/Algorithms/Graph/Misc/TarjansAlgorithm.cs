using System;
using System.Collections.Generic;
using System.Linq;
using AlgorithmsAndDataStructures.Algorithms.Graph.Common;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.Misc
{
    public class TarjansAlgorithm
    {
        private const int NullParent = -1;

#pragma warning disable CA1822 // Mark members as static
        public int[] GetArticulationPoints(UndirectedGraph graph)
#pragma warning restore CA1822 // Mark members as static
        {
            if (graph is null)
            {
                return Array.Empty<int>();
            }

            var vertices = graph.Vertices();

            if (vertices.Length == 0)
            {
                return Array.Empty<int>();
            }

            var visited = new bool[vertices.Length];
            var articulationPoints = new bool[vertices.Length];
            var parents = new int[vertices.Length];
            var discoveryTime = new int[vertices.Length];
            var lowestSubTreeDiscoveryTime = new int[vertices.Length];

            parents[0] = NullParent;

            DfsArticulationTraversal(vertices, 0, visited, articulationPoints, parents, discoveryTime, lowestSubTreeDiscoveryTime, 0);

            return vertices.Select((arg, index) => index).Where(arg => articulationPoints[arg]).ToArray();
        }

        private static void DfsArticulationTraversal(
            IReadOnlyList<List<int>> vertices,
            int currentVertex,
            IList<bool> visited, 
            IList<bool> articulationPoints, 
            IList<int> parents, 
            IList<int> discoveryTime, 
            IList<int> lowestSubTreeDiscoveryTime,
            int time)
        {
            visited[currentVertex] = true;
            var children = 0;
            var currentDiscoveryTime = time + 1;
            discoveryTime[currentVertex] = currentDiscoveryTime;
            lowestSubTreeDiscoveryTime[currentVertex] = currentDiscoveryTime;

            foreach (var adjacentVertex in vertices[currentVertex])
            {
                if (!visited[adjacentVertex])
                {
                    children++;
                    parents[adjacentVertex] = currentVertex;
                    DfsArticulationTraversal(
                        vertices,
                        adjacentVertex,
                        visited,
                        articulationPoints,
                        parents,
                        discoveryTime,
                        lowestSubTreeDiscoveryTime,
                        currentDiscoveryTime);

                    lowestSubTreeDiscoveryTime[currentVertex] = Math.Min(lowestSubTreeDiscoveryTime[currentVertex], lowestSubTreeDiscoveryTime[adjacentVertex]);

                    if (parents[currentVertex] == NullParent && children > 1)
                    {
                        articulationPoints[currentVertex] = true;
                    }
                    if (parents[currentVertex] != NullParent && lowestSubTreeDiscoveryTime[adjacentVertex] >= discoveryTime[currentVertex])
                    {
                        articulationPoints[currentVertex] = true;
                    }
                }
                else if(adjacentVertex != parents[currentVertex])
                {
                    lowestSubTreeDiscoveryTime[currentVertex] = Math.Min(lowestSubTreeDiscoveryTime[currentVertex], discoveryTime[adjacentVertex]);
                }
            }
        }
    }
}
