using System.Collections.Generic;
using System.Linq;
using AlgorithmsAndDataStructures.Algorithms.Graph.Common;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.LongestPath;

public class CriticalPath
{
#pragma warning disable CA1822 // Mark members as static
    public int GetCriticalPath(WeightedGraphVertex[] graph)
#pragma warning restore CA1822 // Mark members as static
    {
        if (graph is null) return default;

        var modifiedGraph = AppendDummyNodes(graph);

        var topologicalSort = SortTopologically(modifiedGraph);
        var criticalPathValue = CalculateCriticalPath(modifiedGraph, topologicalSort);

        return criticalPathValue[^1];
    }

    private static int[] CalculateCriticalPath(IReadOnlyList<WeightedGraphVertex> modifiedGraph,
        Stack<int> topologicalSort)
    {
        var criticalPathValue = new int[modifiedGraph.Count];
        var criticalPath = new int[modifiedGraph.Count];

        while (topologicalSort.Count > 0)
        {
            var currentNodeIndex = topologicalSort.Pop();

            foreach (var edge in modifiedGraph[currentNodeIndex].Edges)
            {
                var criticalPathThroughCurrentVertexValue = criticalPathValue[currentNodeIndex] + edge.Weight;

                if (criticalPathThroughCurrentVertexValue > criticalPathValue[edge.To])
                {
                    criticalPathValue[edge.To] = criticalPathThroughCurrentVertexValue;
                    criticalPath[edge.To] = currentNodeIndex;
                }
            }
        }

        return criticalPathValue;
    }

    private static WeightedGraphVertex[] AppendDummyNodes(IReadOnlyList<WeightedGraphVertex> graph)
    {
        var (hasInboundEdges, hasOutboundEdges) = GetEdgeVertices(graph);

        var sourceNode = new WeightedGraphVertex();
        var targetNode = new WeightedGraphVertex();

        for (var i = 0; i < hasInboundEdges.Length; i++)
        {
            if (!hasInboundEdges[i]) sourceNode.Edges.Add(new WeightedGraphNodeEdge { To = i });

            if (!hasOutboundEdges[i]) graph[i].Edges.Add(new WeightedGraphNodeEdge { To = graph.Count + 1, From = i });
        }

        var modifiedGraph = graph.ToList();
        modifiedGraph.Add(sourceNode);
        modifiedGraph.Add(targetNode);


        return modifiedGraph.ToArray();
    }

    private static Stack<int> SortTopologically(WeightedGraphVertex[] graph)
    {
        var topologicalSort = new Stack<int>();
        var visited = new bool[graph.Length];

        // TODO: Probably it's better to return it from AppendDummyNodes and pass to this method as a parameter. This one looks a little bit "magical".
        var sourceNodeIndex = graph.Length - 2;

        SortTopologically(sourceNodeIndex, graph, topologicalSort, visited);

        return topologicalSort;
    }

    private static void SortTopologically(int currentVertex, IReadOnlyList<WeightedGraphVertex> graph,
        Stack<int> topologicalSort, IList<bool> visited)
    {
        visited[currentVertex] = true;

        foreach (var edge in graph[currentVertex].Edges)
            if (!visited[edge.To])
                SortTopologically(edge.To, graph, topologicalSort, visited);

        topologicalSort.Push(currentVertex);
    }

    private static (bool[] HasInboundEdges, bool[] HasOutboundEdges) GetEdgeVertices(
        IReadOnlyCollection<WeightedGraphVertex> graph)
    {
        var hasInboundEdges = new bool[graph.Count];
        var hasOutboundEdges = new bool[graph.Count];

#pragma warning disable HAA0401 // Possible allocation of reference type enumerator
        foreach (var vertex in graph)
#pragma warning restore HAA0401 // Possible allocation of reference type enumerator
        foreach (var edge in vertex.Edges)
        {
            hasInboundEdges[edge.To] = true;
            hasOutboundEdges[edge.From] = true;
        }

        return (HasInboundEdges: hasInboundEdges, HasOutboundEdges: hasOutboundEdges);
    }
}