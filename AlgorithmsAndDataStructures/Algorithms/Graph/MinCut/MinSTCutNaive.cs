using System;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.MaximumFlow
{
    public class MinSTCutNaive
    {
        public List<Tuple<int, int>> GetSTCut(int[][] graph)
        {
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
                    int[] path;

                    do
                    {
                        path = GetBFSPath(residualGraph, sink, target);
                        hasPath = path != null;

                        if (hasPath)
                        {
                            var delta = GetDelta(path, residualGraph, target);
                            var currentVertice = target;
                            var parent = path[currentVertice];

                            while (parent >= 0)
                            {
                                residualGraph[parent][currentVertice] = residualGraph[parent][currentVertice] - delta;
                                residualGraph[currentVertice][parent] = residualGraph[currentVertice][parent] + delta;

                                currentVertice = parent;
                                parent = path[currentVertice];
                            }
                        }

                    } while (hasPath);

                    var visited = new bool[graph.Length];

                    DFS(sink, residualGraph, visited);

                    var tempResult = new List<Tuple<int, int>>();

                    for (var k = 0; k < graph.Length; k++)
                    {
                        var currentVertice = graph[k];

                        for (var z = 0; z < graph.Length; z++)
                        {
                            if (currentVertice[z] > 0 && visited[k] && !visited[z])
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

        private void DFS(int v, int[][] residualGraph, bool[] visited)
        {
            visited[v] = true;

            for (var i = 0; i < residualGraph[v].Length; i++)
            {
                if (!visited[i] && residualGraph[v][i] > 0)
                {
                    DFS(i, residualGraph, visited);
                }
            }
        }

        private int GetDelta(int[] path, int[][] residualGraph, int targetVertice)
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

        private int[] GetBFSPath(int[][] residualGraph, int sink, int targetVertice)
        {
            var queue = new Queue<int>();
            var visited = new bool[residualGraph.Length];
            var path = new int[residualGraph.Length];
            visited[sink] = true;
            path[sink] = -1;
            queue.Enqueue(sink);

            while (queue.Count > 0)
            {
                var currenntVertice = queue.Dequeue();

                for (var i = 0; i < residualGraph[currenntVertice].Length; i++)
                {
                    if (!visited[i] && residualGraph[currenntVertice][i] > 0)
                    {
                        path[i] = currenntVertice;
                        visited[i] = true;

                        if (i == targetVertice)
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
