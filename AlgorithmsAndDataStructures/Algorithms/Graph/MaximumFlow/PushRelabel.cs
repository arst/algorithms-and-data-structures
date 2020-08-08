using System;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.MaximumFlow
{
    public class PushRelabel
    {
#pragma warning disable CA1822 // Mark members as static
        public int GetMaxFlow(int[][] graph)
#pragma warning restore CA1822 // Mark members as static
        {
            if (graph is null)
            {
                return default;
            }

            var residualGraph = new int[graph.Length][];
            var heights = new int[graph.Length];
            heights[0] = graph.Length;
            var excess = new int[graph.Length];

            Initialize(graph, residualGraph, excess);

            while (HasExcess(excess))
            {
                var currentVertex = GetHighestVertexWithAnExcess(excess, heights);

                if (!Push(residualGraph, currentVertex, excess, heights))
                {
                    Relabel(currentVertex, heights);
                }
            }

            var flow = 0;

            for (var i = 0; i < residualGraph.Length; i++)
            {
                flow += residualGraph[i][0];
            }

            return flow;
        }

        private static bool HasExcess(IReadOnlyList<int> excess)
        {
            for (var i = 1; i < excess.Count - 1; i++)
            {
                if (excess[i] > 0)
                {
                    return true;
                }
            }

            return false;
        }

        private static int GetHighestVertexWithAnExcess(IReadOnlyList<int> excess, IReadOnlyList<int> height)
        {
            var maxHeight = int.MinValue;
            var maxHeightIndex = -1;

            for (var i = 1; i < excess.Count - 1; i++)
            {
                if (excess[i] > 0 && (maxHeightIndex == -1 || height[maxHeightIndex]  > maxHeight))
                {
                    maxHeightIndex = i;
                    maxHeight = height[maxHeightIndex];
                }
            }

            return maxHeightIndex;
        }

        private static void Initialize(IReadOnlyList<int[]> graph, IList<int[]> residualGraph, IList<int> excess)
        {
            for (var i = 0; i < graph.Count; i++)
            {
                residualGraph[i] = new int[graph.Count];

                for (var j = 0; j < residualGraph[i].Length; j++)
                {
                    residualGraph[i][j] = graph[i][j];
                }
            }

            for (var i = 0; i < graph.Count; i++)
            {
                residualGraph[0][i] = 0;
                residualGraph[i][0] = graph[0][i];
                excess[i] = graph[0][i];
            }
        }

        private static bool Push(IReadOnlyList<int[]> residualGraph, int currentVertex, IList<int> excess, IReadOnlyList<int> heights)
        {
            for (var i = 0; i < residualGraph.Count; i++)
            {
                if (residualGraph[currentVertex][i] > 0 && heights[currentVertex] == heights[i] + 1)
                {
                    var delta = Math.Min(excess[currentVertex], residualGraph[currentVertex][i]);

                    residualGraph[currentVertex][i] = residualGraph[currentVertex][i] - delta;
                    residualGraph[i][currentVertex] = residualGraph[i][currentVertex] + delta;

                    excess[currentVertex] = excess[currentVertex] - delta;
                    excess[i] = excess[i] + delta;

                    return true;
                }
            }

            return false;
        }

        private static void Relabel(int currentVertex, IList<int> heights)
        {
            heights[currentVertex] = heights[currentVertex] + 1;
        }
    }
}
