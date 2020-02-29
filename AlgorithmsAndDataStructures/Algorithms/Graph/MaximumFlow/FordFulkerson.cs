using System;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.MaximumFlow
{
    // Ford Fulkerson is actually an approach and not the whle algorithm, it doesn't specify the exact way to traverse a residual graph.
    // Since this implementation uses BFS, it's technically Edmonds-Karp algorithm with complexity of O(V*E^2)
    public class FordFulkerson
    {
        // Actually, flow netwrok here is just a directed graph, though, it may as well be undirected.
        public int MaxFlow(int[][] flowNetwork)
        {
            var residualGraph = new int[flowNetwork.GetLength(0)][];
            var flow = 0;
            for (int i = 0; i < residualGraph.Length; i++)
            {
                residualGraph[i] = new int[flowNetwork[i].Length];

                for (int j = 0; j < residualGraph[i].Length; j++)
                {
                    residualGraph[i][j] = flowNetwork[i][j];
                }
            }

            bool hasPath;
            var sink = flowNetwork.Length - 1;
            var source = 0;

            do
            {
                // Do simple BFS and record the path from source to sink if such path exists.
                var path = GetPath(residualGraph, source, sink);
                hasPath = path != null;
                
                if (hasPath)
                {
                    // Get minimum available capacity in the augmenting path.
                    var delta = GetDelta(residualGraph, path, sink);
                    // Augment max flow with value of delta since we were able to find augmenting path. 
                    flow += delta;

                    // Follow the path until we rich the source.
                    var currentVertice = sink;
                    var parent = path[currentVertice];

                    while (parent >= 0)
                    {
                        // Reduce capacity of the nodes along the path with delta.
                        residualGraph[parent][currentVertice] = residualGraph[parent][currentVertice] - delta;
                        // Create back-node to allow flow undo.
                        residualGraph[currentVertice][parent] = residualGraph[currentVertice][parent] + delta;

                        currentVertice = parent;
                        parent = path[currentVertice];
                    }
                }

            } while (hasPath);

            return flow;
        }

        private int GetDelta(int[][] residualGraph,int[] path, int targetVertice)
        {
            var delta = int.MaxValue;
            var currentVertice = targetVertice;
            var parent = path[currentVertice];

            while (parent >= 0)
            {
                delta = Math.Min(residualGraph[parent][currentVertice], delta);
                currentVertice = parent;
                parent = path[currentVertice];
            }

            return delta;
        }

        // Since BFS is used, we getshortest path here.
        private int[] GetPath(int[][] residualGraph, int currentVertice, int targetVertice)
        {
            var path = new int[residualGraph.Length];
            var queue = new Queue<int>();
            var visited = new bool[residualGraph.Length];
            path[currentVertice] = -1;
            visited[currentVertice] = true;
            queue.Enqueue(currentVertice);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                for (int i = 0; i < residualGraph[current].Length; i++)
                {
                    int adjacentVerticeCapacity = residualGraph[current][i];

                    if (adjacentVerticeCapacity > 0 && !visited[i])
                    {
                        path[i] = current;
                        visited[i] = true;

                        if (i == targetVertice)
                            return path;

                        queue.Enqueue(i);
                    }
                }
            }

            return null;
        }
    }
}
