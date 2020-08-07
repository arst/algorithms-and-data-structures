using System;
using System.Collections.Generic;
using System.Linq;
using AlgorithmsAndDataStructures.Algorithms.Graph.Common;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.Misc
{
    public class TarjansAlgorithm
    {
        private const int nullParent = -1;

        public int[] GetArticulationPoints(UndirectedGraph graph)
        {
            var vertices = graph.Vertices();

            if (vertices.Length == 0)
            {
                return Array.Empty<int>();
            }

            var visited = new bool[vertices.Length];
            var articulationPoints = new bool[vertices.Length];
            var parents = new int[vertices.Length];
            var dicoveryTime = new int[vertices.Length];
            var lowestSubTreeDiscoveryTime = new int[vertices.Length];

            parents[0] = nullParent;

            DFSArticulationTraversal(vertices, 0, visited, articulationPoints, parents, dicoveryTime, lowestSubTreeDiscoveryTime, 0);

            return vertices.Select((arg, index) => index).Where(arg => articulationPoints[arg]).ToArray();
        }

        private void DFSArticulationTraversal(
            List<int>[] vertices,
            int currentVertice,
            bool[] visited, 
            bool[] articulationPoints, 
            int[] parents, 
            int[] dicoveryTime, 
            int[] lowestSubTreeDiscoveryTime,
            int time)
        {
            visited[currentVertice] = true;
            var children = 0;
            var currentDiscoveryTime = time + 1;
            dicoveryTime[currentVertice] = currentDiscoveryTime;
            lowestSubTreeDiscoveryTime[currentVertice] = currentDiscoveryTime;

            foreach (var adjacentVertice in vertices[currentVertice])
            {
                if (!visited[adjacentVertice])
                {
                    children++;
                    parents[adjacentVertice] = currentVertice;
                    DFSArticulationTraversal(
                        vertices,
                        adjacentVertice,
                        visited,
                        articulationPoints,
                        parents,
                        dicoveryTime,
                        lowestSubTreeDiscoveryTime,
                        currentDiscoveryTime);

                    lowestSubTreeDiscoveryTime[currentVertice] = Math.Min(lowestSubTreeDiscoveryTime[currentVertice], lowestSubTreeDiscoveryTime[adjacentVertice]);

                    if (parents[currentVertice] == nullParent && children > 1)
                    {
                        articulationPoints[currentVertice] = true;
                    }
                    if (parents[currentVertice] != nullParent && lowestSubTreeDiscoveryTime[adjacentVertice] >= dicoveryTime[currentVertice])
                    {
                        articulationPoints[currentVertice] = true;
                    }
                }
                else if(adjacentVertice != parents[currentVertice])
                {
                    lowestSubTreeDiscoveryTime[currentVertice] = Math.Min(lowestSubTreeDiscoveryTime[currentVertice], dicoveryTime[adjacentVertice]);
                }
            }
        }
    }
}
