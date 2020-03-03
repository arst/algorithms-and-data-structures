using System;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.MaximumFlow
{
    public class HopcroftKarp
    {
        public int GetMaxMathcing(int[][] graph)
        {
            var distance = new int[graph.Length];
            var pairs = new int[graph.Length];

            for (int i = 0; i < pairs.Length; i++)
            {
                pairs[i] = -1;
            }
            var matching = 0;

            var leftSideVertices = BipartiteGraph(graph);

            while (HasAugmetingPath(graph, leftSideVertices, pairs, distance))
            {
                for (int i = 0; i < graph.Length; i++)
                {
                    var position = new int[graph.Length];

                    if (pairs[i] != -1 || !leftSideVertices.Contains(i))
                    {
                        continue;
                    }

                    Stack<int> path = new Stack<int>();
                    path.Push(i);

                    while (path.Count > 0)
                    {
                        int currentVertice = path.Peek();

                        // retreat, no more edges in level graph leaving v
                        if (position[currentVertice] == graph.Length)
                        {
                            path.Pop();
                        }
                        // advance
                        else
                        {
                            // process edge v-w only if it is an edge in level graph
                            var isEdgeExists = graph[currentVertice][position[currentVertice]] > 0;
                            int w = position[currentVertice];
                            position[currentVertice]++;

                            if (!isEdgeExists)
                            {
                                continue;
                            }

                            if (!IsLevelGraphEdge(graph, leftSideVertices, pairs, distance, currentVertice, w))
                            {
                                continue;
                            }

                            // add w to augmenting path
                            path.Push(w);

                            // augmenting path found: update the matching
                            if (pairs[w] == -1)
                            {
                                while (path.Count > 0)
                                {
                                    int x = path.Pop();
                                    int y = path.Pop();
                                    pairs[x] = y;
                                    pairs[y] = x;
                                }
                                matching++;
                            }
                        }
                    }
                }
            }

            return matching;
        }

        private HashSet<int> BipartiteGraph(int[][] graph)
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
                    BFSColoring(graph, colors, i, startColor);
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

            return leftSetVertices;
        }

        private bool IsLevelGraphEdge(int[][] graph, HashSet<int> leftSetVertices, int[] pairs, int[] distance, int i, int w)
        {
            return (distance[w] == distance[i] + 1) && IsResidualGraphEdge(graph, leftSetVertices, pairs, i, w);
        }

        private bool HasAugmetingPath(int[][] graph, HashSet<int> leftSideVertices, int[] pairs, int[] distance)
        {
            var visited = new bool[graph.Length];

            for (int i = 0; i < distance.Length; i++)
            {
                distance[i] = int.MaxValue;
            }

            var queue = new Queue<int>();

            for (int i = 0; i < graph.Length; i++)
            {
                if (leftSideVertices.Contains(i) && pairs[i] == -1)
                {
                    queue.Enqueue(i);
                    visited[i] = true;
                    distance[i] = 0;
                }
            }

            var hasAugmentingPath = false;

            while (queue.Count > 0)
            {
                int currentVertice = queue.Dequeue();
                for (int i = 0; i < graph.Length; i++)
                {
                    if (graph[currentVertice][i] < 1)
                    {
                        continue;
                    }

                    // forward edge not in matching or backwards edge in matching
                    if (IsResidualGraphEdge(graph, leftSideVertices, pairs, currentVertice, i))
                    {
                        if (!visited[i])
                        {
                            distance[i] = distance[currentVertice] + 1;
                            visited[i] = true;

                            if (pairs[i] == -1)
                            {
                                hasAugmentingPath = true;
                            }

                            // stop enqueuing vertices once an alternating path has been discovered
                            // (no vertex on same side will be marked if its shortest path distance longer)
                            if (!hasAugmentingPath)
                            {
                                queue.Enqueue(i);
                            }
                        }
                    }
                }
            }

            return hasAugmentingPath;
        }

        // is the edge v-w a forward edge not in the matching or a reverse edge in the matching?
        private bool IsResidualGraphEdge(int[][] graph, HashSet<int> leftSideVertices, int[] pairs, int v, int w)
        {
            if ((pairs[v] != w) && leftSideVertices.Contains(v))
            {
                return true;
            }
            if ((pairs[v] == w) && !leftSideVertices.Contains(v))
            {
                return true;
            }

            return false;
        }


        private void BFSColoring(int[][] graph, int[] colors, int startVertice, int startColor)
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
