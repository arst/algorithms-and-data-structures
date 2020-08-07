using System;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.MaximumFlow
{
    // Insipred by https://algs4.cs.princeton.edu/home/
    public class HopcroftKarp
    {
        public int GetMaxMathcing(int[][] graph)
        {
            var matching = 0;
            var distance = new int[graph.Length];
            var pairs = new int[graph.Length];
            Reset(pairs);

            var leftSideVertices = BipartiteGraph(graph);

            while (HasAugmetingPath(graph, leftSideVertices, pairs, distance))
            {
                for (var i = 0; i < graph.Length; i++)
                {
                    var position = new int[graph.Length];

                    if (pairs[i] != -1 || !leftSideVertices.Contains(i))
                    {
                        continue;
                    }

                    var path = new Stack<int>();
                    path.Push(i);

                    while (path.Count > 0)
                    {
                        var currentVertice = path.Peek();
                        
                        // Move up the stack, no more edges in level graph leaving currentVertice
                        if (position[currentVertice] == graph.Length)
                        {
                            path.Pop();
                        }
                        else
                        {
                            var isEdgeExists = graph[currentVertice][position[currentVertice]] > 0;
                            var w = position[currentVertice];
                            position[currentVertice]++;

                            if (!isEdgeExists)
                            {
                                continue;
                            }

                            // Process edge currentVertice-position only if it is an edge in level graph
                            if (!IsLevelGraphEdge(graph, leftSideVertices, pairs, distance, currentVertice, w))
                            {
                                continue;
                            }

                            // add w to augmenting path
                            path.Push(w);

                            // Augmenting path found: update the matching
                            if (pairs[w] == -1)
                            {
                                while (path.Count > 0)
                                {
                                    var x = path.Pop();
                                    var y = path.Pop();
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

        private bool IsLevelGraphEdge(int[][] graph, HashSet<int> leftSetVertices, int[] pairs, int[] distance, int i, int w)
        {
            return (distance[w] == distance[i] + 1) && IsResidualGraphEdge(graph, leftSetVertices, pairs, i, w);
        }

        // Use BFS to find an augmenting path.
        private bool HasAugmetingPath(int[][] graph, HashSet<int> leftSideVertices, int[] pairs, int[] distance)
        {
            var visited = new bool[graph.Length];

            for (var i = 0; i < distance.Length; i++)
            {
                distance[i] = int.MaxValue;
            }

            var queue = new Queue<int>();

            for (var i = 0; i < graph.Length; i++)
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
                var currentVertice = queue.Dequeue();
                for (var i = 0; i < graph.Length; i++)
                {
                    if (graph[currentVertice][i] < 1)
                    {
                        continue;
                    }

                    // Forward edge not in matching or backwards edge in matching?
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

                            // Once an augmenting path is disovered, stop enquing new vertices since no vertex on same side will be marked if its shortest path distance longer.
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

        // Is the edge from-to a forward edge not in the matching or a reverse edge in the matching?
        private bool IsResidualGraphEdge(int[][] graph, HashSet<int> leftSideVertices, int[] pairs, int from, int to)
        {
            // from isn't matched with to so forward edge isn't in the matching
            if ((pairs[from] != to) && leftSideVertices.Contains(from))
            {
                return true;
            }
            // from is matched with to but from is not in the let subset, so we have a reverse edge in the matching
            if ((pairs[from] == to) && !leftSideVertices.Contains(from))
            {
                return true;
            }

            return false;
        }

        private void Reset(int[] input)
        {
            for (var i = 0; i < input.Length; i++)
            {
                input[i] = -1;
            }
        }

        private HashSet<int> BipartiteGraph(int[][] graph)
        {
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
                    BFSColoring(graph, colors, i, startColor);
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

            return leftSetVertices;
        }

        private void BFSColoring(int[][] graph, int[] colors, int startVertice, int startColor)
        {
            var queue = new Queue<int>();
            colors[startVertice] = startColor;
            queue.Enqueue(startVertice);

            while (queue.Count > 0)
            {
                var currentVertice = queue.Dequeue();

                for (var i = 0; i < graph.Length; i++)
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
