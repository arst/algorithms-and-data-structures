using System;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.DataStructures.Graph
{
    public class AdjacencyListGraph<T>
    {
        private GraphNode<T>[] graph;

        public AdjacencyListGraph(int initialCapacity = 8)
        {
            graph = new GraphNode<T>[initialCapacity];
        }

        public void AddEdge(int source, int destination)
        {
            if (graph[source] == null)
            {
                graph[source] = new GraphNode<T>();
            }

            if (graph[destination] == null)
            {
                graph[destination] = new GraphNode<T>();
            }

            graph[source].AdjacentNodes.Add(destination);
            graph[destination].AdjacentNodes.Add(source);
        }

        public List<int> DepthFirstSearch()
        {
            var result = new List<int>();

            var visited = new HashSet<int>();
            
            var stack = new Stack<int>();
            stack.Push(0);
            visited.Add(0);
            result.Add(0);
            
            while (stack.Count > 0)
            {
                var current = graph[stack.Peek()];
                var i = 0;
                var foundNotVisited = false;
                var adjacentNodes = current.AdjacentNodes;

                while (i < adjacentNodes.Count && !foundNotVisited)
                {
                    var nodeUnderVisit = adjacentNodes[i];

                    if (!visited.Contains(nodeUnderVisit))
                    {
                        visited.Add(nodeUnderVisit);
                        result.Add(nodeUnderVisit);
                        stack.Push(nodeUnderVisit);

                        foundNotVisited = true;
                    }

                    i++;
                }

                if (!foundNotVisited)
                    stack.Pop();
            }

            return result;
        }

        public List<int> DepthFirstSearchRecursive()
        {
            var result = new List<int>();
            var visited = new HashSet<int>();

            DepthFirstSearchRecursiveInternal(0, visited, result);

            return result;
        }

        private void DepthFirstSearchRecursiveInternal(int v, HashSet<int> visited, List<int> result)
        {
            result.Add(v);
            visited.Add(v);

            foreach (var adjacentNode in graph[v].AdjacentNodes)
            {
                if (!visited.Contains(adjacentNode))
                {
                    DepthFirstSearchRecursiveInternal(adjacentNode, visited, result);
                }
            }
        }

        public List<int> BreadthFirstSearch()
        {
            var result = new List<int>();

            var visited = new HashSet<int>();

            var queue = new Queue<int>();
            queue.Enqueue(0);
            visited.Add(0);
            result.Add(0);

            while (queue.Count > 0)
            {
                var current = graph[queue.Dequeue()];

                foreach (var adjacentNode in current.AdjacentNodes)
                {
                    if (!visited.Contains(adjacentNode))
                    {
                        queue.Enqueue(adjacentNode);
                        result.Add(adjacentNode);
                        visited.Add(adjacentNode);
                    }
                }
            }

            return result;
        }

        public List<int> BreadthFirstSearchRecursive()
        {
            var result = new List<int>();

            var visited = new HashSet<int>();

            var queue = new Queue<int>();
            queue.Enqueue(0);
            visited.Add(0);
            result.Add(0);

            while (queue.Count > 0)
            {
                var current = graph[queue.Dequeue()];

                foreach (var adjacentNode in current.AdjacentNodes)
                {
                    if (!visited.Contains(adjacentNode))
                    {
                        queue.Enqueue(adjacentNode);
                        result.Add(adjacentNode);
                        visited.Add(adjacentNode);
                    }
                }
            }

            return result;
        }
    }
}
