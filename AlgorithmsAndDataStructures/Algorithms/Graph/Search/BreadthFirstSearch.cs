using System.Collections.Generic;
using System.Linq;
using AlgorithmsAndDataStructures.DataStructures.Graph;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.Search;

public class BreadthFirstSearch
{
#pragma warning disable CA1822 // Mark members as static
    public List<int> Traverse(GraphVertex<int>[] graph)
#pragma warning restore CA1822 // Mark members as static
    {
        if (graph is null) return new List<int>(0);

        var result = new List<int>();
        var traversalQueue = new Queue<int>();
        var visited = new HashSet<int>();
        traversalQueue.Enqueue(0);

        while (traversalQueue.Any())
        {
            var current = traversalQueue.Dequeue();
            result.Add(graph[current].Value);
            visited.Add(current);
            var adjacentNodes = graph[current].AdjacentVertices;

            for (var i = 0; i < adjacentNodes.Count; i++)
            {
                if (visited.Contains(adjacentNodes[i])) continue;

                traversalQueue.Enqueue(adjacentNodes[i]);
            }
        }

        return result;
    }
}