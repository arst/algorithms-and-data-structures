using System;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.MaximumFlow
{
    public class FordFulkerson
    {
        // Actually, flow netwrok here is just a directed graph, though, it may as well be undirected.
        public int MaxFlow(int[][] flowNetwork)
        {
            var residualGraph = new int[flowNetwork.GetLength(0)][];
            var flows = new int[flowNetwork.GetLength(0)][];
            var isBackEdge = new bool[flowNetwork.GetLength(0)][];

            for (int i = 0; i < residualGraph.Length; i++)
            {
                residualGraph[i] = new int[flowNetwork[i].Length];
                isBackEdge[i] = new bool[flowNetwork[i].Length];
                flows[i] = new int[flowNetwork[i].Length];

                for (int j = 0; j < residualGraph[i].Length; j++)
                {
                    residualGraph[i][j] = flowNetwork[i][j];
                }
            }

            bool hasPath;

            do
            {
                var path = GetPath(residualGraph, 0, flowNetwork.Length - 1);
                hasPath = path != null;
                if (hasPath)
                {
                    var delta = GetDelta(residualGraph, path, flowNetwork.Length - 1);
                    EnrichFlows(flows, delta, path, isBackEdge);
                    RebuildResidualGraph(flowNetwork, flows, residualGraph, isBackEdge);
                }
               
            } while (hasPath);

            var maxFlow = 0;

            for (int i = 0; i < flowNetwork.Length; i++)
            {
                maxFlow += flows[0][i];
            }

            return maxFlow;
        }

        private void RebuildResidualGraph(int[][] flowNetwork, int[][] flows, int[][] residualGraph, bool[][] isBackEdge)
        {
            for (int i = 0; i < flowNetwork.Length; i++)
            {
                for (int j = 0; j < flowNetwork.Length; j++)
                {
                    var residualCapacity = flowNetwork[i][j] - flows[i][j];
                    residualGraph[i][j] = residualCapacity;

                    if (flows[i][j] > 0)
                    {
                        isBackEdge[j][i] = true;
                        residualGraph[j][i] = flows[i][j];
                    }
                }
            }
        }

        private void EnrichFlows(int[][] flows, int delta, int[] path, bool[][] isBackEdge)
        {
            var currentVertice = flows.Length - 1;
            var parent = path[currentVertice];

            while (parent >= 0)
            {
                var isBack = isBackEdge[parent][currentVertice];

                if (isBack)
                {
                    flows[parent][currentVertice] = flows[parent][currentVertice] - delta;
                }
                else
                {
                    flows[parent][currentVertice] = flows[parent][currentVertice] + delta;
                }

                currentVertice = parent;
                parent = path[currentVertice];
            }
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
