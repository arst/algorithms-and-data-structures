using System;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.MaximumFlow
{
    public class MaximumBirpartiteMatchingDfsBased
    {
        public int GetMaxMatching(int[][] graph)
        {
            var result = 0;
            var assignment = new int[graph.Length];

            for (int i = 0; i < assignment.Length; i++)
            {
                assignment[i] = -1;
            }

            for (int i = 0; i < graph.Length; i++)
            {
                var visited = new bool[graph.Length];
                if (TryAssign(i, graph, visited, assignment))
                {
                    result++;
                }
            }

            return result;
        }

        private bool TryAssign(int currentVertice, int[][] graph, bool[] visited, int[] assignment)
        {
            for (int i = 0; i < graph.Length; i++)
            {
                if (graph[currentVertice][i] > 0 && !visited[i])
                {
                    visited[i] = true;
                    if (assignment[i] < 0 || TryAssign(assignment[i], graph, visited, assignment))
                    {
                        assignment[i] = currentVertice;
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
