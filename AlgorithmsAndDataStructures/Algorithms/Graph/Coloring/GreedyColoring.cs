using System.Linq;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.Coloring
{
    // This algorithm can't guarantee the best coloring, but it can guarantee that we can color graph with at most d + 1 colors, where d is the max degree of vertice in the graph
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
            var adjacentColors = new bool[graph.Length];

            for (int currentVertice = 1; currentVertice < graph.Length; currentVertice++)
            {
                for (int adjacentVertice = 0; adjacentVertice < graph.Length; adjacentVertice++)
                {
                    if (graph[currentVertice][adjacentVertice] < 1 || colors[adjacentVertice] == -1)
                    {
                        continue;
                    }

                    if (colors[adjacentVertice] != -1)
                        adjacentColors[adjacentVertice] = true;
                }

                int color;

                for (color = 0; color < adjacentColors.Length; color++)
                {
                    if (!adjacentColors[color])
                    {
                        break;
                    }
                }

                colors[currentVertice] = color;

                adjacentColors = new bool[graph.Length];
            }
        }
    }
}
