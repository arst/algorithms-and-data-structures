using System;

namespace AlgorithmsAndDataStructures.Algorithms.Graph
{
    public class DijkstraNaive
    {
        public (int, int[] path) MinDistance(WeightedGraphNode[] graph, int from, int to)
        {
            var visited = new bool[graph.Length];
            var distance = new int[graph.Length];
            var path = new int[graph.Length];

            for (int i = 0; i < distance.Length; i++)
            {
                distance[i] = Int32.MaxValue;
            }

            distance[from] = 0;
            var current = GetMinNodeIndex(distance, visited);

            while (current > -1)
            {
                var currentNode = graph[current];

                foreach (var edge in currentNode.Edges)
                {
                    if (distance[current] + edge.Weight < distance[edge.To])
                    {
                        distance[edge.To] = distance[current] + edge.Weight;
                        path[edge.To] = current;
                    }
                }

                visited[current] = true;
                current = GetMinNodeIndex(distance, visited);
            }

            return (distance[to], path);
        }

        private int GetMinNodeIndex(int[] distance, bool[] visited)
        {
            var currentMin = int.MaxValue;
            var currentMinIndex = -1;

            for (int i = 0; i < distance.Length; i++)
            {
                if (visited[i])
                {
                    continue;
                }

                if (distance[i] < currentMin)
                {
                    currentMinIndex = i;
                    currentMin = distance[i];
                }
            }

            return currentMinIndex;
        }
    }
}
