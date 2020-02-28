using System;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.MaximumFlow
{
    public class STCutFordFulkersonBased
    {
        public List<Tuple<int, int>> GetSTCut(int[][] graph)
        {
            var residualGraph = new int[graph.Length][];

            for (int i = 0; i < residualGraph.Length; i++)
            {
                residualGraph[i] = new int[graph.Length];

                for (int j = 0; j < graph.Length; j++)
                {
                    residualGraph[i][j] = graph[i][j];
                }
            }

            bool hasPath;
            int[] path;
            var targetVertice = graph.Length - 1;
            var maxFlow = 0;

            do
            {
                path = GetBFSPath(residualGraph, targetVertice);
                hasPath = path != null;

                if (hasPath)
                {
                    var delta = GetDelta(path, residualGraph, targetVertice);
                    maxFlow += delta;
                    var currentVertice = graph.Length - 1;
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

            DFS(0, residualGraph, visited);

            var result = new List<Tuple<int, int>>();

            for (int i = 0; i < graph.Length; i++)
            {
                var currentVertice = graph[i];

                for (int j = 0; j < graph.Length; j++)
                {
                    if (currentVertice[j] > 0 && visited[i] && !visited[j])
                    {
                        result.Add(new Tuple<int, int>(i,j));
                    }
                }
            }

            return result;
        }

        private void DFS(int v, int[][] residualGraph, bool[] visited)
        {
            visited[v] = true;

            for (int i = 0; i < residualGraph[v].Length; i++)
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

        private int[] GetBFSPath(int[][] residualGraph, int targetVertice)
        {
            var queue = new Queue<int>();
            var visited = new bool[residualGraph.Length];
            var path = new int[residualGraph.Length];
            visited[0] = true;
            path[0] = -1;
            queue.Enqueue(0);

            while (queue.Count > 0)
            {
                var currenntVertice = queue.Dequeue();

                for (int i = 0; i < residualGraph[currenntVertice].Length; i++)
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
