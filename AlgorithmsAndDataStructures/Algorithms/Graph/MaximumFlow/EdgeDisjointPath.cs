using System;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.MaximumFlow
{
    public class EdgeDisjointPath
    {
#pragma warning disable CA1822 // Mark members as static
        public int GetEdgeDisjointPathCount(int[][] graph)
#pragma warning restore CA1822 // Mark members as static
        {
            if (graph is null)
            {
                return default;
            }

            var residualGraph = new int[graph.Length][];

            for (var i = 0; i < graph.Length; i++)
            {
                residualGraph[i] = new int[graph.Length];

                for (var j = 0;j < residualGraph[i].Length; j++)
                {
                    residualGraph[i][j] = graph[i][j];
                }
            }

            const int source = 0;
            var sink = graph.Length - 1;
            bool hasPath;
            var edgeDisjointPathCount = 0;

            do
            {
                var path = GetPath(residualGraph, source, sink);
                hasPath = path != null;

                if (hasPath)
                {
                    // We don't need to calculate delta for this kind of problem since all edges has max 1 capacity. 
                    var delta = 1;
                    var currentVertex = sink;
                    var parent = path[sink];
                    edgeDisjointPathCount += 1;
                    while (parent >= 0)
                    {
                        residualGraph[parent][currentVertex] = residualGraph[parent][currentVertex] - delta;
                        residualGraph[currentVertex][parent] = residualGraph[currentVertex][parent] + delta;
                        currentVertex = parent;
                        parent = path[currentVertex];
                    }
                }

            } while (hasPath);

            return edgeDisjointPathCount;
        }

        private static int[] GetPath(IReadOnlyList<int[]> residualGraph, int source, int sink)
        {
            var queue = new Queue<int>();
            var visited = new bool[residualGraph.Count];
            var path = new int[residualGraph.Count];

            queue.Enqueue(source);
            visited[source] = true;
            path[source] = -1;

            while (queue.Count > 0)
            {
                var currentVertex = queue.Dequeue();

                for (var i = 0; i < residualGraph[currentVertex].Length; i++)
                {
                    if (!visited[i] && residualGraph[currentVertex][i] > 0)
                    {
                        path[i] = currentVertex;
                        visited[i] = true;
                        queue.Enqueue(i);
                        
                        if (i == sink)
                        {
                            return path;
                        }
                    }
                }
            }

            return null;
        }
    }
}
