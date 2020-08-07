using System;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.MaximumFlow
{
    public class EdgeDisjointPath
    {
        public int GetEdgeDisjointPathCount(int[][] graph)
        {
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
                    var currentVertice = sink;
                    var parent = path[sink];
                    edgeDisjointPathCount += 1;
                    while (parent >= 0)
                    {
                        residualGraph[parent][currentVertice] = residualGraph[parent][currentVertice] - delta;
                        residualGraph[currentVertice][parent] = residualGraph[currentVertice][parent] + delta;
                        currentVertice = parent;
                        parent = path[currentVertice];
                    }
                }

            } while (hasPath);

            return edgeDisjointPathCount;
        }

        private int[] GetPath(int[][] residualGraph, int source, int sink)
        {
            var queue = new Queue<int>();
            var visited = new bool[residualGraph.Length];
            var path = new int[residualGraph.Length];

            queue.Enqueue(source);
            visited[source] = true;
            path[source] = -1;

            while (queue.Count > 0)
            {
                var currentVertice = queue.Dequeue();

                for (var i = 0; i < residualGraph[currentVertice].Length; i++)
                {
                    if (!visited[i] && residualGraph[currentVertice][i] > 0)
                    {
                        path[i] = currentVertice;
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
