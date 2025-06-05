using System.Collections.Generic;
using System.Linq;
using AlgorithmsAndDataStructures.Algorithms.Graph.Common;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.Backtracking;

public class MColoringProblem
{
#pragma warning disable CA1822 // Mark members as static
    public bool CanColor(UndirectedGraph graph, int colors)
#pragma warning restore CA1822 // Mark members as static
    {
        if (graph is null) return default;

        var vertices = graph.Vertices();
        var assignedColors = new int[vertices.Length];

        for (var i = 0; i < assignedColors.Length; i++) assignedColors[i] = -1;


        const int bootstrapVertex = 0;
        return CanColor(bootstrapVertex, vertices, assignedColors, colors);
    }

    private static bool CanColor(int currentVertex, IReadOnlyList<List<int>> vertices, int[] assignedColors, int colors)
    {
        // Try to assign each color to the current vertex.
        for (var i = 0; i < colors; i++)
            // If it is safe to assign, assign and continue to adjacent non-colored vertices.
            if (IsSafeColor(currentVertex, vertices, assignedColors, i))
            {
                assignedColors[currentVertex] = i;

                if (IsAllColored(assignedColors)) return true;

                foreach (var adjacentVertex in vertices[currentVertex])
                {
                    // If color is already assigned on this path we don't need to color it.
                    if (assignedColors[adjacentVertex] != -1) continue;

                    var canColor = CanColor(adjacentVertex, vertices, assignedColors, colors);

                    if (canColor) return true;
                }

                assignedColors[currentVertex] = -1;
            }

        return false;
    }

    private static bool IsAllColored(IEnumerable<int> assignedColors)
    {
        return assignedColors.All(arg => arg > -1);
    }

    private static bool IsSafeColor(int currentVertex, IReadOnlyList<List<int>> vertices,
        IReadOnlyList<int> assignedColors, int color)
    {
        foreach (var adjacentVertex in vertices[currentVertex])
            if (assignedColors[adjacentVertex] == color)
                return false;

        return true;
    }
}