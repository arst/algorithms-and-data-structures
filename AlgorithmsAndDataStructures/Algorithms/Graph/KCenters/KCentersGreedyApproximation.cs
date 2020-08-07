using System.Linq;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.KCenters
{
    public class KCentersGreedyApproximation
    {
#pragma warning disable CA1822 // Mark members as static
        public int[] GetKCenters(int[][] graph, int centers)
#pragma warning restore CA1822 // Mark members as static
        {
            if (graph is null)
            {
                return System.Array.Empty<int>();
            }

            var result = new int[centers];
            var foundCentersCount = 0;
            result[foundCentersCount] = 0;
            foundCentersCount++;
            

            while (foundCentersCount < result.Length)
            {
                var maxDistanceFromCentersVertexIndex = -1;
                var maxDistanceFromCentersVertex = int.MinValue;

                for (var i = 0; i < graph.Length; i++)
                {
                    if (result.Contains(i))
                    {
                        continue;
                    }

                    var minDistance = int.MaxValue;
                    for (var c = 0; c < foundCentersCount; c++)
                    {
                        if (c == i)
                        {
                            continue;
                        }

                        if (graph[c][i] < minDistance)
                        {
                            minDistance = graph[c][i];
                        }
                    }

                    if (maxDistanceFromCentersVertexIndex == -1 || maxDistanceFromCentersVertex < minDistance)
                    {
                        maxDistanceFromCentersVertexIndex = i;
                        maxDistanceFromCentersVertex = minDistance;
                    }
                }

                result[foundCentersCount] = maxDistanceFromCentersVertexIndex;
                foundCentersCount++;
            }

            return result;
        }
    }
}
