using System;
using System.Collections.Generic;
using System.Linq;
using AlgorithmsAndDataStructures.Algorithms.Graph.Common;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.Misc
{
    public class TarjansAlgorithmForBiconnectedComponents
    {
        private const int NullParent = -1;

#pragma warning disable CA1822 // Mark members as static
        public List<List<int>> GetBiconnectedComponents(UndirectedGraph graph)
#pragma warning restore CA1822 // Mark members as static
        {
            if (graph is null)
            {
                return new List<List<int>>(0);
            }

            var vertices = graph.Vertices();

            if (vertices.Length == 0)
            {
                return new List<List<int>>();
            }

            var visited = new bool[vertices.Length];
            var parents = new int[vertices.Length];
            var discoveryTime = new int[vertices.Length];
            var lowestSubTreeDiscoveryTime = new int[vertices.Length];
            var dfs = new Stack<int>(vertices.Length);
            var biconnectedComponents = new List<List<int>>();

            for (var i = 0; i < vertices.Length; i++)
            {
                if (!visited[i])
                {
                    parents[i] = NullParent;
                    DfsArticulationTraversal(vertices, 0, visited, parents, discoveryTime, lowestSubTreeDiscoveryTime, dfs, biconnectedComponents, 0);
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

        private static void DfsArticulationTraversal(
            IReadOnlyList<List<int>> vertices,
            int currentVertex,
            IList<bool> visited, 
            IList<int> parents, 
            IList<int> discoveryTime, 
            IList<int> lowestSubTreeDiscoveryTime,
            Stack<int> dfs,
            ICollection<List<int>> biconnectedComponents,
            int time)
        {
            visited[currentVertex] = true;
            var children = 0;
            var currentDiscoveryTime = time++;
            discoveryTime[currentVertex] = currentDiscoveryTime;
            lowestSubTreeDiscoveryTime[currentVertex] = currentDiscoveryTime;
            dfs.Push(currentVertex);

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
                        parents,
                        discoveryTime,
                        lowestSubTreeDiscoveryTime,
                        dfs,
                        biconnectedComponents,
                        time);

                    lowestSubTreeDiscoveryTime[currentVertex] = Math.Min(lowestSubTreeDiscoveryTime[currentVertex], lowestSubTreeDiscoveryTime[adjacentVertex]);

                    var isRootNode = parents[currentVertex] == NullParent && children > 1;
                    var isChildrenCantReachBeyondParent = parents[currentVertex] != NullParent && lowestSubTreeDiscoveryTime[adjacentVertex] >= discoveryTime[currentVertex];
                    var isArticulationPoint = isRootNode || isChildrenCantReachBeyondParent;

                    if (isArticulationPoint)
                    {
                        var component = new List<int> {currentVertex};

                        while (dfs.Peek() != currentVertex)
                        {
                            component.Add(dfs.Pop());
                        }

                        biconnectedComponents.Add(component);
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
