using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.Coloring
{
    // This algorithm can't guarantee the best coloring, but it can guarantee that we can color graph with at most d + 1 colors, where d is the max degree of vertex in the graph.
    public class GreedyColoring
    {
#pragma warning disable CA1822 // Mark members as static
        public int Color(int[][] graph)
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

            Color(graph, colors);

            return colors.Max();
        }

        private static void Color(IReadOnlyList<int[]> graph, IList<int> colors)
        {
            colors[0] = 0;
            var adjacentColors = new bool[graph.Count];

            for (var currentVertex = 1; currentVertex < graph.Count; currentVertex++)
            {
                for (var adjacentVertex = 0; adjacentVertex < graph.Count; adjacentVertex++)
                {
                    if (graph[currentVertex][adjacentVertex] < 1 || colors[adjacentVertex] == -1)
                    {
                        continue;
                    }

                    adjacentColors[colors[adjacentVertex]] = true;
                }

                int color;

                for (color = 0; color < adjacentColors.Length; color++)
                {
                    if (!adjacentColors[color])
                    {
                        break;
                    }
                }

                colors[currentVertex] = color;

                adjacentColors = new bool[graph.Count];
            }
        }
    }
}
