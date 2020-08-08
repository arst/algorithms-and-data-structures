using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.Misc
{
    public class BipartiteGraphDfsBased
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
                    if (!Dfs(graph, i, 1, colors))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private static bool Dfs(IReadOnlyList<int[]> graph, int currentVertex, int color, IList<int> colors)
        {
            var flipColor = 1 ^ colors[currentVertex];
            colors[currentVertex] = color;

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
                        return false;
                    }
                }
                else
                {
                    var result = Dfs(graph, i, flipColor, colors);

                    if (!result)
                    {
                        return false;
                    }
                }
            }
            
            return true;
        }
    }
}
