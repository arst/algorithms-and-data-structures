using System.Collections.Generic;
using System.Linq;
using AlgorithmsAndDataStructures.Algorithms.Graph.Common;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.MinimumSpanningTree;

public class PrimsAlgorithm
{
#pragma warning disable CA1822 // Mark members as static
    public int GetMinimumSpanningTreeWeight(WeightedGraphVertex[] graph)
#pragma warning restore CA1822 // Mark members as static
    {
        if (graph is null) return default;

        var minimumSpanningTreeWeight = 0;
        var minimumSpanningTree = new List<WeightedGraphNodeEdge>();
        var spanningTree = new HashSet<int>();
        var edges = graph.SelectMany(arg => arg.Edges).ToList();
        spanningTree.Add(0);

        while (spanningTree.Count < graph.Length)
        {
            WeightedGraphNodeEdge minEdge = null;

            for (var i = 0; i < edges.Count; i++)
                if ((minEdge == null || minEdge.Weight > edges[i].Weight) &&
                    spanningTree.Contains(edges[i].From) &&
                    !spanningTree.Contains(edges[i].To))
                    minEdge = edges[i];

            if (minEdge is null) continue;

            edges.Remove(minEdge);
            minimumSpanningTree.Add(minEdge);
            minimumSpanningTreeWeight += minEdge.Weight;
            spanningTree.Add(minEdge.To);
        }

        return minimumSpanningTreeWeight;
    }
}