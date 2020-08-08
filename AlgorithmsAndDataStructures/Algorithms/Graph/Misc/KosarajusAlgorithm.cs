using System.Collections.Generic;
using AlgorithmsAndDataStructures.Algorithms.Graph.Common;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.Misc
{
    public class KosarajusAlgorithm
    {
#pragma warning disable CA1822 // Mark members as static
        public bool IsConnected(WeightedGraphVertex[] graph)
#pragma warning restore CA1822 // Mark members as static
        {
            if (graph is null)
            {
                return default;
            }

            var visited = new bool[graph.Length];

            Dfs(graph, 0, visited);

            for (var i = 0; i < visited.Length; i++)
            {
                if (!visited[i])
                {
                    return false;
                }
            }

            var transposedGraph = GetTransposed(graph);
            var transposedVisited = new bool[graph.Length];

            Dfs(transposedGraph, 0, transposedVisited);

            for (var i = 0; i < transposedVisited.Length; i++)
            {
                if (!transposedVisited[i])
                {
                    return false;
                }
            }

            return true;
        }

        private static void Dfs(WeightedGraphVertex[] graph, int currentVertex, IList<bool> visited)
        {
            visited[currentVertex] = true;

            for (var i = 0; i < graph[currentVertex].Edges.Count; i++)
            {
                var adjacentVertex = graph[currentVertex].Edges[i].To;

                if (!visited[adjacentVertex])
                {
                    Dfs(graph, adjacentVertex, visited);
                }
            }
        }

        private static WeightedGraphVertex[] GetTransposed(IReadOnlyList<WeightedGraphVertex> graph)
        {
            var result = new WeightedGraphVertex[graph.Count];

            for (var i = 0; i < graph.Count; i++)
            {
                result[i] = result[i] == null ? new WeightedGraphVertex() : result[i];

                for (var j = 0; j < graph[i].Edges.Count; j++)
                {
                    var from = graph[i].Edges[j].To;

                    result[from] ??= new WeightedGraphVertex();

                    result[from].Edges.Add(new WeightedGraphNodeEdge
                    {
                        From = from,
                        To = graph[i].Edges[j].From,
                        Weight = graph[i].Edges[j].Weight
                    });
                }
            }

            return result;
        }
    }
}
