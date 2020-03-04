using System;
using System.Linq;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.TravelingSalesman
{
    public class GreedyTravelingSalesman
    {
        public int GetPath(int[][] graph)
        {
            var visited = new bool[graph.Length];

            return Travel(graph, 0, visited, 0, 0);
        }

        private int Travel(int[][] graph, int currentVertice, bool[] visited, int startingVertice, int path)
        {
            visited[currentVertice] = true;

            if (graph[currentVertice][startingVertice] > 0 && visited.All(arg => arg))
            {
                return path + graph[currentVertice][startingVertice];
            }

            var minEdghe = GetMinEdge(graph, currentVertice, visited);

            path += graph[currentVertice][minEdghe];

            return Travel(graph, minEdghe, visited, startingVertice, path);
        }

        private int GetMinEdge(int[][] graph, int currentVertice, bool[] visited)
        {
            var minIndex = -1;
            var minValue = int.MaxValue;

            for (int i = 0; i < graph.Length; i++)
            {
                if (graph[currentVertice][i] > 0 && minValue > graph[currentVertice][i] && !visited[i])
                {
                    minValue = graph[currentVertice][i];
                    minIndex = i;
                }
            }

            return minIndex;
        }
    }
}
