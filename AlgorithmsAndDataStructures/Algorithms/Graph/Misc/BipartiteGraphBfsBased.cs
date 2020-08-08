using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.Misc
{
    public class BipartiteGraphBfsBased
    {
#pragma warning disable CA1822 // Mark members as static
        public bool IsBipartite(int[][] graph)
#pragma warning restore CA1822 // Mark members as static
        {
            if (graph is null)
            {
                return default;
            }

            var colors = new int[graph.Length];
            for (var i = 0; i < colors.Length; i++)
            {
                colors[i] = -1;
            }

            for (var i = 0; i < colors.Length; i++)
            {
                if (colors[i] == -1)
                {
                    if (!Bfs(graph, i, 1, colors))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private static bool Bfs(IReadOnlyList<int[]> graph, int currentVertex, int startColor, IList<int> colors)
        {
            var queue = new Queue<int>();
            queue.Enqueue(currentVertex);
            colors[currentVertex] = startColor;

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                var adjacentColor = 1 ^ colors[current];

                for (var i = 0; i < graph.Count; i++)
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
