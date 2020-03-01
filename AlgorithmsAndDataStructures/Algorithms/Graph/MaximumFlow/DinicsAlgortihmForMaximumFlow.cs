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
                var startAt = new int[residualGraph.Length];

                do
                {
                    var visited = new bool[residualGraph.Length];

                    var delta = GetAugmetingPath(residualGraph, source, sink, visited, verticesLevels, startAt, Int32.MaxValue);
                    hasPath = delta > 0;
                    
                    if (hasPath)
                        flow += delta;
                    
                } while (hasPath);
            }

            return flow;
        }

        private int GetAugmetingPath(int[][] residualGraph, int current, int target, bool[] visited, int[] verticesLevels, int[] startAt, int flow)
        {
            if (current == target)
            {
                return flow;
            }

            for (int i = startAt[current]; i < residualGraph[current].Length; i++)
            {
                if (residualGraph[current][i] < 1)
                {
                    continue;
                }
                // We only go towards the target node, not backwards.
                if (!visited[i] && verticesLevels[current] < verticesLevels[i])
                {
                    visited[i] = true;

                    var delta = GetAugmetingPath(residualGraph, i, target, visited, verticesLevels, startAt, Math.Min(flow, residualGraph[current][i]));
                    // We eliminate dead-end paths, since we can't achieve target nodes through them.
                    startAt[current] = i;

                    if (delta > 0)
                    {
                        // Reduce capacity of the nodes along the path with delta.
                        residualGraph[current][i] = residualGraph[current][i] - delta;
                        // Create back-node to allow flow undo.
                        residualGraph[i][current] = residualGraph[i][current] + delta;
                        return delta;
                    }
                }
            }

            return 0;
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

                    // This checks that vertices is not visited and tha this is a forward edge.
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
