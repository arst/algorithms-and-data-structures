using AlgorithmsAndDataStructures.Algorithms.Graph.Common;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.Backtracking
{
    public class mColoringProblem
    {
        public bool CanBeColored(UndirectedGraph graph, int colors)
        {
            var vertices = graph.Vertices();
            var assignedColors = new int[vertices.Length];

            for (int i = 0; i < assignedColors.Length; i++)
            {
                assignedColors[i] = -1;
            }
            

            return CanColor(0, vertices, assignedColors, colors);
        }

        private bool CanColor(int currentVertice, List<int>[] vertices, int[] assignedColors, int colors)
        {
            // Try to assign each color to the current vertice.
            for (int i = 0; i < colors; i++)
            {
                // If it is safe to assign, assign and continue to adjacent non-colored vertices.
                if (IsSafeColor(currentVertice, vertices, assignedColors, i))
                {
                    assignedColors[currentVertice] = i;

                    if (IsAllColored(assignedColors))
                    {
                        return true;
                    }

                    foreach (var adjacentVertice in vertices[currentVertice])
                    {
                        // If color is already assigned on this path we don't need to color it.
                        if (assignedColors[adjacentVertice] != -1)
                        {
                            continue;
                        }

                        var canColor = CanColor(adjacentVertice, vertices, assignedColors, colors);

                        if (canColor)
                        {
                            return true;
                        }
                    }

                    assignedColors[currentVertice] = -1;
                }
            }

            return false;
        }

        private bool IsAllColored(int[] assignedColors)
        {
            return assignedColors.All(arg => arg > -1);
        }

        private bool IsSafeColor(int currentVertice, List<int>[] vertices, int[] assignedColors, int color)
        {
            foreach (var adjacentVertice in vertices[currentVertice])
            {
                if (assignedColors[adjacentVertice] == color)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
