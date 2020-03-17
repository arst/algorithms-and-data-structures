using System;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.MaximumFlow
{
    public class FordFulkersonWithCapacityHeuristic
    {
        // Actually, flow netwrok here is just a directed graph, though, it may as well be undirected.
        public int MaxFlow(int[][] flowNetwork)
        {
            var residualGraph = new int[flowNetwork.GetLength(0)][];
            var flow = 0;
            var maxEdgeWeight = int.MinValue;
            
            for (int i = 0; i < residualGraph.Length; i++)
            {
                residualGraph[i] = new int[flowNetwork[i].Length];

                for (int j = 0; j < residualGraph[i].Length; j++)
                {
                    residualGraph[i][j] = flowNetwork[i][j];

                    if (flowNetwork[i][j] > maxEdgeWeight)
                    {
                        maxEdgeWeight = flowNetwork[i][j];
                    }
                }
            }

            var delta = 1;

            while (delta * 2 < maxEdgeWeight)
            {
                delta *= 2;
            }

            while (delta > 0)
            {
                bool hasPath;
                var sink = flowNetwork.Length - 1;
                var source = 0;

                do
                {
                    var path = new int[residualGraph.Length];
                    var visited = new bool[residualGraph.Length];
                    path[source] = -1;
                    visited[source] = true;
                    // Do simple DFS and record the path from source to sink if such path exists.
                    path = GetPath(residualGraph, source, sink, path, visited, delta);
                    hasPath = path != null;

                    if (hasPath)
                    {
                        // Get minimum available capacity in the augmenting path.
                        var capacity = GetDelta(residualGraph, path, sink);
                        // Augment max flow with value of delta since we were able to find augmenting path. 
                        flow += capacity;

                        // Follow the path until we rich the source.
                        var currentVertice = sink;
                        var parent = path[currentVertice];

                        while (parent >= 0)
                        {
                            // Reduce capacity of the nodes along the path with delta.
                            residualGraph[parent][currentVertice] = residualGraph[parent][currentVertice] - capacity;
                            // Create back-node to allow flow undo.
                            residualGraph[currentVertice][parent] = residualGraph[currentVertice][parent] + capacity;

                            currentVertice = parent;
                            parent = path[currentVertice];
                        }
                    }

                } while (hasPath);

                delta /= 2;
            }

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

        private int[] GetPath(int[][] residualGraph, int currentVertice, int targetVertice, int[] path, bool[] visited, int delta)
        {

            for (int i = 0; i < residualGraph[currentVertice].Length; i++)
            {
                int adjacentVerticeCapacity = residualGraph[currentVertice][i];

                if (adjacentVerticeCapacity > 0 && !visited[i] && adjacentVerticeCapacity >= delta)
                {
                    path[i] = currentVertice;
                    visited[i] = true;

                    if (i == targetVertice)
                        return path;

                    var tempPath = GetPath(residualGraph, i, targetVertice, path, visited, delta);

                    if (tempPath != null)
                    {
                        return tempPath;
                    }
                }
            }

            return null;
        }
    }
}
