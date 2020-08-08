using AlgorithmsAndDataStructures.Algorithms.Graph.Common;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.Misc
{
    public class NegativeCycleDetectionBellmanFordBased
    {
#pragma warning disable CA1822 // Mark members as static
        public bool HasNegativeCycle(WeightedGraphVertex[] graph)
#pragma warning restore CA1822 // Mark members as static
        {
            if (graph is null)
            {
                return default;
            }

            var distance = new int[graph.Length];
            var distanceChanged = true;

            for (var i = 1; i < graph.Length; i++)
            {
                distance[i] = int.MaxValue;
            }

            // Algorithm performs only V -1 cycles here to avoid being caught in negative cycle.
            for (var j = 0; j < graph.Length - 1 && distanceChanged; j++)
            {
                for (var i = 0; i < graph.Length - 1 && distanceChanged; i++)
                {
                    var vertex = graph[i];
                    distanceChanged = false;

                    foreach (var edge in vertex.Edges)
                    {
                        if (distance[edge.To] > distance[i] + edge.Weight)
                        {
                            distance[edge.To] = distance[i] + edge.Weight;
                            distanceChanged = true;
                        }
                    }
                }
            }


            for (var i = 0; i < graph.Length; i++)
            {
                var vertex = graph[i];
                distanceChanged = false;

                foreach (var edge in vertex.Edges)
                {
                    if (distance[edge.To] > distance[i] + edge.Weight)
                    {
                        distanceChanged = true;
                        break;
                    }
                }
            }

            return distanceChanged;
        }
    }
}
