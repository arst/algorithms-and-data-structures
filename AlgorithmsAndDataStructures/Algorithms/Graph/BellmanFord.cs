namespace AlgorithmsAndDataStructures.Algorithms.Graph
{
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

            while (isNotFinalized)
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
                }
            }

            return (distance[to], path);
        }
    }
}
