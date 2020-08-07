using AlgorithmsAndDataStructures.Algorithms.Graph.Common;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.MinimumSpanningTree
{
    public class PrimsAlgorithm
    {
        public int GetMinimumSpanningTreeWeight(WeightedGraphVertex[] graph)
        {
            var minimumSpanningTreeWeight = 0;
            var minimumSpanningTree = new List<WeightedGraphNodeEdge>();
            var spanningTree = new HashSet<int>();
            var edges = graph.SelectMany(arg => arg.Edges).ToList();
            spanningTree.Add(0);

            while (spanningTree.Count < graph.Length)
            {
                WeightedGraphNodeEdge minEdge = null;

                for (int i = 0; i < edges.Count; i++)
                {
                    if ((minEdge == null || minEdge.Weight > edges[i].Weight) && spanningTree.Contains(edges[i].From) && !spanningTree.Contains(edges[i].To))
                    {
                        minEdge = edges[i];
                    }
                }
                edges.Remove(minEdge);
                minimumSpanningTree.Add(minEdge);
                minimumSpanningTreeWeight += minEdge.Weight;
                spanningTree.Add(minEdge.To);
            }

            return minimumSpanningTreeWeight;
        }
    }
}
