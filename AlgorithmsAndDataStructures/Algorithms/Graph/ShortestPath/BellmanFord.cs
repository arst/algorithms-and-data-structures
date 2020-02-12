using AlgorithmsAndDataStructures.Algorithms.Graph.Common;

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
        public (int, int[] path) MinDistance(WeightedGraphNode[] graph, int from, int to)
        {
            var distance = new int[graph.Length];
            var path = new int[graph.Length];
            var isNotFinalized = true;

            for (int i = 0; i < graph.Length; i++)
            {
                distance[i] = i == from ? 0 : int.MaxValue;
            }

            // Algorithm performs only V -1 cycles here to avoid being caught in negative cycle.
            for (int j = 0; j < graph.Length - 1 && isNotFinalized; j++)
            {
                for (int i = 0; i < graph.Length; i++)
                {
                    var vertex = graph[i];
                    isNotFinalized = false;

                    foreach (var edge in vertex.Edges)
                    {
                        if (distance[edge.To] > distance[i] + edge.Weight)
                        {
                            path[edge.To] = i;
                            distance[edge.To] = distance[i] + edge.Weight;
                            isNotFinalized = true;
                        }
                    }

                    // If we haven't recalculated any distances, then it means that we have our distances finalized.
                    if (!isNotFinalized)
                    {
                        break;
                    }
                }
            }
            
            return (distance[to], path);
        }
    }
}
