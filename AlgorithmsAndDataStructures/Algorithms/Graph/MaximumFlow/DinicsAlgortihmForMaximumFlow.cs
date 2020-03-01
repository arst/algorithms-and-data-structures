using System;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.MaximumFlow
{
    public class DinicsAlgortihmForMaximumFlow
    {
        public int MaxFlow(int[][] flowNetwork, int source, int sink)
        {
            var residualGraph = new int[flowNetwork.GetLength(0)][];
            var flow = 0;
            var verticesLevels = new int[flowNetwork.Length];

            for (int i = 0; i < residualGraph.Length; i++)
            {
                residualGraph[i] = new int[flowNetwork[i].Length];

                for (int j = 0; j < residualGraph[i].Length; j++)
                {
                    residualGraph[i][j] = flowNetwork[i][j];
                }
            }

            while (LeveledBfs(source, sink, residualGraph, verticesLevels, flowNetwork))
            {
                bool hasPath;

                do
                {
                    var visited = new bool[residualGraph.Length];
                    var path = new int[residualGraph.Length];
                    Reset(path);

                    // Do simple DFS and record the path from source to sink if such path exists.
                    GetDfsPath(residualGraph, source, sink, path, visited, verticesLevels);

                    hasPath = path[sink] >= 0;

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
            }

            return flow;
        }

        private int GetDelta(int[][] residualGraph, int[] path, int targetVertice)
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

        private int[] GetDfsPath(int[][] residualGraph, int current, int target, int[] path, bool[] visited, int[] verticesLevels)
        {
            if (current == target)
            {
                return path;
            }

            for (int i = 0; i < residualGraph[current].Length; i++)
            {
                if (residualGraph[current][i] < 1)
                {
                    continue;
                }

                if (!visited[i] && verticesLevels[current] < verticesLevels[i])
                {
                    path[i] = current;
                    visited[i] = true;

                    GetDfsPath(residualGraph, i, target, path, visited, verticesLevels);
                   
                    if (path[target] > -1)
                    {
                        return path;
                    }
                }
            }

            return path;
        }

        private bool LeveledBfs(int currentVertice, int targetVertice, int[][] residualGraph, int[] verticesLevels, int[][] flowNetwork)
        {
            var queue = new Queue<int>();
            Reset(verticesLevels);
            verticesLevels[currentVertice] = 0;
            queue.Enqueue(currentVertice);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                for (int i = 0; i < residualGraph[current].Length; i++)
                {
                    if (residualGraph[current][i] < 1)
                    {
                        continue;
                    }

                    if (verticesLevels[i] < 0 &&  flowNetwork[current][i] - residualGraph[current][i] >= 0)
                    {
                        verticesLevels[i] = verticesLevels[current] + 1;
                        queue.Enqueue(i);
                    }
                }
            }

            return verticesLevels[targetVertice] > -1;
        }

        private static void Reset(int[] verticesLevels)
        {
            for (int i = 0; i < verticesLevels.Length; i++)
            {
                verticesLevels[i] = -1;
            }
        }
    }
}
