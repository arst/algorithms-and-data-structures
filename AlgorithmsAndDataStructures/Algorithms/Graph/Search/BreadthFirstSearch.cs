using AlgorithmsAndDataStructures.DataStructures.Graph;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.Search
{
    public class BreadthFirstSearch
    {
        public List<int> Traverse(GraphNode<int>[] graph)
        {
            var result = new List<int>();
            var traversalQueue = new Queue<int>();
            var visited = new HashSet<int>();
            traversalQueue.Enqueue(0);

            while (traversalQueue.Any())
            {
                var current = traversalQueue.Dequeue();
                result.Add(graph[current].Value);
                visited.Add(current);
                var adjacentNodes = graph[current].AdjacentNodes;

                for (int i = 0; i < adjacentNodes.Count; i++)
                {
                    if (visited.Contains(adjacentNodes[i]))
                    {
                        continue;
                    }

                    traversalQueue.Enqueue(adjacentNodes[i]);
                }
            }

            return result;
        }
    }
}
