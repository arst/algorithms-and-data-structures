using System;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.MaximumFlow
{
    public class MaximumBirpartiteMatchingFordFulkersonBased
    {
        public int MaxMatching(int[][] graph)
        {
            var colors = new int[graph.Length];
            const int startColor = 0;

            for (int i = 0; i < colors.Length; i++)
            {
                colors[i] = -1;
            }

            for (int i = 0; i < graph.Length; i++)
            {
                if (colors[i] == -1)
                {
                    BFS(graph, colors, i, startColor);
                }
            }

            var leftSetVertices = new HashSet<int>();

            for (int i = 0; i < colors.Length; i++)
            {
                if (colors[i] == 0)
                {
                    leftSetVertices.Add(i);
                }
            }

            var flowNetwork = BuildFlowNetwork(graph, leftSetVertices);
            var residualGraph = new int[flowNetwork.Length][];

            for (int i = 0; i < residualGraph.Length; i++)
            {
                residualGraph[i] = new int[flowNetwork[i].Length];

                for (int j = 0; j < residualGraph[i].Length; j++)
                {
                    residualGraph[i][j] = flowNetwork[i][j];
                }
            }

            var hasPath = false;
            var flow = 0;
            var source = 0;
            var sink = flowNetwork.Length - 1;

            do
            {
                var visited = new bool[residualGraph.Length];
                var delta = GetPath(residualGraph, source, sink, visited, int.MaxValue);
                hasPath = delta > 0;
                flow += delta;
            } while (hasPath);

            return flow;
        }

        private int GetPath(int[][] residualGraph, int currentVertice, int targetVertice, bool[] visited, int flow)
        {
            if (currentVertice == targetVertice)
            {
                return flow;
            }

            visited[currentVertice] = true;

            for (int i = 0; i < residualGraph.Length; i++)
            {
                if (residualGraph[currentVertice][i] > 0 && !visited[i])
                {
                    var delta = GetPath(residualGraph, i, targetVertice, visited, Math.Min(flow, residualGraph[currentVertice][i]));

                    if (delta > 0)
                    {
                        residualGraph[currentVertice][i] = residualGraph[currentVertice][i] - delta;
                        residualGraph[i][currentVertice] = residualGraph[i][currentVertice] + delta;
                        return delta;
                    }
                }
            }

            return 0;
        }

        private int[][] BuildFlowNetwork(int[][] graph, HashSet<int> leftSetVertices)
        {
            var flowNwetwork = new int[graph.Length + 2][];
            flowNwetwork[0] = new int[flowNwetwork.Length];
            flowNwetwork[flowNwetwork.Length - 1] = new int[flowNwetwork.Length];

            for (int i = 0; i < graph.Length; i++)
            {
                var currentVertice = i + 1;
                var isLeftSideVertice = leftSetVertices.Contains(i);
                flowNwetwork[currentVertice] = new int[flowNwetwork.Length];

                if (isLeftSideVertice)
                {
                    flowNwetwork[0][currentVertice] = 1;
                }

                for (int j = 0; j < graph.Length; j++)
                {
                    flowNwetwork[currentVertice][j + 1] = graph[i][j];
                }

                if (!isLeftSideVertice)
                {
                    flowNwetwork[currentVertice][flowNwetwork.Length - 1] = 1;
                }
            }

            return flowNwetwork;
        }

        private void BFS(int[][] graph, int[] colors, int startVertice, int startColor)
        {
            var queue = new Queue<int>();
            colors[startVertice] = startColor;
            queue.Enqueue(startVertice);

            while (queue.Count > 0)
            {
                var currentVertice = queue.Dequeue();

                for (int i = 0; i < graph.Length; i++)
                {
                    if (graph[currentVertice][i] < 1)
                    {
                        continue;
                    }

                    if (colors[i] != -1)
                    {
                        if (colors[i] == colors[currentVertice])
                        {
                            throw new Exception("Graph is not bipartite.");
                        }
                    }
                    else
                    {
                        colors[i] = 1 ^ colors[currentVertice];
                        queue.Enqueue(i);
                    }
                }
            }
        }
    }
}
