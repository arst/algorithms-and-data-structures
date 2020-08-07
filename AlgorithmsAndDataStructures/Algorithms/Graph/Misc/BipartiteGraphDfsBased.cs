using System;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.Misc
{
    public class BipartiteGraphDfsBased
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
                    if (!DFS(graph, i, 1, colors))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool DFS(int[][] graph, int currentVertice, int color, int[] colors)
        {
            var flipColor = 1 ^ colors[currentVertice];
            colors[currentVertice] = color;

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
                        return false;
                    }
                }
                else
                {
                    var result = DFS(graph, i, flipColor, colors);

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
