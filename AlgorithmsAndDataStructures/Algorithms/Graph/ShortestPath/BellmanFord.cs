using System;
using AlgorithmsAndDataStructures.Algorithms.Graph.Common;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.ShortestPath
{
    /*
    Negative weighted edges allowed: YES
    Complexity: worst(V*E)(which can lead to quadratic complexity for dense graphs), best - (E) (An example of a graph that would only need one round of relaxation is a graph where each vertex only connects to the next one in a linear fashion)
    Application: Most famous - distance-vector routing protocol. This protocol decides how to route packets of data on a network. 
    The distance equation (to decide weights in the network) is the number of routers a certain path must go through to reach its destination.
    */
    public class BellmanFord
    {
#pragma warning disable CA1822 // Mark members as static
        public (int, int[] path) MinDistance(WeightedGraphVertex[] graph, int from, int to)
#pragma warning restore CA1822 // Mark members as static
        {
            if (graph is null)
            {
                return (default, Array.Empty<int>());
            }

            var distance = new int[graph.Length];
            var path = new int[graph.Length];
            var isRelaxed = true;
            var edges = CollectEdges(graph);

            InitializeDistances(graph, from, distance);

            // Algorithm performs only V -1 cycles here to avoid being caught in negative cycle.
            for (var i = 0; i < graph.Length - 1; i++)
            {
                foreach (var edge in edges)
                {
                    isRelaxed = RelaxEdge(edge, distance, path);
                }
                // If we haven't recalculated any distances, then it means that we have our distances finalized.
                if (!isRelaxed)
                {
                    break;
                }
            }

            return (distance[to], path);
        }

        private static bool RelaxEdge(WeightedGraphNodeEdge edge, IList<int> distance, IList<int> path)
        {
            var relaxed = false;

            if (distance[edge.To] > distance[edge.From] + edge.Weight)
            {
                path[edge.To] = edge.From;
                distance[edge.To] = distance[edge.From] + edge.Weight;
                relaxed = true;
            }

            return relaxed;
        }

        private static List<WeightedGraphNodeEdge> CollectEdges(IEnumerable<WeightedGraphVertex> graph)
        {
            return graph.SelectMany(arg => arg.Edges).ToList();
        }

        private static void InitializeDistances(IReadOnlyCollection<WeightedGraphVertex> graph, int from, IList<int> distance)
        {
            for (var i = 0; i < graph.Count; i++)
            {
                distance[i] = int.MaxValue;
            }

            distance[from] = 0;
        }
    }
}
