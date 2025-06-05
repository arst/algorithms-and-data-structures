using System.Collections.Generic;
using System.Linq;
using AlgorithmsAndDataStructures.Algorithms.Graph.Common;
using AlgorithmsAndDataStructures.DataStructures.DisjointSet;
using AlgorithmsAndDataStructures.DataStructures.Graph;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.MinimumSpanningTree;

public class KruskalMinimumSpanningTreeWithDisjointSet
{
    // Complexity is O(ElogE) or O(ElogV):
    // E * log E - to sort vertices
    // log V - find connectivity with union find
    // overall E*logE + logV
    // Without a disjoint set check for cycle takes linear time.
#pragma warning disable CA1822 // Mark members as static
    public int GetMinimumSpanningTreeWeight(WeightedGraphVertex[] graph)
#pragma warning restore CA1822 // Mark members as static
    {
        if (graph is null) return default;

        var minimumSpanningTreeWeight = 0;
        // ReSharper disable once CollectionNeverQueried.Local
        var minimumSpanningTree = new List<WeightedGraphNodeEdge>();
        var spanningTree = new GraphVertex<int>[graph.Length];
        var disjointSet = new WeightedTreeCoompressedPathDisjoinSet(graph.Length);

        for (var i = 0; i < spanningTree.Length; i++) spanningTree[i] = new GraphVertex<int>();

        var spanningTreeSize = 0;
        var currentEdgeIndex = 0;

        var edges = graph
            .SelectMany(arg => arg.Edges)
            .OrderBy(arg => arg.Weight)
            .ToArray();


        while (spanningTreeSize < graph.Length - 1)
        {
            var currentEdge = edges[currentEdgeIndex];

            spanningTree[currentEdge.From].AdjacentVertices.Add(currentEdge.To);

            if (!disjointSet.Connected(currentEdge.From, currentEdge.To))
            {
                spanningTreeSize++;
                minimumSpanningTreeWeight += currentEdge.Weight;
                minimumSpanningTree.Add(currentEdge);
                disjointSet.Union(currentEdge.From, currentEdge.To);
            }
            else
            {
                spanningTree[currentEdge.From].AdjacentVertices.Remove(currentEdge.To);
            }

            currentEdgeIndex++;
        }

        return minimumSpanningTreeWeight;
    }
}