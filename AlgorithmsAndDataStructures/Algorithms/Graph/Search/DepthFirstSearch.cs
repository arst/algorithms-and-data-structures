using AlgorithmsAndDataStructures.DataStructures.Graph;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.Search
{
    public class DepthFirstSearch
    {
        public List<int> Traverse(GraphVertex<int>[] graph)
        {
            var result = new HashSet<int>();
            var visited = new HashSet<int>();

            TraverseInternal(0, graph, result, visited);
            
            return result.ToList();
        }

        private void TraverseInternal(int node, GraphVertex<int>[] graph, HashSet<int> result, HashSet<int> visited)
        {
            result.Add(graph[node].Value);
            visited.Add(node);

            var notVisitedAdjacentNodes = graph[node].AdjacentVertices
                .Where(arg => !visited.Contains(arg));

            foreach (var adjacentNode in notVisitedAdjacentNodes)
            {
                TraverseInternal(adjacentNode, graph, result, visited);   
            }
        }

        public List<int> TraverseNonRecursive(GraphVertex<int>[] graph)
        {
            var result = new HashSet<int>();
            var visited = new HashSet<int>();
            var stack = new Stack<int>();
            stack.Push(0);
            result.Add(graph[0].Value);

            while (true)
            {
                if (!stack.Any())
                {
                    break;
                }

                var currentVertice = stack.Peek();
                var adjacentNodes = graph[currentVertice].AdjacentVertices;

                if (!adjacentNodes.Except(visited).Any())
                {
                    stack.Pop();
                }
                else
                {
                    for (var i = 0; i < adjacentNodes.Count; i++)
                    {
                        if (!visited.Contains(adjacentNodes[i]))
                        {
                            visited.Add(adjacentNodes[i]);
                            stack.Push(adjacentNodes[i]);
                            result.Add(graph[adjacentNodes[i]].Value);
                            break;
                        }
                    }
                }
            }

            return result.ToList();
        }
    }
}
