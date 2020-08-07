using System;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.Misc
{
    public class BipartiteGraphBfsBased
    {
        public bool IsBipartite(int[][] graph)
        {
            var colors = new int[graph.Length];
            for (var i = 0; i < colors.Length; i++)
            {
                colors[i] = -1;
            }

            for (var i = 0; i < colors.Length; i++)
            {
                if (colors[i] == -1)
                {
                    if (!BFS(graph, i, 1, colors))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool BFS(int[][] graph, int currentVertice, int startColor, int[] colors)
        {
            var queue = new Queue<int>();
            queue.Enqueue(currentVertice);
            colors[currentVertice] = startColor;

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                var adjacentColor = 1 ^ colors[current];

                for (var i = 0; i < graph.Length; i++)
                {
                    if (graph[current][i] < 1)
                    {
                        continue;
                    }

                    if (colors[i] != -1)
                    {
                        if (colors[i] == colors[current])
                        {
                            return false;
                        }
                    }
                    else
                    {
                        queue.Enqueue(i);
                        colors[i] = adjacentColor;
                    }

                    
                }
            }

            return true;
        }
    }
}
