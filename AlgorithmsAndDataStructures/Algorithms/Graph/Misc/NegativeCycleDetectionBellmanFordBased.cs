using AlgorithmsAndDataStructures.Algorithms.Graph.Common;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.Misc
{
    public class NegativeCycleDetectionBellmanFordBased
    {
        public bool HasNegativeCycle(WeightedGraphNode[] graph)
        {
            var distance = new int[graph.Length];
            var distanceChanged = true;

            for (int i = 1; i < graph.Length; i++)
            {
                distance[i] = int.MaxValue;
            }

            // Algorithm performs only V -1 cycles here to avoid being caught in negative cycle.
            for (int j = 0; j < graph.Length - 1 && distanceChanged; j++)
            {
                for (int i = 0; i < graph.Length - 1 && distanceChanged; i++)
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


            for (int i = 0; i < graph.Length; i++)
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
