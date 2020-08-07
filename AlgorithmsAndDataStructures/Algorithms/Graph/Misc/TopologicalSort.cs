using AlgorithmsAndDataStructures.DataStructures.Graph;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.Misc
{
    public class TopologicalSort
    {
        public List<int> GetTopologicalOrder(GraphNode<int>[] graph)
        {
            if (new CycleDetection().IsCyclic(graph))
            {
                throw new ArgumentException("This algorythm only operates on acyclic graphs.");
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

        private void Sort(GraphNode<int>[] graph, int currentVertex, Stack<int> order, bool[] visited)
        {
            for (var i = 0; i < graph[currentVertex].AdjacentNodes.Count; i++)
            {
                if (!visited[graph[currentVertex].AdjacentNodes[i]])
                {
                    Sort(graph, graph[currentVertex].AdjacentNodes[i], order, visited);
                }
            }

            visited[currentVertex] = true;
            order.Push(currentVertex);
        }
    }
}
