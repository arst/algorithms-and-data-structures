using System;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.MaximumFlow
{
    public class MaximumBiPartiteMatchingFordFulkersonBased
    {
#pragma warning disable CA1822 // Mark members as static
        public int MaxMatching(int[][] graph)
#pragma warning restore CA1822 // Mark members as static
        {
            if (graph is null)
            {
                return default;
            }

            var colors = new int[graph.Length];
            const int startColor = 0;

            for (var i = 0; i < colors.Length; i++)
            {
                colors[i] = -1;
            }

            for (var i = 0; i < graph.Length; i++)
            {
                if (colors[i] == -1)
                {
                    Bfs(graph, colors, i, startColor);
                }
            }

            var leftSetVertices = new HashSet<int>();

            for (var i = 0; i < colors.Length; i++)
            {
                if (colors[i] == 0)
                {
                    leftSetVertices.Add(i);
                }
            }

            var flowNetwork = BuildFlowNetwork(graph, leftSetVertices);
            var residualGraph = new int[flowNetwork.Length][];

            for (var i = 0; i < residualGraph.Length; i++)
            {
                residualGraph[i] = new int[flowNetwork[i].Length];

                for (var j = 0; j < residualGraph[i].Length; j++)
                {
                    residualGraph[i][j] = flowNetwork[i][j];
                }
            }

            bool hasPath;
            var flow = 0;
            const int source = 0;
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

        private static int GetPath(IReadOnlyList<int[]> residualGraph, int currentVertex, int targetVertex, IList<bool> visited, int flow)
        {
            if (currentVertex == targetVertex)
            {
                return flow;
            }

            visited[currentVertex] = true;

            for (var i = 0; i < residualGraph.Count; i++)
            {
                if (residualGraph[currentVertex][i] > 0 && !visited[i])
                {
                    var delta = GetPath(residualGraph, i, targetVertex, visited, Math.Min(flow, residualGraph[currentVertex][i]));

                    if (delta > 0)
                    {
                        residualGraph[currentVertex][i] = residualGraph[currentVertex][i] - delta;
                        residualGraph[i][currentVertex] = residualGraph[i][currentVertex] + delta;
                        return delta;
                    }
                }
            }

            return 0;
        }

        private static int[][] BuildFlowNetwork(IReadOnlyList<int[]> graph, ICollection<int> leftSetVertices)
        {
            var flowNetwork = new int[graph.Count + 2][];
            flowNetwork[0] = new int[flowNetwork.Length];
            flowNetwork[^1] = new int[flowNetwork.Length];

            for (var i = 0; i < graph.Count; i++)
            {
                var currentVertex = i + 1;
                var isLeftSideVertex = leftSetVertices.Contains(i);
                flowNetwork[currentVertex] = new int[flowNetwork.Length];

                if (isLeftSideVertex)
                {
                    flowNetwork[0][currentVertex] = 1;
                }

                for (var j = 0; j < graph.Count; j++)
                {
                    flowNetwork[currentVertex][j + 1] = graph[i][j];
                }

                if (!isLeftSideVertex)
                {
                    flowNetwork[currentVertex][flowNetwork.Length - 1] = 1;
                }
            }

            return flowNetwork;
        }

        private static void Bfs(IReadOnlyList<int[]> graph, IList<int> colors, int startVertex, int startColor)
        {
            var queue = new Queue<int>();
            colors[startVertex] = startColor;
            queue.Enqueue(startVertex);

            while (queue.Count > 0)
            {
                var currentVertex = queue.Dequeue();

                for (var i = 0; i < graph.Count; i++)
                {
                    if (graph[currentVertex][i] < 1)
                    {
                        continue;
                    }

                    if (colors[i] != -1)
                    {
                        if (colors[i] == colors[currentVertex])
                        {
                            throw new Exception("Graph is not bipartite.");
                        }
                    }
                    else
                    {
                        colors[i] = 1 ^ colors[currentVertex];
                        queue.Enqueue(i);
                    }
                }
            }
        }
    }
}
