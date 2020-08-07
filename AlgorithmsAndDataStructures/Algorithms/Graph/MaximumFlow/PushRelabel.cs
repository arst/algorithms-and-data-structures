using System;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.MaximumFlow
{
    public class PushRelabel
    {
        public int GetMaxFlow(int[][] graph)
        {
            var residualGraph = new int[graph.Length][];
            var heights = new int[graph.Length];
            heights[0] = graph.Length;
            var excess = new int[graph.Length];

            Initialize(graph, residualGraph, excess);

            while (HasAccess(excess))
            {
                var currentVertice = GetMostHighVedrticeWithAnExcess(excess, heights);

                if (!Push(residualGraph, currentVertice, excess, heights))
                {
                    Relabel(currentVertice, heights);
                }
            }

            var flow = 0;

            for (var i = 0; i < residualGraph.Length; i++)
            {
                flow += residualGraph[i][0];
            }

            return flow;
        }

        private bool HasAccess(int[] excess)
        {
            for (var i = 1; i < excess.Length - 1; i++)
            {
                if (excess[i] > 0)
                {
                    return true;
                }
            }

            return false;
        }

        private int GetMostHighVedrticeWithAnExcess(int[] excess, int[] height)
        {
            var maxHight = int.MinValue;
            var maxHeightIndex = -1;

            for (var i = 1; i < excess.Length - 1; i++)
            {
                if (excess[i] > 0 && (maxHeightIndex == -1 || height[maxHeightIndex]  > maxHight))
                {
                    maxHeightIndex = i;
                    maxHight = height[maxHeightIndex];
                }
            }

            return maxHeightIndex;
        }

        private static void Initialize(int[][] graph, int[][] residualGraph, int[] excess)
        {
            for (var i = 0; i < graph.Length; i++)
            {
                residualGraph[i] = new int[graph.Length];

                for (var j = 0; j < residualGraph[i].Length; j++)
                {
                    residualGraph[i][j] = graph[i][j];
                }
            }

            for (var i = 0; i < graph.Length; i++)
            {
                residualGraph[0][i] = 0;
                residualGraph[i][0] = graph[0][i];
                excess[i] = graph[0][i];
            }
        }

        public bool Push(int[][] residualGraph, int currentVertice, int[] excess, int[] heights)
        {
            for (var i = 0; i < residualGraph.Length; i++)
            {
                if (residualGraph[currentVertice][i] > 0 && heights[currentVertice] == heights[i] + 1)
                {
                    var delta = Math.Min(excess[currentVertice], residualGraph[currentVertice][i]);

                    residualGraph[currentVertice][i] = residualGraph[currentVertice][i] - delta;
                    residualGraph[i][currentVertice] = residualGraph[i][currentVertice] + delta;

                    excess[currentVertice] = excess[currentVertice] - delta;
                    excess[i] = excess[i] + delta;

                    return true;
                }
            }

            return false;
        }

        public void Relabel(int currentVertice, int[] heights)
        {
            heights[currentVertice] = heights[currentVertice] + 1;
        }
    }
}
