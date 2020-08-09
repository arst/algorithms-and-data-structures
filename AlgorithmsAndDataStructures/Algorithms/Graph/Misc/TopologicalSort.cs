using AlgorithmsAndDataStructures.DataStructures.Graph;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.Misc
{
    public class TopologicalSort
    {
#pragma warning disable CA1822 // Mark members as static
        public List<int> GetTopologicalOrder(GraphVertex<int>[] graph)
#pragma warning restore CA1822 // Mark members as static
        {
            if (graph is null)
            {
                return new List<int>(0);
            }

            if (CycleDetector.IsCyclic(graph))
            {
                throw new ArgumentException("This algorithm only operates on acyclic graphs.");
            }

            var order = new Stack<int>();
            var visited = new bool[graph.Length];

            for (var i = 0; i < visited.Length; i++)
            {
                if (!visited[i])
                {
                    Sort(graph, i, order, visited);
                }
            }


            return order.ToList();
        }

        private static void Sort(IReadOnlyList<GraphVertex<int>> graph, int currentVertex, Stack<int> order, IList<bool> visited)
        {
            for (var i = 0; i < graph[currentVertex].AdjacentVertices.Count; i++)
            {
                if (!visited[graph[currentVertex].AdjacentVertices[i]])
                {
                    Sort(graph, graph[currentVertex].AdjacentVertices[i], order, visited);
                }
            }

            visited[currentVertex] = true;
            order.Push(currentVertex);
        }
    }
}
