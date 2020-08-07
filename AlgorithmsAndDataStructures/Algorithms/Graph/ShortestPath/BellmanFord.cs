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
        public (int, int[] path) MinDistance(WeightedGraphVertex[] graph, int from, int to)
        {
            var distance = new int[graph.Length];
            var path = new int[graph.Length];
            var isRelaxed = true;
            var edges = CollectEdges(graph);

            InitializeDisatances(graph, from, distance);

            // Algorithm performs only V -1 cycles here to avoid being caught in negative cycle.
            for (var i = 0; i < graph.Length - 1 && isRelaxed; i++)
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

        private static bool RelaxEdge(WeightedGraphNodeEdge edge, int[] distance, int[] path)
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

        private static List<WeightedGraphNodeEdge> CollectEdges(WeightedGraphVertex[] graph)
        {
            return graph.SelectMany(arg => arg.Edges).ToList();
        }

        private static void InitializeDisatances(WeightedGraphVertex[] graph, int from, int[] distance)
        {
            for (var i = 0; i < graph.Length; i++)
            {
                distance[i] = int.MaxValue;
            }

            distance[from] = 0;
        }
    }
}
