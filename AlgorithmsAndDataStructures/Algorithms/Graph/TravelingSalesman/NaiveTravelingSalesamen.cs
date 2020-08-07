using System;
using System.Linq;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.TravelingSalesman
{
    public class NaiveTravelingSalesamen
    {
        public int GetPath(int[][] graph)
        {
            var visited = new bool[graph.Length];
            visited[0] = true;
            return TravelingSalesman(graph, 0, visited, 0, int.MaxValue);
        }

        private int TravelingSalesman(int[][] graph, int currentVertice, bool[] visited, int currentPathhWeight, int minPathWeight)
        {

            if (visited.All(arg => arg) && graph[currentVertice][0] > 0)
            {
                return Math.Min(currentPathhWeight + graph[currentVertice][0], minPathWeight);
            }

            for (var i = 0; i < graph.Length; i++)
            {
                if (graph[currentVertice][i] < 1 || visited[i])
                {
                    continue;
                }

                visited[i] = true;
                minPathWeight = TravelingSalesman(graph, i, visited, currentPathhWeight + graph[currentVertice][i], minPathWeight);
                visited[i] = false;
            }


            return minPathWeight;
        }
    }
}
