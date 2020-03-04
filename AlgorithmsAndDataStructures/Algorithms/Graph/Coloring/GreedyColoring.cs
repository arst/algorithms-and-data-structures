using System.Linq;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.Coloring
{
    public class GreedyColoring
    {
        public int Color(int[][] graph)
        {
            var colors = new int[graph.Length];

            for (int i = 0; i < colors.Length; i++)
            {
                colors[i] = -1;
            }

            Color(graph, colors);

            return colors.Max();
        }

        private void Color(int[][] graph, int[] colors)
        {
            colors[0] = 0;

            for (int i = 1; i < graph.Length; i++)
            {
                var minAdjacentColor = int.MaxValue;
                var maxAdjacentColor = int.MinValue;

                for (int j = 0; j < graph.Length; j++)
                {
                    if (graph[i][j] < 1 || colors[j] == -1)
                    {
                        continue;
                    }

                    if (colors[j] > maxAdjacentColor)
                    {
                        maxAdjacentColor = colors[j];
                    }

                    if (colors[j] < minAdjacentColor)
                    {
                        minAdjacentColor = colors[j];
                    }
                }

                // No colored adjacent veetices, color with lowest available color
                if (minAdjacentColor == int.MaxValue)
                {
                    colors[i] = 0;
                }
                else if (minAdjacentColor > 0)
                {
                    colors[i] = minAdjacentColor - 1;
                }
                else
                {
                    colors[i] = maxAdjacentColor + 1;
                }
            }
        }
    }
}
