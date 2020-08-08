using System;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.MinCut
{
    public class MinStCutNaive
    {
#pragma warning disable CA1822 // Mark members as static
        public List<Tuple<int, int>> GetStCut(int[][] graph)
#pragma warning restore CA1822 // Mark members as static
        {
            if (graph is null)
            {
                return new List<Tuple<int, int>>(0);
            }

            var residualGraph = new int[graph.Length][];
            var result = new List<Tuple<int, int>>();

            for (var i = 0; i < residualGraph.Length; i++)
            {
                residualGraph[i] = new int[graph.Length];

                for (var j = 0; j < graph.Length; j++)
                {
                    residualGraph[i][j] = graph[i][j];
                }
            }

            for (var i = 0; i < graph.Length; i++)
            {
                for (var j = 0; j < graph.Length; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    var sink = i;
                    var target = j;
                    bool hasPath;

                    do
                    {
                        var path = GetBfsPath(residualGraph, sink, target);
                        hasPath = path != null;

                        if (hasPath)
                        {
                            var delta = GetDelta(path, residualGraph, target);
                            var currentVertex = target;
                            var parent = path[currentVertex];

                            while (parent >= 0)
                            {
                                residualGraph[parent][currentVertex] = residualGraph[parent][currentVertex] - delta;
                                residualGraph[currentVertex][parent] = residualGraph[currentVertex][parent] + delta;

                                currentVertex = parent;
                                parent = path[currentVertex];
                            }
                        }

                    } while (hasPath);

                    var visited = new bool[graph.Length];

                    Dfs(sink, residualGraph, visited);

                    var tempResult = new List<Tuple<int, int>>();

                    for (var k = 0; k < graph.Length; k++)
                    {
                        var currentVertex = graph[k];

                        for (var z = 0; z < graph.Length; z++)
                        {
                            if (currentVertex[z] > 0 && visited[k] && !visited[z])
                            {
                                tempResult.Add(new Tuple<int, int>(k, z));
                            }
                        }
                    }

                    if (result.Count == 0 || tempResult.Count < result.Count)
                    {
                        if (tempResult.Count > 0)
                        {
                            result = tempResult;
                        }
                    }
                }
            }

            return result;
        }

        private static void Dfs(int v, IReadOnlyList<int[]> residualGraph, IList<bool> visited)
        {
            visited[v] = true;

            for (var i = 0; i < residualGraph[v].Length; i++)
            {
                if (!visited[i] && residualGraph[v][i] > 0)
                {
                    Dfs(i, residualGraph, visited);
                }
            }
        }

        private static int GetDelta(IReadOnlyList<int> path, IReadOnlyList<int[]> residualGraph, int targetVertex)
        {
            var delta = int.MaxValue;
            var currentVertex = targetVertex;
            var parent = path[currentVertex];

            while (parent >= 0)
            {
                delta = Math.Min(residualGraph[parent][currentVertex], delta);
                currentVertex = parent;
                parent = path[currentVertex];
            }

            return delta;
        }

        private static int[] GetBfsPath(IReadOnlyList<int[]> residualGraph, int sink, int targetVertex)
        {
            var queue = new Queue<int>();
            var visited = new bool[residualGraph.Count];
            var path = new int[residualGraph.Count];
            visited[sink] = true;
            path[sink] = -1;
            queue.Enqueue(sink);

            while (queue.Count > 0)
            {
                var currentVertex = queue.Dequeue();

                for (var i = 0; i < residualGraph[currentVertex].Length; i++)
                {
                    if (!visited[i] && residualGraph[currentVertex][i] > 0)
                    {
                        path[i] = currentVertex;
                        visited[i] = true;

                        if (i == targetVertex)
                        {
                            return path;
                        }

                        queue.Enqueue(i);
                    }
                }
            }

            return null;
        }
    }
}
