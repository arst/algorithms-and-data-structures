using AlgorithmsAndDataStructures.DataStructures.Graph;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsAndDataStructures.Algorithms.Graph
{
    public class DepthFirstSearch
    {
        public List<int> Traverse(GraphNode<int>[] graph)
        {
            var result = new HashSet<int>();
            var visited = new HashSet<int>();

            TraverseInternal(0, graph, result, visited);
            
            return result.ToList();
        }

        private void TraverseInternal(int node, GraphNode<int>[] graph, HashSet<int> result, HashSet<int> visited)
        {
            result.Add(graph[node].Value);
            visited.Add(node);

            var notVisitedAdjacentNodes = graph[node].AdjacentNodes
                .Where(arg => !visited.Contains(arg));

            foreach (var adjacentNode in notVisitedAdjacentNodes)
            {
                TraverseInternal(adjacentNode, graph, result, visited);   
            }
        }
    }
}
