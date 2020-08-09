using System;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.MaximumFlow
{
    // Inspired by https://algs4.cs.princeton.edu/home/
    public class HopcroftKarp
    {
#pragma warning disable CA1822 // Mark members as static
        public int GetMaxMatching(int[][] graph)
#pragma warning restore CA1822 // Mark members as static
        {
            if (graph is null)
            {
                return default;
            }

            var matching = 0;
            var distance = new int[graph.Length];
            var pairs = new int[graph.Length];
            Reset(pairs);

            var leftSideVertices = BipartiteGraph(graph);

            while (HasAugmentingPath(graph, leftSideVertices, pairs, distance))
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
                        var currentVertex = path.Peek();
                        
                        // Move up the stack, no more edges in level graph leaving currentVertex.
                        if (position[currentVertex] == graph.Length)
                        {
                            path.Pop();
                        }
                        else
                        {
                            var isEdgeExists = graph[currentVertex][position[currentVertex]] > 0;
                            var w = position[currentVertex];
                            position[currentVertex]++;

                            if (!isEdgeExists)
                            {
                                continue;
                            }

                            // Process edge currentVertex-position only if it is an edge in level graph.
                            if (!IsLevelGraphEdge(leftSideVertices, pairs, distance, currentVertex, w))
                            {
                                continue;
                            }

                            // add w to augmenting path.
                            path.Push(w);

                            // Augmenting path found: update the matching.
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

        private static bool IsLevelGraphEdge(ICollection<int> leftSetVertices, IReadOnlyList<int> pairs, IReadOnlyList<int> distance, int from, int to)
        {
            return (distance[to] == distance[from] + 1) && IsResidualGraphEdge(leftSetVertices, pairs, from, to);
        }

        // Use BFS to find an augmenting path.
        private static bool HasAugmentingPath(IReadOnlyList<int[]> graph, ICollection<int> leftSideVertices, IReadOnlyList<int> pairs, IList<int> distance)
        {
            var visited = new bool[graph.Count];

            for (var i = 0; i < distance.Count; i++)
            {
                distance[i] = int.MaxValue;
            }

            var queue = new Queue<int>();

            for (var i = 0; i < graph.Count; i++)
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
                var currentVertex = queue.Dequeue();
                for (var i = 0; i < graph.Count; i++)
                {
                    if (graph[currentVertex][i] < 1)
                    {
                        continue;
                    }

                    // Forward edge not in matching or backwards edge in matching?
                    if (IsResidualGraphEdge(leftSideVertices, pairs, currentVertex, i))
                    {
                        if (!visited[i])
                        {
                            distance[i] = distance[currentVertex] + 1;
                            visited[i] = true;

                            if (pairs[i] == -1)
                            {
                                hasAugmentingPath = true;
                            }

                            // Once an augmenting path is discovered, stop en-queuing new vertices since no vertex on same side will be marked if its shortest path distance longer.
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
        private static bool IsResidualGraphEdge(ICollection<int> leftSideVertices, IReadOnlyList<int> pairs, int from, int to)
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

        private static void Reset(IList<int> input)
        {
            for (var i = 0; i < input.Count; i++)
            {
                input[i] = -1;
            }
        }

        private static HashSet<int> BipartiteGraph(IReadOnlyList<int[]> graph)
        {
            var colors = new int[graph.Count];
            const int startColor = 0;

            for (var i = 0; i < colors.Length; i++)
            {
                colors[i] = -1;
            }

            for (var i = 0; i < graph.Count; i++)
            {
                if (colors[i] == -1)
                {
                    BfsColoring(graph, colors, i, startColor);
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

        private static void BfsColoring(IReadOnlyList<int[]> graph, IList<int> colors, int startVertex, int startColor)
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
