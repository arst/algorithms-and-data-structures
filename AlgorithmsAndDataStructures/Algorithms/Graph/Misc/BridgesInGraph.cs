using AlgorithmsAndDataStructures.Algorithms.Graph.Common;
using System;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.Misc
{
    public class BridgesInGraph
    {
        private const int nullParent = -1;

        public List<Tuple<int, int>> GetBridges(UndirectedGraph grpah)
        {
            var vertices = grpah.Vertices();
            var discoveryTimes = new int[vertices.Length];
            var lowestReachableDicoveryTimeInSubtree = new int[vertices.Length];
            var visited = new bool[vertices.Length];
            var bridges = new List<Tuple<int, int>>();
            var parents = new int[vertices.Length];

            for (var i = 0; i < vertices.Length; i++)
            {
                if (!visited[i])
                    GetBridges(i, 0, vertices, discoveryTimes, lowestReachableDicoveryTimeInSubtree, visited, parents, bridges);
            }

            return bridges;
        }

        private void GetBridges(int currentVertice, int dicoveryTime, List<int>[] vertices, int[] discoveryTimes, int[] lowestReachableDicoveryTimeInSubtree, bool[] visited, int[] parents, List<Tuple<int, int>> bridges)
        {
            discoveryTimes[currentVertice] = lowestReachableDicoveryTimeInSubtree[currentVertice] = dicoveryTime++;
            visited[currentVertice] = true;
            var children = 0;

            foreach (var adjacentVertice in vertices[currentVertice])
            {
                if (!visited[adjacentVertice])
                {
                    children++;
                    parents[adjacentVertice] = currentVertice;
                    GetBridges(adjacentVertice, dicoveryTime, vertices, discoveryTimes, lowestReachableDicoveryTimeInSubtree, visited, parents, bridges);

                    lowestReachableDicoveryTimeInSubtree[currentVertice] = Math.Min(lowestReachableDicoveryTimeInSubtree[currentVertice], lowestReachableDicoveryTimeInSubtree[adjacentVertice]);

                    if (parents[currentVertice] == nullParent && children > 1)
                    {
                        bridges.Add(new Tuple<int, int>(currentVertice, adjacentVertice));
                    }
                    if (parents[currentVertice] != nullParent && lowestReachableDicoveryTimeInSubtree[adjacentVertice] > discoveryTimes[currentVertice])
                    {
                        bridges.Add(new Tuple<int, int>(currentVertice, adjacentVertice));
                    }
                }
                else if (adjacentVertice != parents[currentVertice])
                {
                    lowestReachableDicoveryTimeInSubtree[currentVertice] = Math.Min(lowestReachableDicoveryTimeInSubtree[currentVertice], discoveryTimes[adjacentVertice]);
                }

            }
        }
    }
}
