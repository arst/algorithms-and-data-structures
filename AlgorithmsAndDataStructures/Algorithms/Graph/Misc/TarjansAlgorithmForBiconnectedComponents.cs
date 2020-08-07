using System;
using System.Collections.Generic;
using System.Linq;
using AlgorithmsAndDataStructures.Algorithms.Graph.Common;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.Misc
{
    public class TarjansAlgorithmForBiconnectedComponents
    {
        private const int nullParent = -1;

        public List<List<int>> GetBiconnectedComponents(UndirectedGraph graph)
        {
            var vertices = graph.Vertices();

            if (vertices.Length == 0)
            {
                return new List<List<int>>();
            }

            var visited = new bool[vertices.Length];
            var parents = new int[vertices.Length];
            var dicoveryTime = new int[vertices.Length];
            var lowestSubTreeDiscoveryTime = new int[vertices.Length];
            var dfs = new Stack<int>(vertices.Length);
            var biconnectedComponents = new List<List<int>>();

            for (var i = 0; i < vertices.Length; i++)
            {
                if (!visited[i])
                {
                    parents[i] = nullParent;
                    DFSArticulationTraversal(vertices, 0, visited, parents, dicoveryTime, lowestSubTreeDiscoveryTime, dfs, biconnectedComponents, 0);
                }


            }

            if (dfs.Any())
            {
                var component = new List<int>();

                while (dfs.Any())
                {
                    component.Add(dfs.Pop());
                }

                biconnectedComponents.Add(component);
            }

            return biconnectedComponents;
        }

        private void DFSArticulationTraversal(
            List<int>[] vertices,
            int currentVertice,
            bool[] visited, 
            int[] parents, 
            int[] dicoveryTime, 
            int[] lowestSubTreeDiscoveryTime,
            Stack<int> dfs,
            List<List<int>> biconnectedComponents,
            int time)
        {
            visited[currentVertice] = true;
            var children = 0;
            var currentDiscoveryTime = time++;
            dicoveryTime[currentVertice] = currentDiscoveryTime;
            lowestSubTreeDiscoveryTime[currentVertice] = currentDiscoveryTime;
            dfs.Push(currentVertice);

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
                        parents,
                        dicoveryTime,
                        lowestSubTreeDiscoveryTime,
                        dfs,
                        biconnectedComponents,
                        time);

                    lowestSubTreeDiscoveryTime[currentVertice] = Math.Min(lowestSubTreeDiscoveryTime[currentVertice], lowestSubTreeDiscoveryTime[adjacentVertice]);

                    var isActiculationPoint = false;

                    if (parents[currentVertice] == nullParent && children > 1)
                    {
                        isActiculationPoint = true;
                        
                    }
                    if (parents[currentVertice] != nullParent && lowestSubTreeDiscoveryTime[adjacentVertice] >= dicoveryTime[currentVertice])
                    {
                        isActiculationPoint = true;
                    }

                    if (isActiculationPoint)
                    {
                        var component = new List<int>();
                        component.Add(currentVertice);

                        while (dfs.Peek() != currentVertice)
                        {
                            component.Add(dfs.Pop());
                        }

                        biconnectedComponents.Add(component);
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
