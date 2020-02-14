using AlgorithmsAndDataStructures.Algorithms.Graph.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.Misc
{
    public class BiconnectedGraph
    {
        private const int nullParent = -1;

        public bool IsBiconnected(UndirectedGraph graph)
        {
            var vertices = graph.Vertices();
            var visited = new bool[vertices.Length];
            var parents = new int[vertices.Length];
            var discoveryTimes = new int[vertices.Length];
            var lowestReachableDiscoveryTime = new int[vertices.Length];

            parents[0] = nullParent;
            var result = IsBiconnected(vertices, 0, 0, visited, parents, discoveryTimes, lowestReachableDiscoveryTime) && visited.All(arg => arg);

            return result;
        }

        private bool IsBiconnected(List<int>[] vertices, int currentVertice, int currentDiscoveryTime, bool[] visited, int[] parents, int[] discoveryTimes, int[] lowestReachableDiscoveryTime)
        {
            visited[currentVertice] = true;
            discoveryTimes[currentVertice] = lowestReachableDiscoveryTime[currentVertice] = currentDiscoveryTime++;
            var children = 0;

            foreach (var adjacentVertice in vertices[currentVertice])
            {
                if (!visited[adjacentVertice])
                {
                    children++;
                    parents[adjacentVertice] = currentVertice;

                    var result = IsBiconnected(vertices, adjacentVertice, currentDiscoveryTime, visited, parents, discoveryTimes, lowestReachableDiscoveryTime);
                    
                    if (!result)
                    {
                        return result;
                    }

                    lowestReachableDiscoveryTime[currentVertice] = Math.Min(lowestReachableDiscoveryTime[currentVertice], lowestReachableDiscoveryTime[adjacentVertice]);

                    if (parents[currentVertice] == nullParent && children > 1)
                    {
                        return false;
                    }
                    if (parents[currentVertice] != nullParent && lowestReachableDiscoveryTime[adjacentVertice] >= discoveryTimes[currentVertice])
                    {
                        return false;
                    }
                }
                else if (adjacentVertice != parents[currentVertice])
                {
                    lowestReachableDiscoveryTime[currentVertice] = Math.Min(lowestReachableDiscoveryTime[currentVertice], discoveryTimes[adjacentVertice]);
                }
            }

            return true;
        }
    }
}
